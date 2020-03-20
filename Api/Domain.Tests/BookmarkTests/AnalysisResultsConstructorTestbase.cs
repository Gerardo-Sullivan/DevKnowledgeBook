using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTests.BookmarkTests
{
    public abstract class AnalysisResultsConstructorTestBase
    {
        protected readonly AnalysisResults _analysisResults = new AnalysisResults
        {
            Metadata = new MetadataResult
            {
                Title = "title",
            },
            RetrievedUrl = "url",
            Categories = new List<CategoriesResult>(),
            Concepts = new List<ConceptsResult>(),
            Keywords = new List<KeywordsResult>()
        };
    }
}
