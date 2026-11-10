using System.ComponentModel.DataAnnotations;


    public class UpdatePrefersContactDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int id { get; set; } 
    }
