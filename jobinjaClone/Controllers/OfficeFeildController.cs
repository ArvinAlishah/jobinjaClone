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
    public class OfficeFeildController(ApplicationDbContext context) : ControllerBase
    {
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(CreateOfficeDTO requst)
        {
            var IsPressent = await context.OfficeFeild.AnyAsync(x => x.Name == requst.Name);
            if (IsPressent)
            {
                return BadRequest("این سطح ارشدیت قبلاً ثبت شده است");
            }

            var officeFeild = new OfficeFeild
            {
                Name = requst.Name
            };
            context.OfficeFeild.Add(officeFeild);
            await context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "Admin,JobSeeker")]
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var officeFeild = await context.OfficeFeild
       .Select(x => new GetOfficeFieldDTO
       {
           id = x.Id,
           Name = x.Name,
       })
       .ToListAsync();

            return Ok(officeFeild);

        }
        [Authorize(Roles = "Admin")]

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOfficeDTO requst)
        {
            var officeFeild = await context.OfficeFeild.FirstOrDefaultAsync(x => x.Id == requst.id);
            if (officeFeild == null)
            {
                return BadRequest("این سطح ارشدیت قبلاً ثبت نشده است");
            }
            officeFeild.Name = requst.Name;
            await context.SaveChangesAsync();

            return Ok();
        }
        [Authorize(Roles = "Admin")]

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var officeFeild = await context.OfficeFeild.FirstOrDefaultAsync(x => x.Id == id);
            if (officeFeild == null)
            {
                return BadRequest("این سطح ارشدیت قبلاً ثبت نشده است");
            }
            context.OfficeFeild.Remove(officeFeild);
            await context.SaveChangesAsync();

            return Ok();
        }


    }
}
