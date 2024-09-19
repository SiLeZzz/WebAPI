using WebAPI.Dtos.Settlement;
using WebAPI.Models;

namespace WebAPI.Dtos.Contract
{
    public class ContractDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SettlementDto> Settlements { get; set; }
    }
}
