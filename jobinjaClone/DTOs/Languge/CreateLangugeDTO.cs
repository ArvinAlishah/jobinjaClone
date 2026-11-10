using jobinjaClone.Enums;
using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Languge
{
    public class CreateLangugeDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public LanguageLevelEnum Level { get; set; }
    }
}
