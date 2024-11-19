using CostAccountingApp.ApplicationCore.Inputs;
using CostAccountingApp.ApplicationCore.Interfaces;
using CostAccountingApp.ApplicationCore.Outputs;
using MediatR;

namespace CostAccountingApp.ApplicationCore.UseCases;

internal class CalculateCostAccountingUsingFifoMethodUseCase
    : IRequestHandler<CalculateCostAccountingUsingFifoMethodInput, CalculateCostAccountingOutput>
{
    private readonly ICostAccountingService _costAccountingService;

    public CalculateCostAccountingUsingFifoMethodUseCase(ICostAccountingService costAccountingService)
    {
        _costAccountingService = costAccountingService;
    }

    public Task<CalculateCostAccountingOutput> Handle(CalculateCostAccountingUsingFifoMethodInput request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_costAccountingService.CalculateSaleUsingFifoMethod(request.companyName, request.SharesToSell, request.SalePricePerShare));
    }
}
