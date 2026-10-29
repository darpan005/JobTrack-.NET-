using JobTrackerApi.DTOs;
using JobTrackerApi.Models;

namespace JobTrackerApi.Services;

public interface IJobService
{
    Task<List<JobApplication>> GetUserJobAsync(int userId);
    Task<JobApplication?> GetJobByIdAsync(int id, int userId);
    Task<JobApplication> CreateJobAsync(CreateJobDto dto, int userId);
    Task<bool> UpdateStatusAsync(int id, UpdateJobStatusDto dto, int userId);
    Task<bool> DeleteJobAsync(int id,int userId);
}