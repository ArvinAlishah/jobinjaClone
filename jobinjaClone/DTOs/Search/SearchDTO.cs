using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Search
{
    public class SearchDTO 
    {
        [Required]
        public string search { get; set; } = null!;

        [Required]

        public bool isprovincefillter { get; set; }
        public int provincefillterid { get; set; }
        [Required]

        public bool isJobCategorize { get; set; }
        public int JobCategorizeId { get; set; }
        [Required]

        public bool isPrefersContact { get; set; }
        public int PrefersContactId { get; set; }
        [Required]

        public bool isMinimumWage { get; set; }
        public int MinimumWageId { get; set; }



    }




}
