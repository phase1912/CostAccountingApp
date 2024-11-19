using CostAccountingApp.ApplicationCore.Outputs;
using MediatR;

namespace CostAccountingApp.ApplicationCore.Inputs;

public record CalculateCostAccountingUsingFifoMethodInput(string companyName, int SharesToSell, decimal SalePricePerShare)
    : IRequest<CalculateCostAccountingOutput>;
