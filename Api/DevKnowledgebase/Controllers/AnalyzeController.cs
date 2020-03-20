using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Api.Services;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1;
using Microsoft.AspNetCore.Mvc;
using Api.Extensions;
using System.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Domain.Models.Firestore;
using WebApiContracts;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AnalyzeController : ControllerBase
    {
        private readonly INaturalLanguageUnderstandingService _naturalLanguageService;
        private readonly IFirestoreDbContext _dbContext;

        public AnalyzeController(INaturalLanguageUnderstandingService naturalLanguageService, IFirestoreDbContext dbService)
        {
            _naturalLanguageService = naturalLanguageService;
            _dbContext = dbService;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(Bookmark), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Bookmark), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ModelStateDictionary), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Bookmark([Required][FromBody] AnalyzeRequest request)
        {
            var bookmark = await _dbContext.GetBookmarkFromUrlAsync(request.Url);

            if (bookmark != null) //TODO: might want to save new custom tags
            {
                return Ok(bookmark);
            }

            var results = _naturalLanguageService.Analyze(request.Url);
            bookmark = new Bookmark(results, request.Tags);
            bookmark = await _dbContext.AddBookmarkAsync(bookmark);

            return Created(bookmark.Path, bookmark);
        }
    }
}
