using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
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

        public AnalyzeController(INaturalLanguageUnderstandingService naturalLanguageService)
        {
            _naturalLanguageService = naturalLanguageService;
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