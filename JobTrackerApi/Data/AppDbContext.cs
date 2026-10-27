using Microsoft.EntityFrameworkCore;
using JobTrackerApi.Models;

namespace JobTrackerApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options) : base(options){}

    public DbSet<User> Users => Set<User>();
    public DbSet<JobApplication> JobApplications => Set<JobApplication>();
    
}