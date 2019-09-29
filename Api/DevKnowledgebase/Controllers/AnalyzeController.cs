using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api.Models.Firestore;
using Google.Cloud.Firestore;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using Microsoft.AspNetCore.Mvc;

namespace DevKnowledgebase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyzeController : ControllerBase
    {
        private readonly INaturalLanguageUnderstandingService _naturalLanguageService;
        private readonly FirestoreDb _db;

        public AnalyzeController(INaturalLanguageUnderstandingService naturalLanguageService, FirestoreDb db)
        {
            _naturalLanguageService = naturalLanguageService;
            _db = db;
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
        public ActionResult<AnalysisResults> Analyze([Required][FromBody] AnalyzeBody body)
        {
            if (ModelState.IsValid)
            {
                Parameters parameters = new Parameters
                {
                    Url = body.Url,
                    Features = new Features
                    {
                        Categories = new CategoriesOptions(),
                        Concepts = new ConceptsOptions(),
                        Keywords = new KeywordsOptions(),
                        Metadata = new MetadataOptions()
                    },
                };

                try
                {
                    AnalysisResults results = _naturalLanguageService.Analyze(parameters);
                    CollectionReference bookmarks = _db.Collection("bookmarks");
                    var bookmark = new Bookmark(results);
                    //TODO: save bookmark document to firestore
                    //TODO: need to save the associated categories, concepts, and keywords collection for the newly added document

                    return Ok(results);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}