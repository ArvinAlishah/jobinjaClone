using jobinjaClone.Entities;
using jobinjaClone.Enums;
using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.JobSeeker
{
    public class UpdatePersonalDTO
    {
        [Required]
        public GenderEnum Gender { get; set; }

        [Required]
        public MarriageStatusEnum MarriageStatus { get; set; }

        [Required]
        public MilitaryServiceStatusEnum MiliteryStatus { get; set; }
        [Required]
        [MinLength(11)]
        public string Mobile { get; set; } = null!;
        [Required]

        public string BirthDay { get; set; } = null!;
        [Required]

        public int ProvinceId { get; set; }


    }
}
