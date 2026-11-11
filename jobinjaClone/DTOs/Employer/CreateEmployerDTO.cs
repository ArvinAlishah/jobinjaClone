using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Employer
{
    public class CreateEmployerDTO
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]

        public string LastName { get; set; } = null!;
    }
}
