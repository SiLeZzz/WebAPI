using WebAPI.Dtos.Settlement;
using WebAPI.Models;

namespace WebAPI.Mappers
{
    public static class SettlementMapper
    {
        public static SettlementDto ToSettlementDto(this Settlement settlementModel)
        {
            return new SettlementDto
            {
                Id = settlementModel.Id,
                Name = settlementModel.Name,
                Price = settlementModel.Price,
                ContractId = settlementModel.ContractId,
            };
        }
        public static Settlement ToSettlement(this CreateSettlementDto settlementDto, int contractId) 
        {
            return new Settlement
            {
                Name = settlementDto.Name,
                Price = settlementDto.Price,
                ContractId = contractId,
            };
        }
    }
}
