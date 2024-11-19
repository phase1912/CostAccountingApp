using CostAccountingApp.ApplicationCore.Models.Entities;
using CostAccountingApp.TestData.DataFactory;

namespace CostAccountingApp.TestData.Models.Data;

public static class PurchaseLotFactory
{
    public static PurchaseLot PurchaseLot(
        this ITestDataFactory _,
        DateTime purchaseDate,
        string companyName = "Microsoft",
        int shares = 100,
        decimal pricePerShare = 10)
    {
        return new PurchaseLot(companyName, shares, pricePerShare, purchaseDate);
    }
}
