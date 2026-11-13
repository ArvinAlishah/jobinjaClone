using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Search
{
    public class SearchDTO 
    {
        [Required]
        public string search { get; set; } = null!;

        [Required]

        public int isprovincefillter { get; set; }
        public int provincefillterid { get; set; }
        [Required]

        public int isJobCategorize { get; set; }
        public int JobCategorizeId { get; set; }
        [Required]

        public int isPrefersContact { get; set; }
        public int PrefersContactId { get; set; }
        [Required]

        public int isMinimumWage { get; set; }
        public int MinimumWageId { get; set; }



    }




}
