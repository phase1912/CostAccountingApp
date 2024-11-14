using CostAccountingApp.ApplicationCore.Inputs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CostAccountingApp.Web.Controllers;

[ApiController]
[Route("api/cost-accounting")]
public class CostAccountingController : ControllerBase
{
    private readonly IMediator _mediator;

    public CostAccountingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("calculate-lifo")]
    public async Task<IActionResult> CalculateUsingLifoMethod([FromBody] CalculateCostAccountingUsingLifoMethodInput request)
    {
        var result = await _mediator.Send(request);
        
        if (result == null)
        {
            return BadRequest("Couldn't calculate result - Invalid request");
        }
        
        return Ok(result);
    }
}