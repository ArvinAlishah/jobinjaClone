using jobinjaClone.Enums;
using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Exprince
{
    public class AddExprienceDTo
    {
        [Required]
        public string CompanyName { get; set; } = null!;
        [Required]

        public string RollName { get; set; } = null!;
        [Required]

        public string? Description { get; set; }
        [Required]

        public MonthEnum StartMonth { get; set; } 
        [Required]

        public string StartYear { get; set; } = null!;
        public MonthEnum? EndMonth { get; set; }
        public string? EndYear { get; set; }
        [Required]

        public bool StillWorking { get; set; }
        [Required]

        public bool DescriptionIson { get; set; }
    }
}
