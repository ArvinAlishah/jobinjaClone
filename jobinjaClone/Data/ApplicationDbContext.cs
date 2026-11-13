using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace jobinjaClone.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<JobSeeker> JobSeekers { get; set; }
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Skills> Skills { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<JobCategories> JobCategories { get; set; }
    public DbSet<Benefits> Benefits { get; set; }
    public DbSet<SeniorityLevel> SeniorityLevels { get; set; }
    public DbSet<PrefersContact> PrefersContacts { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<UserRole> UserRole { get; set; }

    public DbSet<Role> Role { get; set; }

    public DbSet<ProfileImage> ProfileImage { get; set; }

    public DbSet<Personal> Personal { get; set; }

    public DbSet<BasicData> BasicData { get; set; }
    public DbSet<Office> Office { get; set; }
    public DbSet<Offers> Offers { get; set; }

    public DbSet<OfficeFeild> OfficeFeild { get; set; }

    public DbSet<EmploeyNumber> EmploeyNumber { get; set; }
    public DbSet<Employer> Employer { get; set; }
    public DbSet<YearExprience> YearExprience { get; set; }
    public DbSet<Minimumwage> Minimumwage { get; set; }

    public DbSet<ResumeFolder> ResumeFolder { get; set; }
    public DbSet<JobApplication> JobApplication { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}