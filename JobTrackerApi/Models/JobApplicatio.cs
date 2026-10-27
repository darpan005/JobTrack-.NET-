namespace JobTrackerApi.Models;

public class JobApplication
{
    public int Id{get; set;}
    public string CompanyName{get; set;}=string.Empty;
    public string RoleTitle{get; set;}=string.Empty;
    public string Status{get; set;}="Applied";
    public decimal? Salary{get; set;}
    public DateTime AppliedDate{get; set;}= DateTime.UtcNow;


    public int UserId{get; set;}
    public User? User{get; set;}
}