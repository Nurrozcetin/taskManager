using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using Task = TaskManager.Models.Task; 

namespace TaskManager.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(t => t.User) 
                .WithMany(u => u.tasks) 
                .HasForeignKey(t => t.UserID) 
                .OnDelete(DeleteBehavior.Cascade); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
