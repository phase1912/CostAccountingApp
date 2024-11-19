using CostAccountingApp.ApplicationCore.Outputs;

namespace CostAccountingApp.ApplicationCore.Interfaces;

public interface ICostAccountingService
{
    public CalculateCostAccountingOutput CalculateSaleUsingLifoMethod(string companyName, int sharesToSell, decimal salePricePerShare);

    public CalculateCostAccountingOutput CalculateSaleUsingFifoMethod(string companyName, int sharesToSell, decimal salePricePerShare);
}
