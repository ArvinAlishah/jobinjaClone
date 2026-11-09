using jobinjaClone.Enums;
namespace jobinjaClone.Entities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; } = null!;
        public LevelEnum Level { get; set; }

        public int JobseekerId { get; set; }
        public JobSeeker JobSeeker { get; set; } = null!;

    }
}
