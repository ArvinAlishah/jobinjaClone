using jobinjaClone.Enums;
using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Education
{
    public class AddEducationDTO
    {
        [Required]
        public string FieldName { get; set; } = null!;
        [Required]

        public string InstituteName { get; set; } = null!;
        [Required]

        public EducationDegreeEnum Degree { set; get; }
        [Required]

        public string StartYear { get; set; } = null!;
        public string? EndYear { get; set; } 
        public string? Description { get; set; }
        [Required]
        public bool StillEducatucating { get; set; }

    }
}
