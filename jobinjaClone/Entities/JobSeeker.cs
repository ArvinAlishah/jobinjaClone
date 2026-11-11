namespace jobinjaClone.Entities
{
    public class JobSeeker : BaseEntity
    {
        public BasicData? BasicData { get; set; }

        public Personal? Personal { get; set; }

        public string? About { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public List<Skills> Skills { get; set; } = new();

        public List<Experience> Experiences { get; set; } = new();

        public List<Education> Education { get; set; } = new();

        public ProfileImage? ProfileImages { get; set; } 

        public Preference? Preference { get; set; }

        public List<Language> Languages { get; set; } = new();

        public Resume? Resume { get; set; }
         
    }
}