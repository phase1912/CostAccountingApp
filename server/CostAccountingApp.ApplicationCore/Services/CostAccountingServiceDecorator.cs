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

    public CalculateCostAccountingOutput CalculateSaleUsingLifoMethod(string companyName, int sharesToSell, decimal salePricePerShare)
    {
        _logger.LogInformation("Started calculating profit using lifo for {SharesToSell} shares by price {SalePricePerShare}", sharesToSell, salePricePerShare);
        
        var result = _costAccountingService.CalculateSaleUsingLifoMethod(companyName, sharesToSell, salePricePerShare);
        
        _logger.LogInformation("Calculation result: {Result}", result);
        
        return result;
    }

    public CalculateCostAccountingOutput CalculateSaleUsingFifoMethod(string companyName, int sharesToSell, decimal salePricePerShare)
    {
        _logger.LogInformation("Started calculating profit using fifo for {SharesToSell} shares by price {SalePricePerShare}", sharesToSell, salePricePerShare);
        
        var result = _costAccountingService.CalculateSaleUsingFifoMethod(companyName, sharesToSell, salePricePerShare);
        
        _logger.LogInformation("Calculation result: {Result}", result);
        
        return result;
    }
}
