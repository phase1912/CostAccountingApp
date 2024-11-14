using CostAccountingApp.ApplicationCore.Models;

namespace CostAccountingApp.ApplicationCore.Interfaces;

public interface IRepository
{
    public List<PurchaseLot> GetPurchaseLots();
}