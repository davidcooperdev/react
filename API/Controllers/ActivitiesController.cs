
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
//using Details;

namespace API.Controllers;

//[ApiController]
//[Route("controller")]
public class ActivitiesController : BaseApiController
{
    private readonly DataContext context;
    

    [HttpGet]
    public async Task<ActionResult<List<Domain.Activity>>> GetActivities()
    {
        return await Mediator.Send(new Application.Activities.List.Query());

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Domain.Activity>> GetActivity(Guid id)
    {
        return await Mediator.Send(new Application.Activities.Details.Query{Id = id });

        //return Ok();
    }

}