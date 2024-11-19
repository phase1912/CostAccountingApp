using CostAccountingApp.ApplicationCore.Inputs;
using CostAccountingApp.ApplicationCore.Interfaces;
using CostAccountingApp.ApplicationCore.Outputs;
using MediatR;

namespace CostAccountingApp.ApplicationCore.UseCases;

internal class CalculateCostAccountingUsingLifoMethodUseCase
    : IRequestHandler<CalculateCostAccountingUsingLifoMethodInput, CalculateCostAccountingOutput>
{
    private readonly ICostAccountingService _costAccountingService;

    public CalculateCostAccountingUsingLifoMethodUseCase(ICostAccountingService costAccountingService)
    {
        _costAccountingService = costAccountingService;
    }

    public Task<CalculateCostAccountingOutput> Handle(
        CalculateCostAccountingUsingLifoMethodInput request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_costAccountingService.CalculateSaleUsingLifoMethod(request.companyName, request.SharesToSell, request.SalePricePerShare));
    }
}
