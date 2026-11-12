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
    public class YMinimumWageController(ApplicationDbContext context) : ControllerBase
    {
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(createMinimumwageTO requst)
        {
            var IsPressent = await context.Minimumwage.AnyAsync(x => x.minimum == requst.Minimumwage);
            if (IsPressent)
            {
                return BadRequest("این سال موجود است");
            }

            var minimum = new Minimumwage
            {
                minimum = requst.Minimumwage
            };
            context.Minimumwage.Add(minimum);
            await context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "Admin,Employer")]
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var minimum = await context.Minimumwage
       .Select(x => new GetMinimumwageDTO
       {
           id = x.Id,
           Minimumwage = x.minimum
       })
       .ToListAsync();

            return Ok(minimum);

        }
        [Authorize(Roles = "Admin")]

        [HttpPut]
        public async Task<IActionResult> Update(UpdateYearExprienceDTO requst)
        {
            var PrefersContact = await context.YearExprience.FirstOrDefaultAsync(x => x.Id == requst.id);
            if (PrefersContact == null)
            {
                return BadRequest("این مزایا موجود نیست");
            }
            PrefersContact.Year = requst.Year;
            await context.SaveChangesAsync();

            return Ok();
        }
        [Authorize(Roles = "Admin")]

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var minimum = await context.Minimumwage.FirstOrDefaultAsync(x => x.Id == id);
            if (minimum == null)
            {
                return BadRequest("این مزایا موجود نیست");
            }
            context.Minimumwage.Remove(minimum);
            await context.SaveChangesAsync();

            return Ok();
        }


    }
}