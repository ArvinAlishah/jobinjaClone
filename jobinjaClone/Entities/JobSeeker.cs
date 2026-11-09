using jobinjaClone.Enums;
using Microsoft.AspNetCore.SignalR;

namespace jobinjaClone.Entities
{
    public class JobSeeker : BaseEntity
    {

        public BasicData BasicData {  get; set; } = null!;

        public Personal Personal { get; set; } = null!;

        public string About { get; set; } = null!;

        public  int UserId { get; set; }
        public User User { set; get; } = null!;
        
        public List<Skills> Skills { get; set; } = null!;

        public List<Experience> Experiences { get; set; } = null!;

        public List<Education> Education { get; set; } = null!;
        public List<ProfileImage> ProfileImages { get; set; } = null!;


        public Preference Preference { get; set; } = null!;


        public List<Language> Languages { get; set; } = null!;

        public Resume Resume { get; set; } = null!;


    }
}
