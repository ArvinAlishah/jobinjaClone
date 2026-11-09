using jobinjaClone.Enums;
namespace jobinjaClone.Entities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; } = null!;
        public LanguageLevelEnum Level { get; set; }
        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; } = null!;

    }
}
