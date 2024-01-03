using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceService.Database;

namespace ResourceService.Resources;

[ApiController]
[Route("[controller]")]
public class ResourceController : ControllerBase
{
    private readonly ILogger<ResourceController> _logger;
    private readonly ResourceDbContext _dbContext;

    public ResourceController(
            ILogger<ResourceController> logger,
            ResourceDbContext dbContext) 
    {
        this._logger = logger;
        this._dbContext = dbContext;
    }

    [HttpGet(Name = "GetResources")]
    public async Task<IEnumerable<Resource>> Index()
    {
        return await this._dbContext.Resources.ToListAsync();
    }

    [HttpPost(Name = "AddResource")]
    [Route("")]
    public async Task<Resource> Add([FromBody] Resource newResource)
    {
        this._dbContext.Resources.Add(newResource);
        await this._dbContext.SaveChangesAsync();
        return newResource;
    }

    [HttpPut(Name = "EditResource")]
    [Route("[id]")]
    public async Task<Resource> Edit(int id, [FromBody] Resource model) {
        Resource resource = await this._dbContext.Resources
            .Where(r => r.Id == id)
            .SingleAsync();

        await this._dbContext.SaveChangesAsync();
        return resource;
    }

    [HttpDelete(Name = "DeleteResource")]
    [Route("[id]")]
    public async Task<Resource> Delete(int id) {
        Resource resource = await this._dbContext.Resources
            .Where(m => m.Id == id)
            .SingleAsync();
        
        this._dbContext.Remove(resource);
        await this._dbContext.SaveChangesAsync();
        return resource;
    }
}
