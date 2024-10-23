
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

//[ApiController]
//[Route("controller")]
public class ActivitiesController : BaseApiController
{
    private readonly DataContext context;
    public ActivitiesController(DataContext context)
    {
        this.context = context;

    }

    [HttpGet]
    public async Task<ActionResult<List<Domain.Activity>>> GetActivities()
    {
        return await this.context.Activities.ToListAsync();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Domain.Activity>> GetActivity(Guid id)
    {
        return await this.context.Activities.FindAsync(id);
    }

}