namespace jobinjaClone.Entities
{
    public class OfficeFeild :BaseEntity
    {
        public string Name { get; set; } = null!;

        public List<Office> office { get; set; } = null!;

    }
}
