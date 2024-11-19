using AutoMapper;
using CostAccountingApp.ApplicationCore.Exceptions;
using CostAccountingApp.ApplicationCore.Interfaces;
using CostAccountingApp.ApplicationCore.Models.DTO;
using CostAccountingApp.ApplicationCore.Outputs;

namespace CostAccountingApp.ApplicationCore.Services;

public class CostAccountingService : ICostAccountingService
{
    private readonly IPurchaseLotRepository _repository;
    private readonly IMapper _mapper;

    public CostAccountingService(IPurchaseLotRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public CalculateCostAccountingOutput CalculateSaleUsingFifoMethod(
        string companyName, int sharesToSell, decimal salePricePerShare)
    {

        var lots = _repository.ListAll();
        var lotsDto = _mapper.Map<List<PurchaseLotDTO>>(lots);
        var orderedLots = lotsDto.OrderBy(lot => lot.PurchaseDate).ToList();

        return CalculateSaleBase(companyName, sharesToSell, salePricePerShare, orderedLots);
    }
    
    public CalculateCostAccountingOutput CalculateSaleUsingLifoMethod(
        string companyName, int sharesToSell, decimal salePricePerShare)
    {

        var lots = _repository.ListAll();
        var lotsDto = _mapper.Map<List<PurchaseLotDTO>>(lots);
        var orderedLots = lotsDto.OrderByDescending(lot => lot.PurchaseDate).ToList();

        return CalculateSaleBase(companyName, sharesToSell, salePricePerShare, orderedLots);
    }

    private CalculateCostAccountingOutput CalculateSaleBase(string companyName, int sharesToSell, decimal salePricePerShare, List<PurchaseLotDTO> orderedLots)
    {
        if (sharesToSell <= 0 || salePricePerShare <= 0)
        {
            throw new CostAccountingAppException("Invalid request data");
        }
            
        int remainingShares = sharesToSell;
        decimal totalCostBasis = 0;
        int totalSharesSold = 0;

        if (sharesToSell > orderedLots.Sum(x => x.Shares))
        {
            throw new CostAccountingAppException("Invalid count of shares");
        }

        var filteredLots = orderedLots
            .Where(lot => string.Equals(lot.CompanyName, companyName, StringComparison.InvariantCultureIgnoreCase))
            .ToList();

        if (filteredLots.Count == 0)
        {
            throw new CostAccountingAppException("Could not find any shares");
        }
        
        foreach (var lot in filteredLots)
        {
            if (remainingShares <= 0) break;

            int sharesFromThisLot = Math.Min(remainingShares, lot.Shares);
            decimal costBasisFromThisLot = sharesFromThisLot * lot.PricePerShare;

            totalCostBasis += costBasisFromThisLot;
            totalSharesSold += sharesFromThisLot;
            remainingShares -= sharesFromThisLot;

            lot.Shares -= sharesFromThisLot;
        }
            
        decimal soldSharesRevenue = totalSharesSold * salePricePerShare;
        decimal totalProfit = soldSharesRevenue - totalCostBasis;
        decimal soldSharesCostBasis = totalSharesSold > 0 ? totalCostBasis / totalSharesSold : 0;

        int remainingTotalShares = filteredLots.Sum(lot => lot.Shares);
        decimal remainingCostBasis = filteredLots.Where(lot => lot.Shares > 0).Sum(lot => lot.Shares * lot.PricePerShare);
        decimal remainingSharesCostBasis = remainingTotalShares > 0 ? remainingCostBasis / remainingTotalShares : 0;
        decimal profitAfterTaxes = totalProfit - totalProfit * (decimal) 0.2;
            
        return new CalculateCostAccountingOutput(
            remainingTotalShares, soldSharesCostBasis, remainingSharesCostBasis, totalProfit, profitAfterTaxes);
    }
}
