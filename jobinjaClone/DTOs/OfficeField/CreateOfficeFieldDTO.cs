using System.ComponentModel.DataAnnotations;


    public class CreateOfficeDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

    }

