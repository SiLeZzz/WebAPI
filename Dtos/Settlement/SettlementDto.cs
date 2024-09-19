namespace WebAPI.Dtos.Settlement
{
    public class SettlementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int? ContractId { get; set; }
    }
}
