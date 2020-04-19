using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using System.Collections.Generic;

namespace Domain.Tests.Models.Firestore
{
    public abstract class BookmarkAnalysisResultsConstructorTestBase
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
