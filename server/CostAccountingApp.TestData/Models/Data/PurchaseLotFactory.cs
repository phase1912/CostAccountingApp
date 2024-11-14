using CostAccountingApp.ApplicationCore.Models.Entities;
using CostAccountingApp.TestData.DataFactory;

namespace CostAccountingApp.TestData.Models.Data;

public static class PurchaseLotFactory
{
    public static PurchaseLot PurchaseLot(
        this ITestDataFactory _,
        DateTime purchaseDate,
        int shares = 100,
        decimal pricePerShare = 10)
    {
        return new PurchaseLot(shares, pricePerShare, purchaseDate);
    }
}