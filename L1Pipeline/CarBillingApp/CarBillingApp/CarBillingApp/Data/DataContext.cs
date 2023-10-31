using CarBillingApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarBillingApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<BillingEntity> BillingEntity { get; set; }
    }
}
