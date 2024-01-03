using Microsoft.EntityFrameworkCore;
using ResourceService.Resources;

namespace ResourceService.Database;

public class ResourceDbContext : DbContext {
    private readonly ILogger<ResourceDbContext> _logger;

    public DbSet<Resource> Resources { get; private set; }

    public ResourceDbContext(
            DbContextOptions<ResourceDbContext> options,
            ILogger<ResourceDbContext> logger) : base(options) {
        this._logger = logger;
    }
}
