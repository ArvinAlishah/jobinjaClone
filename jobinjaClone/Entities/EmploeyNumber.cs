namespace jobinjaClone.Entities
{
    public class EmploeyNumber :BaseEntity
    {
        public string Number { get; set; } = null!;
        public List<Office> office { get; set; } = null!;

    }
}
