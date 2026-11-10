using jobinjaClone.Entities;
using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.JobSeeker
{
    public class UpdatePerfrenceDataDTO
    {
        [Required]
        public List<int> PrefersContactId { get; set; } = null!;
        [Required]

        public List<int> SeniorityLevelId { get; set; } = null!;
        [Required]

        public List<int> JobCategoriesId { get; set; } = null!;
        [Required]

        public string ExpectedSalary { get; set; } = null!;
        [Required]

        public List<int> ProvinceId { get; set; } = null!;
        [Required]

        public List<int> BenefitsId { get; set; } = null!;
    }
    
}
