using Microsoft.EntityFrameworkCore;
using JobTrackerApi.Models;
using JobTrackerApi.DTOs;
using JobTrackerApi.Data;

namespace JobTrackerApi.Services;

public class JobService : IJobService
{
    private readonly AppDbContext _context;

    public JobService(AppDbContext context)
    {
        _context=context;
    }

    public async Task<List<JobApplication>> GetUserJobAsync(int userId)
    {
        return await _context.JobApplications
                    .Where(j => j.UserId == userId)
                    .OrderByDescending(j => j.AppliedDate)
                    .ToListAsync();
    }

    public async Task<JobApplication?> GetJobByIdAsync(int id, int userId)
    {
        return await _context.JobApplications
                    .FirstOrDefaultAsync(j => j.Id == id && j.UserId == userId);
    }

    public async Task<JobApplication> CreateJobAsync(CreateJobDto dto, int userId)
    {
        var job = new JobApplication
        {
            CompanyName = dto.CompanyName,
            RoleTitle = dto.RoleTitle,
            Status = dto.Status,
            SalaryPackage = dto.SalaryPackage,
            UserId = userId,
            AppliedDate = DateTime.UtcNow
        };

        _context.JobApplications.Add(job);
        await _context.SaveChangesAsync();
        return job;
    }

    public async Task<bool> UpdateStatusAsync(int id, UpdateJobStatusDto dto, int userId)
    {
        var job = await _context.JobApplications
                    .FirstOrDefaultAsync(j => j.Id == id && j.UserId == userId);
        
        if(job == null) return false;

        job.Status = dto.Status;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteJobAsync(int id, int userId)
    {
        var job = await _context.JobApplications
                        .FirstOrDefaultAsync(j => j.Id == id && j.UserId == userId);
        
        if(job == null) return false;

        _context.JobApplications.Remove(job);
        await _context.SaveChangesAsync();
        return true;
    }
}