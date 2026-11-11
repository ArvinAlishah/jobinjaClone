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
    public class BenefitsDTOController(ApplicationDbContext context) : ControllerBase
    {
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(CreateBenefitsDTO requst)
        {
            var IsPressent =    await context.Benefits.AnyAsync(x => x.Name == requst.Name);
            if (IsPressent)
            {
                 return BadRequest("این سطح ارشدیت قبلاً ثبت شده است");
            }

            var benefits = new Benefits
            {
                Name = requst.Name
            };
            context.Benefits.Add(benefits);
            await context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "Admin,JobSeeker")]
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var benefits = await context.Benefits
       .Select(x => new GetSeniorityLevelDTO
       {
           id = x.Id,
           Name = x.Name
       })
       .ToListAsync();

            return Ok(benefits);

        }
        [Authorize(Roles = "Admin")]

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBenefitsDTO requst)
        {
            var benefits = await context.Benefits.FirstOrDefaultAsync(x => x.Id == requst.id);
            if (benefits == null)
            {
                return BadRequest("این سطح ارشدیت قبلاً ثبت نشده است");
            }
            benefits.Name = requst.Name;
            await context.SaveChangesAsync();

            return Ok();
        }
        [Authorize(Roles = "Admin")]

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var benefits = await context.Benefits.FirstOrDefaultAsync(x => x.Id == id);
            if (benefits == null)
            {
                return BadRequest("این سطح ارشدیت قبلاً ثبت نشده است");
            }
            context.Benefits.Remove(benefits);
            await context.SaveChangesAsync();

            return Ok();
        }


    }
}
