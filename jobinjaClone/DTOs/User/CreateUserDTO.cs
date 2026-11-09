using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.User
{
    public class CreateUserDTO
    {

        [Required]
        [MaxLength(100)]
        public string username { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = null!;

    }
}
