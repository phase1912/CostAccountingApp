using AutoMapper;
using CostAccountingApp.ApplicationCore.Models.DTO;
using CostAccountingApp.ApplicationCore.Models.Entities;

namespace CostAccountingApp.ApplicationCore.Profiles;

public class PurchaseLotDTOProfile : Profile
{
    public PurchaseLotDTOProfile()
    {
        CreateMap<PurchaseLot, PurchaseLotDTO>();
    }
}