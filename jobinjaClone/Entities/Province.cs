namespace jobinjaClone.Entities
{
    public class Province : BaseEntity
    {
        public String Name { get; set; } = null!;
        public List<JobSeeker> JobSeekers { get; set; } = null!;
        public List<Preference> Preferences { get; set; } = null!;
    }
}
