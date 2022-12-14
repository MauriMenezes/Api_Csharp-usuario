using user.Models;
using Microsoft.EntityFrameworkCore;

namespace user.Data
{
  public class ApiDbContext : DbContext
  {
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    { }

    public DbSet<Cliente> Clientes { get; set; }
  }
}
