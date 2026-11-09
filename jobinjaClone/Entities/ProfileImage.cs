namespace jobinjaClone.Entities
{
    public class ProfileImage:BaseEntity
    {
        public String Url { get; set; } = null!;

        public JobSeeker JobSeeker { get; set; } = null!;

        public int JobSeekerId { get; set; }

    }
}
