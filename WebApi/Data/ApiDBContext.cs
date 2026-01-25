using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApiDBContext: DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
