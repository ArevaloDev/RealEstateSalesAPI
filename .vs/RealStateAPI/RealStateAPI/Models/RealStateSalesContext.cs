using Microsoft.EntityFrameworkCore;

namespace RealStateAPI.Models
{
    public class RealStateSalesContext:DbContext
    {
        public RealStateSalesContext(DbContextOptions<RealStateSalesContext> options):base(options)
        {

        }

        public DbSet<HousingLocation> HousingLocations { get; set; } = null!;
    }
}
