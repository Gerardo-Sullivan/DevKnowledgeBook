using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api.Models.Firestore;
using Api.Models.Responses;
using Api.Services;
using Google.Cloud.Firestore;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using Microsoft.AspNetCore.Mvc;
using Api.Extensions;

namespace DevKnowledgebase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyzeController : ControllerBase
    {
        private readonly INaturalLanguageUnderstandingService _naturalLanguageService;
        private readonly IFirestoreDbService _dbService;

        public AnalyzeController(INaturalLanguageUnderstandingService naturalLanguageService, IFirestoreDbService dbService)
        {
            _naturalLanguageService = naturalLanguageService;
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

        [HttpPost]
        public async Task<ActionResult<AnalyzeResponse>> Analyze([Required][FromBody] AnalyzeBody body)
        {
            AnalysisResults results;
            Bookmark bookmark;

            if (ModelState.IsValid)
            {
                bookmark = await _dbService.GetBookmarkAsync(body.Url);

                if (bookmark != null)
                {
                    return Ok(bookmark);
                }

                try
                {
                    results = _naturalLanguageService.Analyze(body.Url);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

                bookmark = new Bookmark(results, body.Tags);
                bookmark = await _dbService.AddBookmarkAsync(bookmark);

                return Created(bookmark.Path, bookmark);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}