using jobinjaClone.Data;
using jobinjaClone.DTOs.Offer;
using jobinjaClone.Entities;
using jobinjaClone.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jobinjaClone.Controllers
{
    [Authorize(Roles = "Employer")]
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController(ApplicationDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            int userid = JwtHellper.GetId(User);

            var offer = await context.Offers
                .Include(x=>x.Employer)
                .Where( x=> x.Employer.UserId ==  userid && x.Id == id)
                .FirstOrDefaultAsync();
            if (offer == null)
            {
                return NotFound("اگهی وجود ندارد");
            }
            var tempOffer = await context.Offers.Where(x => x.Id == id)
                .Select(x => new GetOfferDTO
                {
                    AboutJob = x.AboutJob,
                    AboutOffice = x.AboutOffice,
                    ExpectedSalary = x.ExpectedSalary,
                    GenderImportent = x.GenderImportent,
                    Gnder = x.Gnder,
                    JobCategories = new()
                    {
                        Name = x.JobCategories.Name,
                    },
                    military = x.military,
                    MilitaryStatusImportent = x.MilitaryStatusImportent,
                    Minimumwage = new()
                    {
                        Mnimum = x.Minimumwage.minimum
                    },
                    offerStatus = x.offerStatus,
                    title = x.title,
                    Province = new()
                    {
                        Name = x.Province.Name
                    },
                    PrefersContact = new()
                    {
                        Name = x.PrefersContact.Name,
                    },
                    YearExprience = new()
                    {
                        Year = x.YearExprience.Year
                    }




                }).FirstOrDefaultAsync();



            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddOfferDTO request)
        {
            int userid = JwtHellper.GetId(User);

            var employ = await context.Employer.Where(x => x.UserId == userid).FirstOrDefaultAsync();
            if(employ == null)
            {
                return NotFound();
            }
            var offer = new Offers()
            {
                AboutJob = request.AboutJob,
                AboutOffice = request.AboutOffice,
                EmployId = employ.Id,
                ExpectedSalary = request.ExpectedSalary,
                Gnder = request.Gnder,
                JobCategoriesId = request.JobCategoriesId,
                military = request.military,
                MilitaryStatusImportent = request.MilitaryStatusImportent,
                MinmumWageId = request.Minimumwage,
                PrefersContactId =request.PrefersContact,
                ProvinceId =request.Province,
                title= request.title,
                YearExpriceId = request.YearExprience,
                offerStatus = request.offerStatus,
                


            };


            employ.Offers.Add(offer);





            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
