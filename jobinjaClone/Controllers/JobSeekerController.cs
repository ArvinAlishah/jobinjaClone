using jobinjaClone.Data;
using jobinjaClone.DTOs.JobSeekers;
using jobinjaClone.Entities;
using jobinjaClone.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace jobinjaClone.Controllers
{
    [Authorize("JobSeeker")]
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController(ApplicationDbContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var UserId = JwtHellper.GetId(User);
            var HaveJobSeeker = await   context.JobSeekers.AnyAsync(x=> x.UserId == UserId);
            if(HaveJobSeeker)
            {
                return BadRequest();
            }

            var JobSeeker = new JobSeeker
            {
                UserId = UserId,

            };
             context.JobSeekers.Add(JobSeeker);
            await context.SaveChangesAsync();


            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var UserId = JwtHellper.GetId(User);
            var HaveJobSeeker = await context.JobSeekers.AnyAsync(x => x.UserId == UserId);
            if (!HaveJobSeeker)
            {
                return NotFound();
            }

            //var JobSeeker = await context.JobSeekers.Where(x => x.UserId == UserId)
            //                        .Select(x => new GetJobSeekerResponseDto
            //                        {
            //                            About = x.About,



            //                        }).FirstOrDefaultAsync();
           


            return Ok();
        }



    }
}