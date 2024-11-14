using AutoMapper;
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

    public CalculateCostAccountingUsingLifoMethodOutput? CalculateSaleUsingLifoMethod(
        int sharesToSell, decimal salePricePerShare)
    {
        try
        {
            if (sharesToSell <= 0 || salePricePerShare <= 0)
            {
                return null;
            }
            
            int remainingShares = sharesToSell;
            decimal totalCostBasis = 0;
            int totalSharesSold = 0;
            var lots = _repository.ListAll();
            var lotsDto = _mapper.Map<List<PurchaseLotDTO>>(lots);
            var orderedLots = lotsDto.OrderBy(lot => lot.PurchaseDate).ToList();

            foreach (var lot in orderedLots)
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

            int remainingTotalShares = orderedLots.Sum(lot => lot.Shares);
            decimal remainingCostBasis = orderedLots.Where(lot => lot.Shares > 0).Sum(lot => lot.Shares * lot.PricePerShare);
            decimal remainingSharesCostBasis = remainingTotalShares > 0 ? remainingCostBasis / remainingTotalShares : 0;
            
            return new CalculateCostAccountingUsingLifoMethodOutput(
                remainingTotalShares, soldSharesCostBasis, remainingSharesCostBasis, totalProfit);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}