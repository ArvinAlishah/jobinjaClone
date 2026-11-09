namespace jobinjaClone.Entities
{
    public class Province : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<Personal> Personal { get; set; } = null!;
        public List<Preference> Preferences { get; set; } = null!;
    }
}
