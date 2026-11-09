namespace jobinjaClone.Entities
{
    public class Skills : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<JobSeeker> JobSeekers { get; set; } = null!;


    }
}
