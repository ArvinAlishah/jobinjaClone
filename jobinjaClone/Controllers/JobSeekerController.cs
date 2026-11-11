using jobinjaClone.Data;
using jobinjaClone.DTOs.About;
using jobinjaClone.DTOs.Education;
using jobinjaClone.DTOs.Exprince;
using jobinjaClone.DTOs.JobSeeker;
using jobinjaClone.DTOs.JobSeekers;
using jobinjaClone.DTOs.Languge;
using jobinjaClone.DTOs.Resume;
using jobinjaClone.DTOs.Skill;
using jobinjaClone.Entities;
using jobinjaClone.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


namespace jobinjaClone.Controllers
{
    [Authorize(Roles = "JobSeeker")]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class JobSeekerController(ApplicationDbContext context, IWebHostEnvironment environment) : ControllerBase
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

          


            var JobSeeker = await context.JobSeekers.Where(x => x.UserId == UserId)
                                    .Select( x => new GetJobSeekerResponseDto
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
                                       ProfileImage = new()
                                        {
                                            Url = x.ProfileImages.Url
                                        },
                                        Experiences = x.Experiences.Select(Experience => new ExperienceDto
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
                                        }).ToList(),
                                        Educations = x.Education.Select(Educat => new EducationDto
                                        {
                                            Degree = Educat.Degree.ToString(),
                                            Description = Educat.Description,
                                            EndYear = Educat.Description,
                                            FieldName = Educat.FieldName,
                                            Id = Educat.Id,
                                            InstituteName = Educat.InstituteName,
                                            StartYear = Educat.StartYear,
                                            StillEducatucating = Educat.StillEducatucating
                                        }).ToList(),
                                        Languages = x.Languages.Select(Language => new LanguageDto
                                        {
                                            Id = Language.Id,
                                            Name = Language.Name,
                                            Level = Language.Level.ToString()
                                            
                                        }).ToList(),
                                        Skills = x.Skills.Select(skill => new SkillDto
                                        {
                                            Id = skill.Id,
                                            Name = skill.Name
                                        }).ToList()
                                        ,
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
         .ThenInclude(x => x.Province)
     .Include(x => x.Preference)
         .ThenInclude(x => x.Benefits)
     .Include(x => x.Preference)
         .ThenInclude(x => x.JobCategories)
     .Include(x => x.Preference)
         .ThenInclude(x => x.PrefersContact)
     .Include(x => x.Preference)
         .ThenInclude(x => x.SeniorityLevel)
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
            if (jobSeeker.Preference.Province == null)
            {
                jobSeeker.Preference.Province = new List<Province>();
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

            if (jobSeeker.Preference.Benefits == null)
            {
                jobSeeker.Preference.Benefits = new List<Benefits>();
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
            if (jobSeeker.Preference.JobCategories == null)
            {
                jobSeeker.Preference.JobCategories = new List<JobCategories>();
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

            if (jobSeeker.Preference.PrefersContact == null)
            {
                jobSeeker.Preference.PrefersContact = new List<PrefersContact>();
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
            if (jobSeeker.Preference.SeniorityLevel == null)
            {
                jobSeeker.Preference.SeniorityLevel = new List<SeniorityLevel>();
            }
            foreach (var seniorityLevelId in request.SeniorityLevelId)
            {
                var TempSeniorityLevels = await context.SeniorityLevels.FirstOrDefaultAsync(x => x.Id == seniorityLevelId);
                if (TempSeniorityLevels == null)
                {
                    return NotFound("ارشدیت مورد نظر یافت نشده است");
                }
                jobSeeker.Preference.SeniorityLevel.Add(TempSeniorityLevels);

            }
       jobSeeker.Preference.ExpectedSalary = request.ExpectedSalary;
        
            await context.SaveChangesAsync();

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> AddSkill(AddSkillDTO request)
        {
            var userId = JwtHellper.GetId(User);

            var jobSeeker = await context.JobSeekers
                .Include(x => x.Skills)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (jobSeeker == null)
            {
                return NotFound();
            }
            var isPresent = jobSeeker.Skills.Any(x => x.Name == request.Name);

            if (isPresent)
            {
                return BadRequest("مهارت از قبل ثبت شده است");
            }
            var skill = new Skills
            {
                JobSeekersId = jobSeeker.Id,
                Name = request.Name
            };

            jobSeeker.Skills.Add(skill);

            await context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSkill(int skillId)
        {
            var userId = JwtHellper.GetId(User);

            var jobSeeker = await context.JobSeekers
                .Include(x => x.Skills)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (jobSeeker == null)
            {
                return NotFound();
            }
            var skill = jobSeeker.Skills
                .FirstOrDefault(x => x.Id == skillId);

            if (skill == null)
            {
                return NotFound("مهارت پیدا نشد");
            }
            jobSeeker.Skills.Remove(skill);

            await context.SaveChangesAsync();

            return Ok();
        }



        [HttpPost]
        public async Task<IActionResult> AddExprience(AddExprienceDTo request)
        {
            var userId = JwtHellper.GetId(User);

            var jobSeeker = await context.JobSeekers
                .Include(x => x.Experiences)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (jobSeeker == null)
            {
                return NotFound();
            }
        
            var experience = new Experience
            {
               CompanyName  = request.CompanyName,
               JobSeekerId = jobSeeker.Id,
               RollName = request.RollName,
               Startmonth = request.StartMonth,
               StartYear = request.StartYear,
               StillWorking = request.StillWorking,
               DescriptionIsOn = request.DescriptionIson,
               

               
            };

            if (request.DescriptionIson)
            {
                experience.Description = request.Description;

            }
            if (!request.StillWorking)
            {
                experience.EndYear = request.EndYear;
                experience.Endtmonth = request.EndMonth;


            }
            jobSeeker.Experiences.Add(experience);

            await context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteExprience(int ExperiencesId)
        {
            var userId = JwtHellper.GetId(User);

            var jobSeeker = await context.JobSeekers
                .Include(x => x.Experiences)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (jobSeeker == null)
            {
                return NotFound();
            }
            var experiences = jobSeeker.Experiences
                .FirstOrDefault(x => x.Id == ExperiencesId);

            if (experiences == null)
            {
                return NotFound("مهارت پیدا نشد");
            }
            jobSeeker.Experiences.Remove(experiences);

            await context.SaveChangesAsync();

            return Ok();
        }
    
     [HttpPost]
        public async Task<IActionResult> AddEducation(AddEducationDTO request)
        {
            var userId = JwtHellper.GetId(User);

            var jobSeeker = await context.JobSeekers
                .Include(x => x.Education)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (jobSeeker == null)
            {
                return NotFound();
            }

            var education = new Education
            {
                Degree = request.Degree,
                FieldName = request.FieldName,
                InstituteName= request.InstituteName,
                StartYear = request.StartYear,
                StillEducatucating = request.StillEducatucating,
                Description = request.Description,
                JobSeekerId = jobSeeker.Id,
                

            };


            if (!request.StillEducatucating)
            {
                education.EndYear = request.EndYear;


            }
            jobSeeker.Education.Add(education);

            await context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEducation(int EducationId)
        {
            var userId = JwtHellper.GetId(User);

            var jobSeeker = await context.JobSeekers
                .Include(x => x.Education)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (jobSeeker == null)
            {
                return NotFound();
            }
            var education = jobSeeker.Education
                .FirstOrDefault(x => x.Id == EducationId);

            if (education == null)
            {
                return NotFound("مهارت پیدا نشد");
            }
            jobSeeker.Education.Remove(education);

            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddLanguge(CreateLangugeDTO request)
        {
            var userId = JwtHellper.GetId(User);

            var jobSeeker = await context.JobSeekers
                .Include(x => x.Languages)
                .FirstOrDefaultAsync(x => x.UserId == userId);
            var isperessent = await context.Languages
               .AnyAsync(x => x.Name == request.Name);

            if (isperessent)
            {
                return BadRequest("از قبل موجود است");
            }
            if (jobSeeker == null)
            {
                return NotFound();
            }

            var language = new Language
            {
               JobSeekerId = jobSeeker.Id,
               Level = request.Level,
               Name = request.Name,


            };


        
            jobSeeker.Languages.Add(language);

            await context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Deletelanguage(int LanguageId)
        {
            var userId = JwtHellper.GetId(User);

            var jobSeeker = await context.JobSeekers
                .Include(x => x.Languages)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (jobSeeker == null)
            {
                return NotFound();
            }
            var language = jobSeeker.Languages
                .FirstOrDefault(x => x.Id == LanguageId);

            if (language == null)
            {
                return NotFound("مهارت پیدا نشد");
            }
            jobSeeker.Languages.Remove(language);

            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDTO request)
        {
            var UserId = JwtHellper.GetId(User);
            var jobseeker = await context.JobSeekers.FirstOrDefaultAsync(x => x.UserId == UserId);

            if (jobseeker == null)
            {
                return NotFound("کارجو وجود ندارد");
            }
            jobseeker.About = request.About;

            await context.SaveChangesAsync();
            return Ok(request);
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteAbout()
        {
            var UserId = JwtHellper.GetId(User);
            var jobseeker = await context.JobSeekers.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (jobseeker == null)
            {
                return NotFound("کارجو وجود ندارد");
            }
            jobseeker.About = null;

            await context.SaveChangesAsync();
            return Ok();
        }



        [HttpPost]
        public async Task<IActionResult> AddResume([FromForm] createResumeDTO request)
        {
            var UserId = JwtHellper.GetId(User);
            var jobseeker = await context.JobSeekers.FirstOrDefaultAsync(x => x.UserId == UserId);

            if (jobseeker == null)
            {
                return NotFound("کارجو وجود ندارد");
            }
            var uploadFolder = Path.Combine(environment.WebRootPath, "Resume");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            if (request.File == null || request.File.Length == 0)
            {
                return BadRequest("فایلی ارسال نشده است.");
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";

            var filePath = Path.Combine(uploadFolder, fileName);
            await using var stream = new FileStream(filePath, FileMode.Create);
            await request.File.CopyToAsync(stream);


            var resume = new Resume
            {
                Url = $"Resume/{fileName}",
                JobSeekerId = jobseeker.Id

            };

            context.Resumes.Add(resume);
            await context.SaveChangesAsync();


            return Created($"api/sliders/{resume.Id}", new
            {
                Id = resume.Id
            });
        }
        
        [HttpDelete]

        public async Task<IActionResult> DeleteResume()
        {
            var UserId = JwtHellper.GetId(User);
            var jobseeker = await context.JobSeekers.
                Include(x=>x.Resume)
                .FirstOrDefaultAsync(x => x.UserId == UserId);
            if (jobseeker == null)
            {
                return NotFound("کارجو وجود ندارد");
            }
            var resume = await context.Resumes.FirstOrDefaultAsync(x => x.Id == jobseeker.Resume.Id);
                if(resume == null)
            {
                return NotFound();
            }
            context.Remove(resume);
            await context.SaveChangesAsync();

            var normalazedresumename = resume.Url.Replace('/', Path.DirectorySeparatorChar);
            var ResumePath = Path.Combine(environment.WebRootPath, normalazedresumename);

            if (System.IO.File.Exists(ResumePath))
            {
                System.IO.File.Delete(ResumePath);
            }
         
            return Ok();
        }




        [HttpPost]
        public async Task<IActionResult> AddProfileImage([FromForm] CreateProfileImageDTO request)
        {
            var UserId = JwtHellper.GetId(User);
            var jobseeker = await context.JobSeekers
                .Include(x=>x.ProfileImages)
                .FirstOrDefaultAsync(x => x.UserId == UserId);

            if (jobseeker == null)
            {
                return NotFound("کارجو وجود ندارد");
            }
            if (jobseeker.ProfileImages.Url != null)
            {
                return BadRequest("کارجو وجود ندارد");
            }
            var uploadFolder = Path.Combine(environment.WebRootPath, "Profile");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            if (request.File == null || request.File.Length == 0)
            {
                return BadRequest("فایلی ارسال نشده است.");
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";

            var filePath = Path.Combine(uploadFolder, fileName);
            await using var stream = new FileStream(filePath, FileMode.Create);
            await request.File.CopyToAsync(stream);


            var resume = new Resume
            {
                Url = $"Profile/{fileName}",
                JobSeekerId = jobseeker.Id

            };

            context.Resumes.Add(resume);
            await context.SaveChangesAsync();


            return Created($"api/Profile/{resume.Id}", new
            {
                Id = resume.Id
            });
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteProfileImage()
        {
            var UserId = JwtHellper.GetId(User);
            var jobseeker = await context.JobSeekers.
                Include(x => x.ProfileImages)
                .FirstOrDefaultAsync(x => x.UserId == UserId);
            if (jobseeker == null)
            {
                return NotFound("کارجو وجود ندارد");
            }
            var resume = await context.Resumes.FirstOrDefaultAsync(x => x.Id == jobseeker.ProfileImages.Id);
            if (resume == null)
            {
                return NotFound();
            }
            context.Remove(resume);
            await context.SaveChangesAsync();

            var normalazedresname = resume.Url.Replace('/', Path.DirectorySeparatorChar);
            var ProfilePath = Path.Combine(environment.WebRootPath, normalazedresname);

            if (System.IO.File.Exists(ProfilePath))
            {
                System.IO.File.Delete(ProfilePath);
            }

            return Ok();
        }











    }


}
