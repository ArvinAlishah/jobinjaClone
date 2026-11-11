using jobinjaClone.Data;
using jobinjaClone.DTOs.Province;
using jobinjaClone.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jobinjaClone.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SeniorityLevelController(ApplicationDbContext context) : ControllerBase
    {
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> CreateSeniorityLevel(CreateSeniorityLevelDTO requst)
        {
            var IsPressent =    await context.SeniorityLevels.AnyAsync(x => x.Name == requst.Name);
            if (IsPressent)
            {
                 return BadRequest("این سطح ارشدیت قبلاً ثبت شده است");
            }

            var seniorityLevel = new SeniorityLevel
            {
                Name = requst.Name
            };
            context.SeniorityLevels.Add(seniorityLevel);
            await context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "Admin,JobSeeker")]
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var seniorityLevel = await context.SeniorityLevels
       .Select(x => new GetSeniorityLevelDTO
       {
           id = x.Id,
           Name = x.Name
       })
       .ToListAsync();

            return Ok(seniorityLevel);

        }
        [Authorize(Roles = "Admin")]

        [HttpPut]
        public async Task<IActionResult> UpdateSeniorityLevel(UpdateSeniorityLevelDTO requst)
        {
            var seniorityLevel = await context.SeniorityLevels.FirstOrDefaultAsync(x => x.Id == requst.id);
            if (seniorityLevel == null)
            {
                return BadRequest("این سطح ارشدیت قبلاً ثبت نشده است");
            }
            seniorityLevel.Name = requst.Name;
            await context.SaveChangesAsync();

            return Ok();
        }
        [Authorize(Roles = "Admin")]

        [HttpDelete]
        public async Task<IActionResult> DeleteSeniorityLevel(int id)
        {
            var seniorityLevel = await context.SeniorityLevels.FirstOrDefaultAsync(x => x.Id == id);
            if (seniorityLevel == null)
            {
                return BadRequest("این سطح ارشدیت قبلاً ثبت نشده است");
            }
            context.SeniorityLevels.Remove(seniorityLevel);
            await context.SaveChangesAsync();

            return Ok();
        }


    }
}
