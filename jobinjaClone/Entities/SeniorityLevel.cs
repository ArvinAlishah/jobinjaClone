namespace jobinjaClone.Entities
{
    public class SeniorityLevel : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<Preference> Preferences { get; set; } = null!;

    }
}
