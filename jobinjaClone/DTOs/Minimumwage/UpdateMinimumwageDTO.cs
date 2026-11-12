using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Province
{
    public class UpdateMinimumwageDTO
    {
        [Required]
        public string Minimumwage { get; set; } = null!;
        [Required]
        public int id { get; set; } 
    }
}
