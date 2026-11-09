using jobinjaClone.Enums;

namespace jobinjaClone.Entities
{
    public class Personal : BaseEntity
    {

        public GenderEnum Gender { get; set; }

        public MarriageStatusEnum MarriageStatus { get; set; }

        public MilitaryServiceStatusEnum MiliteryStatus { get; set; }

        public string Mobile { get; set; } = null!;
        public string BirthDay { get; set; } = null!;

        public int ProvinceId { get; set; }

        public Province Province { get; set; } = null!;
        public int JobSeekerId { get; set; }

        public JobSeeker JobSeeker {  get; set; } = null!;
    }
}
