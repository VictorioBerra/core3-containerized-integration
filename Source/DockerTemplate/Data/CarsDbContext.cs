namespace DockerTemplate.Data
{
    using DockerTemplate.Models;
    using Microsoft.EntityFrameworkCore;

    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}
