using jobinjaClone.Data;
using jobinjaClone.DTOs.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace jobinjaClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController(ApplicationDbContext context) : ControllerBase
    {
        private int pageSize = 10;
        [HttpGet]
        public async Task<IActionResult> Get([FromBody] SearchDTO request, [FromQuery] int pagenum)
        {
            List< OffersDTO> searchResult = new();
            pagenum = pagenum  < 1 ? 1 : pagenum;

            if (request != null)
            {
                var query = context.Offers
                    .Include(x => x.JobCategories)
                    .AsQueryable();
                query = query.Where(x => x.JobCategories.Name.Contains(request.search) || x.title.Contains(request.search));
                if (request.isJobCategorize)
                {
                    query = query.Where(x => x.JobCategoriesId == request.JobCategorizeId);

                }
                if (request.isMinimumWage)
                {
                    query = query.Where(x => x.MinmumWageId == request.MinimumWageId);

                }
                if (request.isprovincefillter)
                {
                    query = query.Where(x => x.ProvinceId == request.provincefillterid);

                }
                if (request.isPrefersContact)
                {
                    query = query.Where(x => x.PrefersContactId == request.PrefersContactId);

                }


                int resultNumber = await query.CountAsync();

                int pagesNumber = (resultNumber + pageSize - 1) / pageSize;

                 searchResult = await query
        .OrderByDescending(x => x.Id)
        .Skip((pagenum - 1) * pageSize)
        .Take(pageSize)
        .Select(x => new OffersDTO
        {
            JobTitle = x.title,
            Companyname = x.AboutOffice,
            prefrancecintract = x.PrefersContact.Name,
            minimumWage = x.Minimumwage.minimum,
            ProvinceName = x.Province.Name
        })
        .ToListAsync();
            }
            else
            {

                int resultNumber = await context.Offers.CountAsync();

                int pagesNumber = (resultNumber + pageSize - 1) / pageSize;

                searchResult = await context.Offers
       .OrderByDescending(x => x.Id)
       .Skip((pagenum - 1) * pageSize)
       .Take(pageSize)
       .Select(x => new OffersDTO
       {
           JobTitle = x.title,
           Companyname = x.AboutOffice,
           prefrancecintract = x.PrefersContact.Name,
           minimumWage = x.Minimumwage.minimum,
           ProvinceName = x.Province.Name
       })
       .ToListAsync();





            }


            return Ok(searchResult);
        }
    }
}
