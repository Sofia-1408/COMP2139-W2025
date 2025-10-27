using COMP2139_ICE.Areas.ProjectManagement.Models;

namespace COMP2139_ICE.Data;
using COMP2139_ICE.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Tasks)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Project>().HasData(
            new Project { ProjectId = 1, Name = "Assignment 1", Description = "COMP2139 Assignment 1" },
            new Project { ProjectId = 2, Name = "Assignment 2", Description = "COMP2139 Assignment 2" }
        );
    }
}