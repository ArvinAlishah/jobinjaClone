using jobinjaClone.DTOs.Office;
using jobinjaClone.Enums;

namespace jobinjaClone.DTOs.Offer
{
    public class AddOfferDTO
    {
        public string title { get; set; } = null!;
        public int PrefersContact { get; set; } 


        public int Province { get; set; } 

        public int JobCategoriesId { get; set; } 

        public string ExpectedSalary { get; set; } = null!;

        public string AboutJob { get; set; } = null!;

        public string AboutOffice { get; set; } = null!;



        public int YearExprience { get; set; } 

        public int Minimumwage { get; set; } 


        public bool GenderImportent { set; get; }

        public GenderEnum Gnder { set; get; }

        public bool MilitaryStatusImportent { set; get; }

        public MilitaryServiceStatusEnum military { set; get; }


        public OfferStatusEnum offerStatus { set; get; }
    }
}
