using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;

namespace Api.Extensions
{
    public static class NaturalLanguageServiceExtensions
    {
        public static AnalysisResults Analyze(this INaturalLanguageUnderstandingService naturalLanguageService, string url)
        {
            Parameters parameters = new Parameters
            {
                Url = url,
                Features = new Features
                {
                    Categories = new CategoriesOptions(),
                    Concepts = new ConceptsOptions(),
                    Keywords = new KeywordsOptions(),
                    Metadata = new MetadataOptions()
                },
            };

            return naturalLanguageService.Analyze(parameters);
        }
    }
}
