using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Models.Firestore;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class BookmarksController : Controller
    {
        private readonly IFirestoreDbService _dbService;

        public BookmarksController(IFirestoreDbService dbService)
        {
            _dbService = dbService;
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
            List<Bookmark> bookmarks = await _dbService.GetBookmarksAsync();

            return Ok(bookmarks);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Bookmark), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([Required]string id)
        {
            Bookmark bookmark = await _dbService.GetBookmarkAsync(id);

            if (bookmark is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(bookmark);
            }
        }
    }
}