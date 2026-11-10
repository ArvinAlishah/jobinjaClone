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
    public class ProvinceController(ApplicationDbContext context) : ControllerBase
    {
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> CreateProvince(CreatePrefersContactDTO requst)
        {
            var IsPressent =    await context.Provinces.AnyAsync(x => x.Name == requst.Name);
            if (IsPressent)
            {
                return BadRequest("استان وارد شده موجود است");
            }

            var province = new Province
            {
                Name = requst.Name
            };
            context.Provinces.Add(province);
            await context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "Admin,JobSeeker")]
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var provinces = await context.Provinces
       .Select(x => new GetPrefersContactDTO
       {
           id = x.Id,
           Name = x.Name
       })
       .ToListAsync();

            return Ok(provinces);

        }
        [Authorize(Roles = "Admin")]

        [HttpPut]
        public async Task<IActionResult> UpdateProvince(UpdatePrefersContactDTO requst)
        {
            var province = await context.Provinces.FirstOrDefaultAsync(x => x.Id == requst.id);
            if (province == null)
            {
                return BadRequest("استان وارد شده  وجود  ندارد");
            }
            province.Name = requst.Name;
            await context.SaveChangesAsync();

            return Ok();
        }
        [Authorize(Roles = "Admin")]

        [HttpDelete]
        public async Task<IActionResult> DeleteProvince(int id)
        {
            var province = await context.Provinces.FirstOrDefaultAsync(x => x.Id == id);
            if (province == null)
            {
                return BadRequest("استان وارد شده  وجود  ندارد");
            }
            context.Provinces.Remove(province);
            await context.SaveChangesAsync();

            return Ok();
        }


    }
}
