using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Contracts.Bookmarks
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GetBookmarksRequestValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var getBookmarksRequest = (GetBookmarksRequest)value;

            if (getBookmarksRequest == null)
            {
                return new ValidationResult($"{nameof(GetBookmarksRequest)} is null");
            }

            if (getBookmarksRequest.IsValid() == false)
            {
                return new ValidationResult($"{nameof(GetBookmarksRequest)} must have one of the following properties: {GetBookmarksRequest.GetProperties()}");
            }

            return ValidationResult.Success;
        }
    }
}
