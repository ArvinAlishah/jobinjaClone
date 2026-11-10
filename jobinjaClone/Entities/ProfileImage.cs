namespace jobinjaClone.Entities
{
    public class ProfileImage:BaseEntity
    {
        public string Url { get; set; } = null!;

        public JobSeeker JobSeeker { get; set; } = null!;

        public int JobSeekerId { get; set; }

    }
}
