using Microsoft.EntityFrameworkCore;

namespace RogueDuel.Infrastructure.Persistence;

public class RogueDuelDbContext : DbContext
{
    public RogueDuelDbContext(DbContextOptions<RogueDuelDbContext> options)
        : base(options)
    {
    }
}
