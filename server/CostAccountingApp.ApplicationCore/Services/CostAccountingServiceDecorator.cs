using CostAccountingApp.ApplicationCore.Interfaces;
using CostAccountingApp.ApplicationCore.Outputs;
using  Microsoft.Extensions.Logging;

namespace CostAccountingApp.ApplicationCore.Services;

public class CostAccountingServiceDecorator : ICostAccountingService
{
    private readonly ICostAccountingService _costAccountingService;
    private readonly ILogger<CostAccountingServiceDecorator> _logger;

    public CostAccountingServiceDecorator(ILogger<CostAccountingServiceDecorator> logger, ICostAccountingService costAccountingService)
    {
        _logger = logger;
        _costAccountingService = costAccountingService;
    }

    public CalculateCostAccountingUsingLifoMethodOutput CalculateSaleUsingLifoMethod(int sharesToSell, decimal salePricePerShare)
    {
        _logger.LogInformation("Started calculating profit using lifo for {SharesToSell} shares by price {SalePricePerShare}", sharesToSell, salePricePerShare);
        
        var result = _costAccountingService.CalculateSaleUsingLifoMethod(sharesToSell, salePricePerShare);
        
        _logger.LogInformation("Calculation result: {Result}", result);
        
        return result;
    }
}