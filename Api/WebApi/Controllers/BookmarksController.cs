using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Domain.Models.Firestore;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using WebApiContracts.Bookmarks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class BookmarksController : Controller
    {
        private readonly IFirestoreDbContext _dbContext;

        public BookmarksController(IFirestoreDbContext dbService)
        {
            _dbContext = dbService;
        }

        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpGet]
        [ProducesResponseType(typeof(List<Bookmark>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            List<Bookmark> bookmarks = await _dbContext.GetBookmarksAsync();

            return Ok(bookmarks);
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<Bookmark>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Search([FromBody]GetBookmarksRequest request)
        {
            List<Bookmark> bookmarks = await _dbContext.GetBookmarksAsync(request);

            return Ok(bookmarks);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Bookmark), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([Required]string id)
        {
            Bookmark bookmark = await _dbContext.GetBookmarkAsync(id);

            if (bookmark is null)
            {
                return NotFound();
            }

            return Ok(bookmark);
        }
    }
}
