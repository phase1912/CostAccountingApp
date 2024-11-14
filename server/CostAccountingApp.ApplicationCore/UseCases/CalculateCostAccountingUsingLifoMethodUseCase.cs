using CostAccountingApp.ApplicationCore.Inputs;
using CostAccountingApp.ApplicationCore.Interfaces;
using CostAccountingApp.ApplicationCore.Outputs;
using MediatR;

namespace CostAccountingApp.ApplicationCore.UseCases;

internal class CalculateCostAccountingUsingLifoMethodUseCase
    : IRequestHandler<CalculateCostAccountingUsingLifoMethodInput, CalculateCostAccountingUsingLifoMethodOutput>
{
    private readonly ICostAccountingService _costAccountingService;

    public CalculateCostAccountingUsingLifoMethodUseCase(ICostAccountingService costAccountingService)
    {
        _costAccountingService = costAccountingService;
    }

    public Task<CalculateCostAccountingUsingLifoMethodOutput?> Handle(
        CalculateCostAccountingUsingLifoMethodInput request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_costAccountingService.CalculateSaleUsingLifoMethod(request.SharesToSell, request.SalePricePerShare));
    }
}