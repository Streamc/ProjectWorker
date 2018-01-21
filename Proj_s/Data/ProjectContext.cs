using Proj_s.Models;
using Microsoft.EntityFrameworkCore;


namespace Proj_s.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
           

        }
      
public DbSet<Project> Projects { get; set; }
        public DbSet<Worker> Workers{ get; set; }
       public DbSet<ProjectAssignment> ProjectAssignments{ get; set; }
   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project");
           
            modelBuilder.Entity<Worker>().ToTable("Worker");

            modelBuilder.Entity<ProjectAssignment>().ToTable("ProjectAssignment");

            modelBuilder.Entity<ProjectAssignment>()
               .HasKey(c => new { c.ProjectID, c.WorkerID });



        }



    }

}
