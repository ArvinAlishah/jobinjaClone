using jobinjaClone.Entities;

namespace jobinjaClone.Controllers
{
    public class Minimumwage : BaseEntity
    {
        public string minimum { get; set; } = null!;

        public List<Offers> Offers { get; set; } = null!;
    }
}
