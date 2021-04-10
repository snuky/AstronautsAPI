using Microsoft.EntityFrameworkCore;

namespace DB.Models
{
    public class AstronautContext : DbContext
    {

        public DbSet<Astronaut> Astronaut { get; set; }
        public AstronautContext(DbContextOptions<AstronautContext> options)
            : base(options)
        {
        }



    }
}
