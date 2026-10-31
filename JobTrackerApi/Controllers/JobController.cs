using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using JobTrackerApi.DTOs;
using JobTrackerApi.Services;

namespace JobTrackerApi.Controller;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobsController(IJobService jobservice)
    {
        _jobService = jobservice;
    }

    private int GetCurrentUserId()
    {
        var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(idClaim!);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = GetCurrentUserId();
        var jobs = await _jobService.GetUserJobAsync(userId);
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var userId = GetCurrentUserId();
        var job = await _jobService.GetJobByIdAsync(id, userId);

        if(job == null) return NotFound(new {message = "Job Application Not found"});

        return Ok(job);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateJobDto dto)
    {
        var userId = GetCurrentUserId();
        var createdJob = await _jobService.CreateJobAsync(dto, userId);

        return CreatedAtAction(nameof(GetById), new {id = createdJob.Id}, createdJob);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id,[FromBody] UpdateJobStatusDto dto)
    {
        var userId = GetCurrentUserId();
        var updated = await _jobService.UpdateStatusAsync(id, dto, userId);

        if(!updated) return NotFound(new {message = "Job not found or Acess denied!"});

        return Ok(new { message = "Statud Updated sucessfully"});
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = GetCurrentUserId();
        var deleted = await _jobService.DeleteJobAsync(id, userId);

        if(!deleted) return NotFound(new {message = "Job not found or Acess Denied!"});

        return NoContent(); //204
    }
}

