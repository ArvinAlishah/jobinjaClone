using jobinjaClone.Enums;

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


        public int YearExpriceId { set; get; }

        public YearExprience YearExprience { get; set; } = null!;
        public int MinmumWageId { set; get; }

        public Minimumwage Minimumwage { get; set; } = null!;


        public bool GenderImportent { set; get; }

        public GenderEnum Gnder {  set; get; }

        public bool MilitaryStatusImportent { set; get; }

        public MilitaryServiceStatusEnum military {  set; get; }


        public OfferStatusEnum offerStatus { set; get; }
        public int EmployId { get; set; }

        public Employer Employer { get; set; } = null!;


    }
}
