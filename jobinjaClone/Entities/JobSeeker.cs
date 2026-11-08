using jobinjaClone.Enums;

namespace jobinjaClone.Entities
{
    public class JobSeeker : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string BirthDay { get; set; } = null!;

        public string About { get; set; } = null!;

        public GenderEnum Gender { get; set; }

        public MarriageStatusEnum MarriageStatus { get; set; }

        public MilitaryServiceStatusEnum MiliteryStatus { get; set; }

        public int ProvinceId { get; set; } 

        public Province Province { get; set; } = null!;
        
        public List<Skills> Skills { get; set; } = null!;
        public List<Experience> Experiences { get; set; } = null!;

    }
}
