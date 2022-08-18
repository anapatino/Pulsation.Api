using Entities;
using Microsoft.EntityFrameworkCore;
namespace Data;

public class PulsationsDbContext:DbContext
{
    public PulsationsDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> People { get; set; }
}
