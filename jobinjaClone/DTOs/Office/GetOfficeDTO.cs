using jobinjaClone.Entities;

namespace jobinjaClone.DTOs.Office
{



    public class OfficeDTO
    {
        public string OfficeNameFarsi { get; set; } = null!;

        public string OfficeNameEnglish { get; set; } = null!;

        public bool HaveLogo { get; set; }

        public string? LogoUrl { get; set; }


        public ProvinceDTO Province { get; set; } = null!;

        public string PrivateNumber { get; set; } = null!;

        public string SiteUrl { get; set; } = null!;



        public EmploeyNumberDTO EmploeyNumber { get; set; } = null!;


        public List<OfficeFeildDTO> OfficeFeild { get; set; } = null!;


        public int EmployerId { get; set; }




        public string AboutOffice { get; set; } = null!;






    }
    public class ProvinceDTO
    {
        public string Name { get; set; } = null!;
 


    }
    public class EmploeyNumberDTO
    {
        public string Number { get; set; } = null!;

    }
    public class OfficeFeildDTO
    {
        public string Name { get; set; } = null!;

    }
}


