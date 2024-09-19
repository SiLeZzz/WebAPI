using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos.Settlement
{
    public class UpdateSettlementDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be 3 characters")]
        [MaxLength(300, ErrorMessage = "Name can't be over 300 characters")]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
