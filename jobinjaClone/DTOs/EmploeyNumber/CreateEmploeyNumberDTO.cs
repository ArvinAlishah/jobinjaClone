using System.ComponentModel.DataAnnotations;


    public class CreateEmploeyNumberDTO
{
        [Required]
        [MaxLength(50)]
        public string number { get; set; } = null!;

    }

