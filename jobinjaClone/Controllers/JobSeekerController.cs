using jobinjaClone.Data;
using jobinjaClone.DTOs.JobSeeker;
using jobinjaClone.DTOs.JobSeekers;
using jobinjaClone.Entities;
using jobinjaClone.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace jobinjaClone.Controllers
{
    [Authorize(Roles = "JobSeeker")]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class JobSeekerController(ApplicationDbContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var UserId = JwtHellper.GetId(User);
            var HaveJobSeeker = await context.JobSeekers.AnyAsync(x => x.UserId == UserId);
            if (HaveJobSeeker)
            {
                return BadRequest();
            }

            var JobSeeker = new JobSeeker
            {
                UserId = UserId,


            };
            context.JobSeekers.Add(JobSeeker);
            await context.SaveChangesAsync();


            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var UserId = JwtHellper.GetId(User);
            var HaveJobSeeker = await context.JobSeekers.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (HaveJobSeeker == null)
            {
                return NotFound();
            }

            List<ExperienceDto> Experiences = new List<ExperienceDto>();
            foreach (var Experience in HaveJobSeeker.Experiences)
            {
                Experiences.Add(new ExperienceDto
                {
                    CompanyName = Experience.CompanyName,
                    Description = Experience.Description,
                    EndMonth = Experience.Endtmonth.ToString(),
                    StartMonth = Experience.Startmonth.ToString(),
                    EndYear = Experience.EndYear,
                    Id = Experience.Id,
                    RollName = Experience.RollName,
                    StartYear = Experience.StartYear,
                    StillWorking = Experience.StillWorking

                });
            }

            List<EducationDto> Educations = new List<EducationDto>();
            foreach (var Educat in HaveJobSeeker.Education)
            {
                Educations.Add(new EducationDto
                {
                    Degree = Educat.Degree.ToString(),
                    Description = Educat.Description,
                    EndYear = Educat.Description,
                    FieldName = Educat.FieldName,
                    Id = Educat.Id,
                    InstituteName = Educat.InstituteName,
                    StartYear = Educat.StartYear,
                    StillEducatucating = Educat.StillEducatucating

                });
            }
            List<LanguageDto> Language = new List<LanguageDto>();
            foreach (var Languages in HaveJobSeeker.Languages)
            {
                Language.Add(new LanguageDto
                {
                    Id = Languages.Id,
                    Level = Languages.Level.ToString(),
                    Name = Languages.Name
                });
            }
            List<SkillDto> skillss = new List<SkillDto>();
            foreach (var skill in HaveJobSeeker.Skills)
            {
                skillss.Add(new SkillDto
                {
                    Id = skill.Id,
                    Name = skill.Name

                });
            }

            var JobSeeker = await context.JobSeekers.Where(x => x.UserId == UserId)
                                    .Select(x => new GetJobSeekerResponseDto
                                    {
                                        About = x.About,
                                        BasicData = new()
                                        {
                                            FirstName = x.BasicData.FirstName,
                                            JobTitle = x.BasicData.JobTitel,
                                            LastName = x.BasicData.LastName,
                                            WorkingStatus = x.BasicData.WorkingStatus.ToString()

                                        },
                                        Personal = new()
                                        {
                                            BirthDay = x.Personal.BirthDay,
                                            Gender = x.Personal.Gender.ToString(),
                                            MarriageStatus = x.Personal.MarriageStatus.ToString(),
                                            MilitaryStatus = x.Personal.MiliteryStatus.ToString(),
                                            Mobile = x.Personal.Mobile,
                                            ProvinceName = x.Personal.Province.Name




                                        },
                                        Resume = new()
                                        {
                                            IsPublic = x.Resume.IsPublic,
                                            Url = x.Resume.Url
                                        },
                                        Experiences = Experiences,
                                        Educations = Educations,
                                        Languages = Language,
                                        Skills = skillss,
                                        Preference = new()
                                        {
                                            Benefits = x.Preference.Benefits.Select(b => b.Name).ToList(),
                                            SeniorityLevel = x.Preference.Benefits.Select(b => b.Name).ToList(),
                                            ExpectedSalary = x.Preference.ExpectedSalary,
                                            JobCategories = x.Preference.JobCategories.Select(b => b.Name).ToList(),
                                            PrefersContact = x.Preference.PrefersContact.Select(b => b.Name).ToList(),
                                            Province = x.Preference.Province.Select(b => b.Name).ToList()
                                        }



                                    }).FirstOrDefaultAsync();



            return Ok(JobSeeker);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonal(UpdatePersonalDTO request)
        {
            var userId = JwtHellper.GetId(User);

            var jobSeeker = await context.JobSeekers
                .Include(x => x.Personal)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (jobSeeker == null)
                return NotFound();

            var provinceExists = await context.Provinces
                .AnyAsync(x => x.Id == request.ProvinceId);

            if (!provinceExists)
                return BadRequest("استان وجود ندارد");

            if (jobSeeker.Personal == null)
            {
                jobSeeker.Personal = new Personal();
            }

            jobSeeker.Personal.BirthDay = request.BirthDay;
            jobSeeker.Personal.Gender = request.Gender;
            jobSeeker.Personal.MarriageStatus = request.MarriageStatus;
            jobSeeker.Personal.MiliteryStatus = request.MiliteryStatus;
            jobSeeker.Personal.Mobile = request.Mobile;
            jobSeeker.Personal.ProvinceId = request.ProvinceId;

            await context.SaveChangesAsync();

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBasicData(UpdateBasicDataDTO request)
        {
            var userId = JwtHellper.GetId(User);

            var jobSeeker = await context.JobSeekers
                .Include(x => x.BasicData)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (jobSeeker == null)
                return NotFound();

            if (jobSeeker.BasicData == null)
            {
                jobSeeker.BasicData = new BasicData
                {
                    JobSeekerId = jobSeeker.Id
                };
            }

            jobSeeker.BasicData.FirstName = request.FirstName;
            jobSeeker.BasicData.LastName = request.LastName;
            jobSeeker.BasicData.JobTitel = request.JobTitle;
            jobSeeker.BasicData.WorkingStatus = request.WorkingStatus;

            await context.SaveChangesAsync();

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePerfrence(UpdatePerfrenceDataDTO request)
        {
            var userId = JwtHellper.GetId(User);

            var jobSeeker = await context.JobSeekers
                .Include(x => x.Preference)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (jobSeeker == null)
                return NotFound();

            if (jobSeeker.Preference == null)
            {
                jobSeeker.Preference = new Preference
                {
                    JobSeekerId = jobSeeker.Id
                };
            }

            foreach (var provinceid in request.ProvinceId)
            {
                var  TempProvince = await context.Provinces.FirstOrDefaultAsync(x => x.Id == provinceid);
                 if (TempProvince == null)
                {
                    return NotFound("استان مورد نظر ثبت شده نمیباشد");
                }
                jobSeeker.Preference.Province.Add(TempProvince);

            }
            foreach (var benefitsid in request.BenefitsId)
            {
                var Tempbenefits = await context.Benefits.FirstOrDefaultAsync(x => x.Id == benefitsid);
                if (Tempbenefits == null)
                {
                    return NotFound("مزایا مورد نظر یافت نشد");
                }
                jobSeeker.Preference.Benefits.Add(Tempbenefits);

            }

            foreach (var jobCategoriesId in request.JobCategoriesId)
            {
                var TempjobCategories = await context.JobCategories.FirstOrDefaultAsync(x => x.Id == jobCategoriesId);
                if (TempjobCategories == null)
                {
                    return NotFound("شغل مورد نظر یافت نشد ");
                }
                jobSeeker.Preference.JobCategories.Add(TempjobCategories);

            }
            foreach (var prefersContactId in request.PrefersContactId)
            {
                var TempprefersContact = await context.PrefersContacts.FirstOrDefaultAsync(x => x.Id == prefersContactId);
                if (TempprefersContact == null)
                {
                    return NotFound("قرارداد مورد نظر یافت نشد  ");
                }
                jobSeeker.Preference.PrefersContact.Add(TempprefersContact);

            }

            foreach (var seniorityLevelId in request.SeniorityLevelId)
            {
                var TempSeniorityLevels = await context.SeniorityLevels.FirstOrDefaultAsync(x => x.Id == seniorityLevelId);
                if (TempSeniorityLevels == null)
                {
                    return NotFound("مهارت مورد نظر یافت نشده است");
                }
                jobSeeker.Preference.SeniorityLevel.Add(TempSeniorityLevels);

            }
       request.ExpectedSalary = request.ExpectedSalary;
        
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
