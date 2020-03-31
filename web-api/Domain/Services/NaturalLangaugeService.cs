using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using Microsoft.Extensions.Logging;
using System;

namespace Domain.Services
{
    public interface INaturalLangaugeService
    {
        /// <summary>
        /// Analyze url using <see cref="INaturalLanguageUnderstandingService"/>
        /// </summary>
        AnalysisResults Analyze(string url);
    }

    public class NaturalLangaugeService : INaturalLangaugeService
    {
        private readonly INaturalLanguageUnderstandingService _naturalLanguageUnderstandingService;
        private readonly ILogger<NaturalLangaugeService> _logger;

        public NaturalLangaugeService(
            INaturalLanguageUnderstandingService naturalLanguageUnderstandingService,
            ILogger<NaturalLangaugeService> logger
        )
        {
            _naturalLanguageUnderstandingService = naturalLanguageUnderstandingService;
            _logger = logger;
        }

        public AnalysisResults Analyze(string url)
        {
            AnalysisResults result = null;
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

            try
            {
                result = _naturalLanguageUnderstandingService.Analyze(parameters);
                _logger.LogTraceObject(result);
            }
            catch (AggregateException e)
            {
                var loggedException = e.InnerException ?? e;
                _logger.LogError(loggedException, $"Bad request url for analyze {url}");
                //TODO: add service level exception to throw
                //TODO: add exception action filter
            }

            return result;
        }
    }
}
