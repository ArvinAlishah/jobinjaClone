using jobinjaClone.Enums;
namespace jobinjaClone.Entities
{
    public class Education : BaseEntity
    {
        public string FieldName { get; set; } = null!;
        public string InstituteName { get; set; } = null!;
        public EducationDegreeEnum Degree { set; get; }
        public string StartYear { get; set; } = null!;
        public string EndYear { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool StillEducatucating { get; set; }

        public int JobSeekerId {  get; set; }

        public JobSeeker JobSeeker { get; set; } = null!;



    }
}
