using jobinjaClone.Data;
using jobinjaClone.DTOs.Office;
using jobinjaClone.Entities;
using jobinjaClone.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace jobinjaClone.Controllers
{
    [Authorize(Roles = "Employer")]
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController(ApplicationDbContext context , IWebHostEnvironment environment) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int UserId = JwtHellper.GetId(User);
            var Office = await context.Office.
                  Include(x => x.Employer)
                  .Where(x => x.Employer.UserId == UserId)
                  .AnyAsync();

            if(!Office)
            {
                return NotFound("شرکت پیدا نشد");
            }

            var tempoffice = await context.Office.
                  Include(x => x.Employer)
                  .Where(x => x.Employer.UserId == UserId)
                  .Select( x => new GetOfficeDTO
                  {
                      AboutOffice = x.AboutOffice,
                      LogoUrl = x.LogoUrl,
                      OfficeNameEnglish = x.OfficeNameEnglish,
                      OfficeNameFarsi = x.OfficeNameFarsi,
                      HaveLogo = x.HaveLogo,
                      PrivateNumber = x.PrivateNumber,
                      SiteUrl = x.SiteUrl,
                      Province = new ProvinceDTO()
                      {
                          Name =x.Province.Name
                      },
                      EmployerId = x.EmployerId,
                      EmploeyNumber = new EmploeyNumberDTO()
                      {
                          Number = x.EmploeyNumber.Number
                      },
                      OfficeFeild = x.OfficeFeild.Select(x=> new OfficeFeildDTO
                      {
                          Name =x.Name
                      }).ToList()

                      
                  }).FirstOrDefaultAsync();






            return Ok(tempoffice);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]UpdareOfficeDTO request)
        {
            int UserId = JwtHellper.GetId(User);

            var Office = await context.Office.Include(x=> x.Employer)
                                   .Include(x=>x.OfficeFeild)
                                  .Where(x => x.Employer.UserId == UserId)
                                  .FirstOrDefaultAsync();
            var employer = await context.Employer.FirstOrDefaultAsync(x=>x.UserId == UserId);
            if(employer == null)
            {
                return NotFound("کارفرما وجود ندارد");
            }
            if (Office == null)
            {
                Office = new()
                {
                    EmployerId = employer.Id
                };
            }

            Office.HaveLogo = request.HaveLogo;
            if (Office.HaveLogo) {
                if(Office.LogoUrl != null)
                {
                    var normalazedlogoUrl = Office.LogoUrl.Replace('/', Path.DirectorySeparatorChar);
                    var normalazedlogoPath = Path.Combine(environment.WebRootPath, normalazedlogoUrl);

                    if (System.IO.File.Exists(normalazedlogoPath))
                    {
                        System.IO.File.Delete(normalazedlogoPath);
                    }
                }

                var uploadFolder = Path.Combine(environment.WebRootPath, "Logo");

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.Logo.FileName)}";

                var filePath = Path.Combine(uploadFolder, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await request.Logo.CopyToAsync(stream);
                Office.LogoUrl = $"Logo/{fileName}";


            }
            if(Office.OfficeFeild == null)
            {
                Office.OfficeFeild = new List<OfficeFeild>();
            }
            Office.OfficeFeild.Clear();
            foreach(var OfficeFeildId in request.OfficeFeildId)
            {
                var officeFeild = await context.OfficeFeild.Where(x=>x.Id  == OfficeFeildId)
                    .FirstOrDefaultAsync();

                if(officeFeild == null)
                {
                    return NotFound("فیلد مورد نظر وجود ندارد");

                }
                Office.OfficeFeild.Add(officeFeild);

            }
            Office.EmployNumberId = request.EmploeyNumberId;
            Office.AboutOffice = request.AboutOffice;
            Office.ProvinceId = request.ProvinceId;
            Office.SiteUrl = request.SiteUrl;
            Office.OfficeNameFarsi = request.OfficeNameFarsi;
            Office.PrivateNumber =request.PrivateNumber;
            Office.OfficeNameEnglish = request.OfficeNameEnglish;
            if (Office.Id == 0)                 
            {
                context.Office.Add(Office);
            }
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
