using jobinjaClone.Data;
using jobinjaClone.DTOs.Employer;
using jobinjaClone.Entities;
using jobinjaClone.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace jobinjaClone.Controllers
{
    [Authorize(Roles = "Employer")]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployerController(ApplicationDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int UserId = JwtHellper.GetId(User);
            var employer = await context.Employer.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (employer == null)
            {
                return NotFound("کارجو ثبت نشده است");
            }
            var emplyer = await context.Employer
                .Where(x => x.Id == employer.Id).
                Select(x => new GetEmployerDto
                {
FirstName = x.FirstName,
LastName = x.LastName,


                }).FirstOrDefaultAsync();

            return Ok(emplyer);
        }



        [HttpPost]
       public async Task<IActionResult> Create(CreateEmployerDTO request)
        {
            int UserId = JwtHellper.GetId(User);
            var Haveemployer = await context.Employer.AnyAsync(x => x.UserId == UserId);
            if (Haveemployer)
            {
                return NotFound("کارفرما ثبت شده است");
            }
            var employer = new Employer
            {
                FirstName = request.FirstName,
                UserId = UserId,
                LastName = request.LastName,
            };
            context.Employer.Add(employer);
            await context.SaveChangesAsync();


            return Ok();
        }
    }
}
