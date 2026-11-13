namespace jobinjaClone.DTOs.Search
{
    public class SearachResultDTO
    {
        public List <OffersDTO> offers {  get; set; }

        public int pageNumber { get; set; }

        public int SizePage { get; set; }

    }

    public class OffersDTO
    {
        int id { get; set; }

        public string JobTitle { get; set; } = null!;

        public string Companyname { get; set; } = null!;

        public string ProvinceName { get; set; } = null!;

        public string prefrancecintract { get; set; } = null!;

        public string minimumWage { get; set; } = null!;

    }
}
