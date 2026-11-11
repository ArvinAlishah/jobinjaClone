using jobinjaClone.Entities;
using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Office
{



    public class UpdareOfficeDTO
    {
        [Required]
        public string OfficeNameFarsi { get; set; } = null!;
        [Required]

        public string OfficeNameEnglish { get; set; } = null!;
        [Required]

        public bool HaveLogo { get; set; }

        public IFormFile? Logo { get; set; }

        [Required]

        public int ProvinceId { get; set; }
        [Required]

        public string PrivateNumber { get; set; } = null!;
        [Required]

        public string SiteUrl { get; set; } = null!;


        [Required]

        public int EmploeyNumberId { get; set; }

        [Required]

        public List<int> OfficeFeildId { get; set; } = null!;

        [Required]

        public string AboutOffice { get; set; } = null!;






    }
}