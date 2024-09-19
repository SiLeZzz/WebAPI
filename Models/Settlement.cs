using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Settlement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(20,2)")]
        public double Price { get; set; }
        public int? ContractId { get; set; }
        public Contract? Contract { get; set; }
    }
}
