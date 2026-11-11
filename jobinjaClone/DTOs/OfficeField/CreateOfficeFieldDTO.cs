using System.ComponentModel.DataAnnotations;


    public class CreateOfficeFeildDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

    }

