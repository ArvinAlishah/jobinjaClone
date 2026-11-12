using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Province
{
    public class UpdateYearExprienceDTO
    {
        [Required]
        public string Year { get; set; } = null!;
        [Required]
        public int id { get; set; } 
    }
}
