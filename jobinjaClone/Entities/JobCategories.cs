namespace jobinjaClone.Entities
{
    public class JobCategories : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<Preference> Preferences { get; set; } = null!;

    }
}
