using jobinjaClone.DTOs.Office;
using jobinjaClone.Entities;
using jobinjaClone.Enums;

namespace jobinjaClone.DTOs.Offer
{
    public class GetOfferDTO
    {
        public string title { get; set; } = null!;
        public PrefersContactDTO PrefersContact { get; set; } = null!;


        public ProvinceDTO Province { get; set; } = null!;


        public JobCategoriesDTO JobCategories { get; set; } = null!;

        public string ExpectedSalary { get; set; } = null!;

        public string AboutJob { get; set; } = null!;

        public string AboutOffice { get; set; } = null!;



        public YearExprienceDTO YearExprience { get; set; } = null!;

        public MinimumwageDTO Minimumwage { get; set; } = null!;


        public bool GenderImportent { set; get; }

        public GenderEnum Gnder { set; get; }

        public bool MilitaryStatusImportent { set; get; }

        public MilitaryServiceStatusEnum military { set; get; }


        public OfferStatusEnum offerStatus { set; get; }

    }
    public class JobCategoriesDTO
    {
        public string Name { get; set; } = null!;

    }


    public class YearExprienceDTO
    {
        public string Year { get; set; } = null!;

    }
    public class PrefersContactDTO
    {
        public string Name { get; set; } = null!;

    }
    public class MinimumwageDTO
    {
        public string Mnimum { get; set; } = null!;

    }

}

