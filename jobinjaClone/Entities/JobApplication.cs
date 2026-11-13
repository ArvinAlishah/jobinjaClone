namespace jobinjaClone.Entities
{
    public class JobApplication : BaseEntity
    {
        public Offers offers { get; set; } = null!;

        public List<Resume>? Resume { get; set; }


        public ResumeFolder ResumeFolder { get; set; } = null!;

        public int ResumeFolderId { get; set; }
    }
}
