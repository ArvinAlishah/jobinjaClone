using jobinjaClone.Enums;

namespace jobinjaClone.Entities
{
    public class BasicData : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string JobTitel { get; set; } = null!;

        public WorkingStatusEnum WorkingStatus { get; set; }
        public int JobSeekerId { get; set; }

        public JobSeeker JobSeeker { get; set; } = null!;

    }
}
