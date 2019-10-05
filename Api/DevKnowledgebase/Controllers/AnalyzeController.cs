using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api.Models.Firestore;
using Api.Models.Responses;
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
        public async Task<ActionResult<AnalyzeResponse>> Analyze([Required][FromBody] AnalyzeBody body)
        {
            AnalysisResults results;
            Bookmark bookmark;

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
                    results = _naturalLanguageService.Analyze(parameters);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

                //TODO: check url already exists in the db
                CollectionReference bookmarks = _db.Collection("bookmarks");
                Query query = bookmarks.WhereEqualTo("url", results.RetrievedUrl);
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

                if (querySnapshot.Documents.Any())
                {
                    bookmark = querySnapshot.Documents.First().ConvertTo<Bookmark>();

                    return Ok(bookmark);
                }

                bookmark = new Bookmark(results);
                DocumentReference docReference = await bookmarks.AddAsync(bookmark);
                //TODO: add categories, concepts and keywords collection.
                bookmark.Id = docReference.Id;
                //TODO: save bookmark document to firestore
                //TODO: need to save the associated categories, concepts, and keywords collection for the newly added document

                return Created(docReference.Path, bookmark);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}