using jobinjaClone.Entities;

namespace jobinjaClone.DTOs.JobSeekers;

public class GetJobSeekerResponseDto
{
    public BasicDataDto? BasicData { get; set; }
    public PersonalDto? Personal { get; set; }

    public string? About { get; set; }

    public List<SkillDto> Skills { get; set; } = new();
    public List<ExperienceDto> Experiences { get; set; } = new();
    public List<EducationDto> Educations { get; set; } = new();
    public List<LanguageDto> Languages { get; set; } = new();

    public PreferenceDto? Preference { get; set; }
    public ResumeDto? Resume { get; set; }
    public ProfileImageDTO? ProfileImage { get; set; }

}

public class BasicDataDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? WorkingStatus { get; set; }
    public string? JobTitle { get; set; }
}

public class PersonalDto
{
    public string? Gender { get; set; }
    public string? MarriageStatus { get; set; }
    public string? MilitaryStatus { get; set; }
    public string? Mobile { get; set; }
    public string? BirthDay { get; set; }
    public string? ProvinceName { get; set; }
}

public class SkillDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class ExperienceDto
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string RollName { get; set; } = null!;
    public string? Description { get; set; }
    public string StartMonth { get; set; } = null!;
    public string StartYear { get; set; } = null!;
    public string? EndMonth { get; set; }
    public string? EndYear { get; set; }
    public bool StillWorking { get; set; }
}

public class EducationDto
{
    public int Id { get; set; }
    public string FieldName { get; set; } = null!;
    public string InstituteName { get; set; } = null!;
    public string Degree { get; set; } = null!;
    public string StartYear { get; set; } = null!;
    public string? EndYear { get; set; }
    public string? Description { get; set; }
    public bool StillEducatucating { get; set; }
}

public class LanguageDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Level { get; set; } = null!;
}

public class PreferenceDto
{
    public List<string> PrefersContact { get; set; } = new();
    public List<string> SeniorityLevel { get; set; } = new();
    public List<string> JobCategories { get; set; } = new();
    public List<string> Province { get; set; } = new();
    public List<string> Benefits { get; set; } = new();
    public string? ExpectedSalary { get; set; }
}

public class ResumeDto
{
    public string? Url { get; set; }
    public bool? IsPublic { get; set; }

}
    public class ProfileImageDTO
    {
        public string? Url { get; set; }
    }