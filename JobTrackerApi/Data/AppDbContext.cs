using Microsoft.EntityFrameworkCore;
using JobTrackerApi.Models;

using Microsoft.EntityFrameworkCore;
using JobTrackerApi.Models;

namespace jobTrackerApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options) : base(options){}

    public DbSet<User> Users => Set<User>();
    public DbSet<JobApplication> JobApplications => Set<JobApplication>();
    
}