using MAirline.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAirline.API.Context
{
    public class MAirlineDbContext : DbContext
    {
        public MAirlineDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
    }
}