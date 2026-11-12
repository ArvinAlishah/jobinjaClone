using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Province
{
    public class createMinimumwageTO
    {
        [Required]
        [MaxLength(50)]
        public string Minimumwage { get; set; } = null!;

    }
}
