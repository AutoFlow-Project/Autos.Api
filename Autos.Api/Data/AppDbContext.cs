using Autos.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Autos.Api.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Auto> Autos { get; set; }
    }
}
