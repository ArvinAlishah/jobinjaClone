using jobinjaClone.Data;
using jobinjaClone.DTOs.Province;
using jobinjaClone.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jobinjaClone.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PrefersContactController(ApplicationDbContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreatePrefersContactDTO requst)
        {
            var IsPressent =    await context.PrefersContacts.AnyAsync(x => x.Name == requst.Name);
            if (IsPressent)
            {
                 return BadRequest("این مزایا موجود است");
            }

            var prefersContact = new PrefersContact
            {
                Name = requst.Name
            };
            context.PrefersContacts.Add(prefersContact);
            await context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "Admin,JobSeeker")]
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var PrefersContact = await context.PrefersContacts
       .Select(x => new GetPrefersContactDTO
       {
           id = x.Id,
           Name = x.Name
       })
       .ToListAsync();

            return Ok(PrefersContact);

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePrefersContactDTO requst)
        {
            var PrefersContact = await context.PrefersContacts.FirstOrDefaultAsync(x => x.Id == requst.id);
            if (PrefersContact == null)
            {
                return BadRequest("این مزایا موجود نیست");
            }
            PrefersContact.Name = requst.Name;
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var PrefersContact = await context.PrefersContacts.FirstOrDefaultAsync(x => x.Id == id);
            if (PrefersContact == null)
            {
                return BadRequest("این مزایا موجود نیست");
            }
            context.PrefersContacts.Remove(PrefersContact);
            await context.SaveChangesAsync();

            return Ok();
        }


    }
}
