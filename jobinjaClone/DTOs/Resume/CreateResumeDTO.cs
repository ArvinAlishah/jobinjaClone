using System.ComponentModel.DataAnnotations;

namespace jobinjaClone.DTOs.Resume
{
    public class createResumeDTO
    {
        [Required]

        public bool IsPublic { get; set; }

        public  IFormFile? File { get; set; } = null!;

    }
}
