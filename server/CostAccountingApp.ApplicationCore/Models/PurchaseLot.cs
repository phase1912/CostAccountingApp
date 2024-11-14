namespace CostAccountingApp.ApplicationCore.Models;

public class PurchaseLot(int shares, decimal pricePerShare, DateTime purchaseDate)
{
    public int Shares { get; set; } = shares;
    
    public decimal PricePerShare { get; set; } = pricePerShare;
    
    public DateTime PurchaseDate { get; set; } = purchaseDate;
}