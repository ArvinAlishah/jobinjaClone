using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Skill
{
    public class AddSkillDTO
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = null!;

    }
}
