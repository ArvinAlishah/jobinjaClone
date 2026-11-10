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
    public class JobCategoriesController(ApplicationDbContext context) : ControllerBase
    {
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(CreateJobCategoriesLevelDTO requst)
        {
            var IsPressent =    await context.JobCategories.AnyAsync(x => x.Name == requst.Name);
            if (IsPressent)
            {
                 return BadRequest("این سطح ارشدیت قبلاً ثبت شده است");
            }

            var jobCategories = new JobCategories
            {
                Name = requst.Name
            };
            context.JobCategories.Add(jobCategories);
            await context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "Admin,JobSeeker")]
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var jobCategories = await context.JobCategories
       .Select(x => new GetSeniorityLevelDTO
       {
           id = x.Id,
           Name = x.Name
       })
       .ToListAsync();

            return Ok(jobCategories);

        }
        [Authorize(Roles = "Admin")]

        [HttpPut]
        public async Task<IActionResult> Update(UpdateJobCategoriesLevelDTO requst)
        {
            var jobCategories = await context.JobCategories.FirstOrDefaultAsync(x => x.Id == requst.id);
            if (jobCategories == null)
            {
                return BadRequest("این سطح ارشدیت قبلاً ثبت نشده است");
            }
            jobCategories.Name = requst.Name;
            await context.SaveChangesAsync();

            return Ok();
        }
        [Authorize(Roles = "Admin")]

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var jobCategories = await context.JobCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (jobCategories == null)
            {
                return BadRequest("این سطح ارشدیت قبلاً ثبت نشده است");
            }
            context.JobCategories.Remove(jobCategories);
            await context.SaveChangesAsync();

            return Ok();
        }


    }
}
