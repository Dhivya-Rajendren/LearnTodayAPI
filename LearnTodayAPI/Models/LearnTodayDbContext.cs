using Microsoft.EntityFrameworkCore;

namespace LearnTodayAPI.Models
{
    public class LearnTodayDbContext:DbContext
    {
        public LearnTodayDbContext(DbContextOptions<LearnTodayDbContext> options):base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
    }
}
