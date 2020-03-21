using Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Contracts.Bookmarks
{
    public class GetBookmarksRequest : IValidatableObject
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Concepts { get; set; }
        public List<string> Keywords { get; set; }
        public List<string> Tags { get; set; }

        public bool IsValid()
        {
            bool isValid = false;
            if (!string.IsNullOrEmpty(Title)
                || string.IsNullOrEmpty(Url)
                || Categories.IsNullOrEmpty()
                || Concepts.IsNullOrEmpty()
                || Keywords.IsNullOrEmpty()
                || Tags.IsNullOrEmpty())
            {
                isValid = true;
            }

            return isValid;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            if (string.IsNullOrEmpty(Title)
                && string.IsNullOrEmpty(Url)
                && Categories.IsNullOrEmpty()
                && Concepts.IsNullOrEmpty()
                && Keywords.IsNullOrEmpty()
                && Tags.IsNullOrEmpty())
            {
                var validationResult = new ValidationResult($"{nameof(GetBookmarksRequest)} must have at least one of the follow properties: ",
                        new[] { nameof(Title), nameof(Url), nameof(Categories), nameof(Concepts), nameof(Keywords), nameof(Tags) });
                validationResults.Add(validationResult);
            }

            return validationResults;
        }
    }
}
