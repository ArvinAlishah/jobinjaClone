using jobinjaClone.Enums;
namespace jobinjaClone.Entities
{
    public class Preference : BaseEntity
    {
        public List<PrefersContact> PrefersContact { get; set; } = null!;
        public List<SeniorityLevel> SeniorityLevel { get; set; } = null!;
        public List<JobCategories> JobCategories { get; set; } = null!;
        public string ExpectedSalary { get; set; } = null!;
        public List<Province> Province { get; set; } = null!;
        public List<Benefits> Benefits { get; set; } = null!;
        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; } = null!;


    }
}
