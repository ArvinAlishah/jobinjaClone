namespace jobinjaClone.Entities
{
    public class YearExprience : BaseEntity
    {
        public string Year { get; set; } = null!;

        public List<Offers> offers { get; set; } = null!;
    }
}
