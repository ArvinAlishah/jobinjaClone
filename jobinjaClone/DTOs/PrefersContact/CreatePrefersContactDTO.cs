using System.ComponentModel.DataAnnotations;


    public class CreatePrefersContactDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

    }

