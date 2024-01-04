using FundingApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FundingApplication.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> Options) : base(Options)
        {
            
        }
        public DbSet<User> users { get; set; }
        public DbSet<Salary> salaries { get; set; }
        public DbSet<MonthSalary> monthSalaries { get; set; }
        public DbSet<Spending> spending { get; set; }
    }
}
