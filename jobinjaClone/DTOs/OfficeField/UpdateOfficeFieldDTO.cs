using System.ComponentModel.DataAnnotations;


    public class UpdateOfficeFeildDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int id { get; set; } 
    }

