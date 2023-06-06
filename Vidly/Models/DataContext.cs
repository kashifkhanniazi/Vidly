using Microsoft.EntityFrameworkCore;
using Vidly.Models.DbModels;

namespace Vidly.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
