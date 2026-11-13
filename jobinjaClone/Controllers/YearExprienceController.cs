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
    public class YearExpreinceController(ApplicationDbContext context) : ControllerBase
    {
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(CreateYearExprienceDTO requst)
        {
            var IsPressent = await context.YearExprience.AnyAsync(x => x.Year == requst.Year);
            if (IsPressent)
            {
                return BadRequest("این سال موجود است");
            }

            var exprienceyear = new YearExprience
            {
                Year = requst.Year
            };
            context.YearExprience.Add(exprienceyear);
            await context.SaveChangesAsync();
            return Ok();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var yearexprience = await context.YearExprience
       .Select(x => new GetYearExprienceDTO
       {
           id = x.Id,
           Year = x.Year
       })
       .ToListAsync();

            return Ok(yearexprience);

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
            var yearExprience = await context.YearExprience.FirstOrDefaultAsync(x => x.Id == id);
            if (yearExprience == null)
            {
                return BadRequest("این مزایا موجود نیست");
            }
            context.YearExprience.Remove(yearExprience);
            await context.SaveChangesAsync();

            return Ok();
        }


    }
}