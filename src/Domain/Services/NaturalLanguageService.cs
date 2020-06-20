using Common.Extensions;
using Domain.Exceptions;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using Microsoft.Extensions.Logging;
using System;

namespace Domain.Services
{
    public interface INaturalLanguageService
    {
        /// <summary>
        /// Analyze url using <see cref="INaturalLanguageUnderstandingService"/>
        /// </summary>
        AnalysisResults Analyze(string url);
    }

    public class NaturalLanguageService : INaturalLanguageService
    {
        private readonly INaturalLanguageUnderstandingService _naturalLanguageUnderstandingService;
        private readonly ILogger<NaturalLanguageService> _logger;

        public NaturalLanguageService(
            INaturalLanguageUnderstandingService naturalLanguageUnderstandingService,
            ILogger<NaturalLanguageService> logger
        )
        {
            _naturalLanguageUnderstandingService = naturalLanguageUnderstandingService;
            _logger = logger;
        }

        /// <inheritdoc/>
        public AnalysisResults Analyze(string url)
        {
            AnalysisResults result;
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
                _logger.LogError(loggedException, $"Bad request url for analysis: {url}");
                throw new NaturalLangaugeInvalidUrlException("Bad request url for analysis", url, loggedException);
            }

            return result;
        }
    }
}
