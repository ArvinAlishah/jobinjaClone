using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Province
{
    public class UpdatePrefersContactDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int id { get; set; } 
    }
}
