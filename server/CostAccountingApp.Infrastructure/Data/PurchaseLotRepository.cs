using CostAccountingApp.ApplicationCore.Interfaces;
using CostAccountingApp.ApplicationCore.Models.Entities;

namespace CostAccountingApp.Infrastructure.Data;

public class PurchaseLotRepository : IPurchaseLotRepository
{
    public IReadOnlyList<PurchaseLot> ListAll()
    {
        return
        [
            new PurchaseLot(100, 20, new DateTime(2023, 1, 1)),
            new PurchaseLot(150, 30, new DateTime(2023, 2, 1)),
            new PurchaseLot(120, 10, new DateTime(2023, 3, 1))
        ];
    }
}