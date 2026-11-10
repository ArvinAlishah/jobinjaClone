using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.About
{
    public class UpdateAboutDTO
    {
        [Required]
        public string About { get; set; } = null!;
    }
}
