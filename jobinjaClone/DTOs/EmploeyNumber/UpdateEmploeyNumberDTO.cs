using System.ComponentModel.DataAnnotations;


    public class UpdateEmploeyNumberDTO
    {
        [Required]
        public string number { get; set; } = null!;
        [Required]
        public int id { get; set; } 
    }

