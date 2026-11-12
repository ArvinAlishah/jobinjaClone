using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Province
{
    public class CreateYearExprienceDTO
    {
        [Required]
        [MaxLength(50)]
        public string Year { get; set; } = null!;

    }
}
