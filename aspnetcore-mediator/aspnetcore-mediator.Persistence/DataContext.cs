using Microsoft.EntityFrameworkCore;
using aspnetcore_mediator.Domain.Entities;

namespace aspnetcore_mediator.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
