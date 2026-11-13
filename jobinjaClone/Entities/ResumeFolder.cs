namespace jobinjaClone.Entities
{
    public class ResumeFolder : BaseEntity
    {

        public int EmployerId{ set; get; } 

        public Employer Employer { set; get; } = null!;

        public List<JobApplication>? JobApplication { get; set; }
    }
}
