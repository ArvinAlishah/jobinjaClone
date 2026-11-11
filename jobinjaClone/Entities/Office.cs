using Microsoft.Identity.Client.NativeInterop;

namespace jobinjaClone.Entities
{
    public class Office:BaseEntity
    {
        public string OfficeNameFarsi { get; set; } = null!;

        public string OfficeNameEnglish { get; set; } = null!;

        public bool HaveLogo { get; set; }

        public string? LogoUrl { get; set; }
        
        public int ProvinceId {  get; set; }

        public Province Province { get; set; } = null!;

        public string PrivateNumber { get; set; } = null!;

        public string SiteUrl { get; set; } = null!;


    }
}
