//using jobinjaClone.Data;
//using jobinjaClone.DTOs.Search;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace jobinjaClone.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SearchController(ApplicationDbContext context) : ControllerBase
//    {
//        private int pageSize = 10;
//        [HttpGet]
//        public async Task<IActionResult> Get( [FromBody]SearchDTO request , [FromQuery])
//        {

//            int resultNumber = await context.Offers.CountAsync();
//            int pagesNumber = (resultNumber + pageSize - 1) / pageSize;
//            if (request != null) {
//                var query = context.Offers
//                    .Include(x=>x.JobCategories)
//                    .AsQueryable();
//                query = query.Where(x => x.JobCategories.Name.Contains(request.search) || x.title.Contains(request.search));
//                if (request.isJobCategorize)
//                {
//                    query = query.Where(x => x.JobCategoriesId  ==  request.JobCategorizeId);

//                }
//                if (request.isMinimumWage)
//                {
//                    query = query.Where(x => x.MinmumWageId == request.MinimumWageId);

//                }
//                if (request.isprovincefillter)
//                {
//                    query = query.Where(x => x.ProvinceId == request.provincefillterid);

//                }
//                if (request.isPrefersContact)
//                {
//                    query = query.Where(x => x.PrefersContactId == request.PrefersContactId);

//                }


//                var searchResult = query.Select(x => new SearachResultDTO
//                {
//                    offers = context.Offers.Where(x => x.Id =
//                    Select(x=>new OffersDTO
//                    {
//                        JobTitle = 
//                    }).ToList()




//                });
//                    }
//            else
//            {

//            }


//            return Ok();
//        }
//    }
//}
