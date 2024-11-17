using CostAccountingApp.ApplicationCore.Outputs;

namespace CostAccountingApp.ApplicationCore.Interfaces;

public interface ICostAccountingService
{
    public CalculateCostAccountingUsingLifoMethodOutput CalculateSaleUsingLifoMethod(int sharesToSell, decimal salePricePerShare);
}