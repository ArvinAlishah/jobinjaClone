namespace jobinjaClone.Entities
{
    public class Skills : BaseEntity
    {
        public string Name { get; set; } = null!;

        public int JobSeekersId { get; set; }
        public JobSeeker JobSeekers { get; set; } = null!;


    }
}
