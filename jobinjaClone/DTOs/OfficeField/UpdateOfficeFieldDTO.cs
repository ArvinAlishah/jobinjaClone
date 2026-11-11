using System.ComponentModel.DataAnnotations;


    public class UpdateOfficeFieldDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int id { get; set; } 
    }

