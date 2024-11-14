namespace CostAccountingApp.ApplicationCore.Outputs;

public record CalculateCostAccountingUsingLifoMethodOutput(
    int RemainingShares, decimal SoldCostBasis, decimal RemainingCostBasis, decimal Profit);