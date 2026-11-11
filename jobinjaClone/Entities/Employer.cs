namespace jobinjaClone.Entities
{
    public class Employer:BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public Office Office {  get; set; }

        public List<Offers> Offers { get; set; }
    }
}
