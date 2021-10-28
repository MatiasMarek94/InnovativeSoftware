using InnovativeSoftware.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnovativeSoftware.Data
{
    public class DataContext : DbContext
    {
        protected DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}