using Ecommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
}
