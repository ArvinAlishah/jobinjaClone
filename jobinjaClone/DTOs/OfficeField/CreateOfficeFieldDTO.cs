using System.ComponentModel.DataAnnotations;


    public class CreateOfficeFieldDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

    }

