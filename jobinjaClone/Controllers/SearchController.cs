using jobinjaClone.Data;
using jobinjaClone.DTOs.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jobinjaClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController(ApplicationDbContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get( [FromBody]SearchDTO request , [FromQuery])
        {

            var resultNumber = await 
            if (request != null) {
                //var query =
                    }
            return Ok();
        }
    }
}
