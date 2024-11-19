namespace CostAccountingApp.ApplicationCore.Models.Entities;

public class PurchaseLot(string companyName, int shares, decimal pricePerShare, DateTime purchaseDate)
{
    public string CompanyName { get; set; } = companyName;
    
    public int Shares { get; set; } = shares;
    
    public decimal PricePerShare { get; set; } = pricePerShare;
    
    public DateTime PurchaseDate { get; set; } = purchaseDate;
}
