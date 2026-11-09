namespace jobinjaClone.Entities
{
    public class PrefersContact : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<Preference> Preferences { get; set; } = null!;

    }
}
