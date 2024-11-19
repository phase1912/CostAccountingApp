namespace CostAccountingApp.ApplicationCore.Outputs;

public record CalculateCostAccountingOutput(
    int RemainingShares, decimal SoldCostBasis, decimal RemainingCostBasis, decimal Profit, decimal ProfitAfterTaxes);
