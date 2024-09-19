using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos.Contract
{
    public class CreateContractDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be 3 characters")]
        [MaxLength(300, ErrorMessage = "Name can't be over 300 characters")]
        public string Name { get; set; }
    }
}
