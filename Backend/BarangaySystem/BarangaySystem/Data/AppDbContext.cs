using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using BarangaySystem.Model.Entities;

namespace BarangaySystem.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }

        public DbSet<Resident> Residents { get; set; }
        public DbSet<Education> Education { get; set; }
    }
}
