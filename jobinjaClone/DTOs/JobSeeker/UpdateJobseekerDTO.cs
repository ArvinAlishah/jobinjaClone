using jobinjaClone.Enums;
using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.JobSeeker
{
    public class UpdateJobseekerDTO
    {
    }
    public class UpdateBasicDataDTO
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; } = null!;

        public WorkingStatusEnum WorkingStatus { get; set; }
        [Required]
        [MaxLength(20)]
        public string JobTitle { get; set; } = null!;
    }
}