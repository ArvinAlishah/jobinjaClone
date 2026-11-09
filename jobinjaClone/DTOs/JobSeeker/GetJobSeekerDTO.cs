namespace jobinjaClone.DTOs.JobSeekers;

public class GetJobSeekerResponseDto
{
    public BasicDataDto BasicData { get; set; } = null!;
    public PersonalDto Personal { get; set; } = null!;
    public string? About { get; set; }
    public List<SkillDto> Skills { get; set; } = new();
    public List<ExperienceDto> Experiences { get; set; } = new();
    public List<EducationDto> Educations { get; set; } = new();
    public List<LanguageDto> Languages { get; set; } = new();
    public PreferenceDto? Preference { get; set; }
    public ResumeDto? Resume { get; set; }
}

public class BasicDataDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? JobTitle { get; set; }
    public string? AvatarUrl { get; set; }
}

public class PersonalDto
{
    public string? Gender { get; set; }
    public string? MarriageStatus { get; set; }
    public string? MilitaryStatus { get; set; }
    public string? Mobile { get; set; }
    public string? BirthDay { get; set; }
    public int? ProvinceId { get; set; }
    public int? ProvinceName { get; set; }
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
    public List<int> PrefersContact { get; set; } = new();
    public List<int> SeniorityLevel { get; set; } = new();
    public List<int> JobCategories { get; set; } = new();
    public List<int> Province { get; set; } = new();
    public List<int> Benefits { get; set; } = new();
    public string? ExpectedSalary { get; set; }
}

public class ResumeDto
{
    public string Url { get; set; } = null!;
    public bool IsPublic { get; set; }
}