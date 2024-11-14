using CostAccountingApp.ApplicationCore.Outputs;
using MediatR;

namespace CostAccountingApp.ApplicationCore.Inputs;

public record CalculateCostAccountingUsingLifoMethodInput(int SharesToSell, decimal SalePricePerShare)
    : IRequest<CalculateCostAccountingUsingLifoMethodOutput>;