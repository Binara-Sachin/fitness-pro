using Microsoft.EntityFrameworkCore;
using CheatMealAPI.Models;

namespace CheatMealAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<CheatMeal> CheatMeals { get; set; }
    }
}
