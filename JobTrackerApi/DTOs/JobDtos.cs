using System.ComponentModel.DataAnnotations;

namespace JobTrackerApi.DTOs;

public class CreateJobDto
{
    [Required]
    public string CompanyName {get; set;}=string.Empty;

    [Required]
    public string RoleTitle {get; set;}=string.Empty;

    public string Status {get; set;}="Applied";

    public decimal? SalaryPackage {get; set;}
}

public class UpdateJobStatusDto
{
    [Required]
    public string Status {get; set;}=string.Empty;
}