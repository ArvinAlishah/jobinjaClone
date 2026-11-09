namespace jobinjaClone.Entities
{
    public class Resume : BaseEntity
    {
        public int JobSeekerId { get; set; }
        public string Url { get; set; } = null!;
        public bool IsPublic { get; set; }
        public JobSeeker JobSeeker { get; set; } = null!;

    }
}
