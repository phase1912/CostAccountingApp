namespace CostAccountingApp.ApplicationCore.Models.DTO;

public class PurchaseLotDTO
{
    public int Shares { get; set; }

    public decimal PricePerShare { get; set; }

    public DateTime PurchaseDate { get; set; }
}