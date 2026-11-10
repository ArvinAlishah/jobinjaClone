using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Province
{
    public class CreateBenefitsDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

    }
}
