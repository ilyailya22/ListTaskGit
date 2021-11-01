using ListTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ListTask
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<MainTask> MainTasks { get; set; }

        public DbSet<SubTask> SubTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL($"server=localhost;port=3307;database=tasks;user=ilya;password=Merihov-2002");
        }
    }
}
