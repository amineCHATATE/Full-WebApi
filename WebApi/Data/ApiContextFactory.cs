using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApi.Data
{
    public class ApiContextFactory : IDesignTimeDbContextFactory<ApiDBContext>
    {
        public ApiDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiDBContext>();
            optionsBuilder.UseSqlite("Data Source=UnitTestDB.db");

            return new ApiDBContext(optionsBuilder.Options);
        }

    }
}
