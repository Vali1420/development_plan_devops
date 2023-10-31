using CarWebApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarWebApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<CarEntity> CarEntity { get; set; }
    }
}
