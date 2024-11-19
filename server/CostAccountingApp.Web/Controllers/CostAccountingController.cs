using CostAccountingApp.ApplicationCore.Inputs;
using CostAccountingApp.ApplicationCore.Outputs;
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
    public async Task<CalculateCostAccountingOutput> CalculateUsingLifoMethod(
        [FromBody] CalculateCostAccountingUsingLifoMethodInput request)
    {
        return await _mediator.Send(request);
    }
    
    [HttpPost("calculate-fifo")]
    public async Task<CalculateCostAccountingOutput> CalculateUsingFifoMethod(
        [FromBody] CalculateCostAccountingUsingFifoMethodInput request)
    {
        return await _mediator.Send(request);
    }
}
