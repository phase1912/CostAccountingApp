namespace CostAccountingApp.ApplicationCore.Models.DTO;

public class PurchaseLotDTO
{
    public string CompanyName { get; set; }
    
    public int Shares { get; set; }

    public decimal PricePerShare { get; set; }

    public DateTime PurchaseDate { get; set; }
}
