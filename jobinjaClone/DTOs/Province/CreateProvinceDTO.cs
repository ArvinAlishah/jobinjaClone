using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Province
{
    public class CreatePrefersContactDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

    }
}
