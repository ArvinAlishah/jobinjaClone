namespace jobinjaClone.Entities
{
    public class Offers : BaseEntity
    {
        public string title { get; set; } = null!; 
        public int PrefersContactId { get; set; }
        public PrefersContact PrefersContact { get; set; } = null!;

        public int ProvinceId { get; set; }

        public Province Province  { get; set; } = null!;

        public int JobCategoriesId { get; set; } 

        public JobCategories JobCategories { get; set; } = null!;

        public string ExpectedSalary { get; set; } = null!;

        public string AboutJob { get; set; } = null!;

        public string AboutOffice { get; set; } = null!;

        public int EmployId { get; set; }

        public Employer Employer { get; set; } = null!;


    }
}
