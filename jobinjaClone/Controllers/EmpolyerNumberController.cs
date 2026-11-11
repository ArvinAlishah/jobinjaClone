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
    public class EmployerController(ApplicationDbContext context) : ControllerBase
    {
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmploeyNumberDTO requst)
        {
            var IsPressent = await context.EmploeyNumber.AnyAsync(x => x.Number == requst.number);
            if (IsPressent)
            {
                return BadRequest("این سطح ارشدیت قبلاً ثبت شده است");
            }

            var emploeyNumber = new EmploeyNumber
            {
                Number = requst.number
            };
            context.EmploeyNumber.Add(emploeyNumber);
            await context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "Admin,JobSeeker")]
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var officeFeild = await context.EmploeyNumber
       .Select(x => new GetEmploeyNumberDTO
       {
           id = x.Id,
          number = x.Number,
       })
       .ToListAsync();

            return Ok(officeFeild);

        }
        [Authorize(Roles = "Admin")]

        [HttpPut]
        public async Task<IActionResult> Update(UpdateEmploeyNumberDTO requst)
        {
            var emploeyNumber = await context.EmploeyNumber.FirstOrDefaultAsync(x => x.Id == requst.id);
            if (emploeyNumber == null)
            {
                return BadRequest("این سطح ارشدیت قبلاً ثبت نشده است");
            }
            emploeyNumber.Number = requst.number;
            await context.SaveChangesAsync();

            return Ok();
        }
        [Authorize(Roles = "Admin")]

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var emploeyNumber = await context.EmploeyNumber.FirstOrDefaultAsync(x => x.Id == id);
            if (emploeyNumber == null)
            {
                return BadRequest("این سطح ارشدیت قبلاً ثبت نشده است");
            }
            context.EmploeyNumber.Remove(emploeyNumber);
            await context.SaveChangesAsync();

            return Ok();
        }


    }
}
