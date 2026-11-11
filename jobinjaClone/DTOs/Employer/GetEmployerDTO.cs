using jobinjaClone.Entities;

namespace jobinjaClone.DTOs.Employer
{
    public class GetEmployerDto
    {
        public int id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;


    }

}