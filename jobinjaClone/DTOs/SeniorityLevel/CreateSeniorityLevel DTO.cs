using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Province
{
    public class CreateSeniorityLevelDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

    }
}
