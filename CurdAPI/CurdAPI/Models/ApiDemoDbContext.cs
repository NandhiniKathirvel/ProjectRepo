using Microsoft.EntityFrameworkCore;

namespace CurdAPI.Models
{
    public class ApiDemoDbContext : DbContext
    {
        public ApiDemoDbContext(DbContextOptions<ApiDemoDbContext> options) : base(options) 
        {

        }
        public DbSet<Employees> Employees { get; set; }
    }
}
