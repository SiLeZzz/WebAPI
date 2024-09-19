using System.Runtime.CompilerServices;
using WebAPI.Dtos.Contract;
using WebAPI.Models;

namespace WebAPI.Mappers
{
    public static class ContractMappers
    {
        public static ContractDto ToContractDto(this Contract contractModel)
        {
            return new ContractDto
            {
                Id = contractModel.Id,
                Name = contractModel.Name,
                Settlements = contractModel.Settlements.Select(s => s.ToSettlementDto()).ToList()
            };
        }
        public static Contract ToContractFromCreateDto(this CreateContractDto createDto)
        {
            return new Contract
            {
                Name = createDto.Name
            };
        }
        
    }
}
