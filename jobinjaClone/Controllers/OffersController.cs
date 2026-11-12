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
    [Route("api/[controller]/[Action]")]
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



            return Ok(tempOffer);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            int userid = JwtHellper.GetId(User);

            var Haveoffer = await context.Offers
                .Include(x => x.Employer)
                .AnyAsync(x => x.Employer.UserId == userid);
            if (!Haveoffer)
            {
                return NotFound("اگهی وجود ندارد");
            }
            var tempOffer = await context.Offers.Include(x => x.Employer)
                .Where(x => x.Employer.UserId == userid)
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




                }).ToListAsync();



            return Ok(tempOffer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddOfferDTO request)
        {
            int userid = JwtHellper.GetId(User);

            var employ = await context.Employer.Include(x=>x.Offers)
                .Where(x => x.UserId == userid).FirstOrDefaultAsync();
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
                GenderImportent = request.GenderImportent,
             
                YearExpriceId = request.YearExprience,
                offerStatus = request.offerStatus,
            };
            if(employ.Offers == null)
            {
                employ.Offers = new List<Offers>();
            }
            employ.Offers.Add(offer);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOfferDTO request)
        {
            int userid = JwtHellper.GetId(User);

            var offer = await context.Offers.Include(x => x.Employer)
                .Where(x => x.Employer.UserId == userid && x.Id == request.Id).FirstOrDefaultAsync();
            if (offer == null)
            {
                return NotFound();
            }

            offer.AboutJob = request.AboutJob;
                offer.AboutOffice = request.AboutOffice;
               offer.ExpectedSalary = request.ExpectedSalary;
               offer.Gnder = request.gender;
            offer.JobCategoriesId = request.JobCategories;
            offer.military = request.military;
            offer.MilitaryStatusImportent = request.MilitaryStatusImportent;
               offer.MinmumWageId = request.Minimumwage;
            offer.PrefersContactId = request.PrefersContact;
            offer.ProvinceId = request.Province;
            offer.title = request.title;
            offer.GenderImportent = request.GenderImportent;
            offer.YearExpriceId = request.YearExprience;
            offer.offerStatus = request.offerStatus;
        
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            int userid = JwtHellper.GetId(User);

            var offer = await context.Offers.Include(x => x.Employer)
                .Where(x => x.Employer.UserId == userid && x.Id == id).FirstOrDefaultAsync();
            if (offer == null)
            {
                return NotFound();
            }

          

             context.Remove(offer);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
