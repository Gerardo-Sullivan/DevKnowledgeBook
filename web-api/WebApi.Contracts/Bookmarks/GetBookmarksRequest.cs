using Common.Extensions;
using System.Collections.Generic;

namespace WebApi.Contracts.Bookmarks
{
    [GetBookmarksRequestValidation]
    public class GetBookmarksRequest
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Concepts { get; set; }
        public List<string> Keywords { get; set; }
        public List<string> Tags { get; set; }

        public bool IsValid() //TODO: inherit this from interface
        {
            var isValid = true;
            if (string.IsNullOrEmpty(Title)
                && string.IsNullOrEmpty(Url)
                && Categories.IsNullOrEmpty()
                && Concepts.IsNullOrEmpty()
                && Keywords.IsNullOrEmpty()
                && Tags.IsNullOrEmpty())
            {
                isValid = false;
            }

            return isValid;
        }

        public static string GetProperties()
        {
            var type = typeof(GetBookmarksRequest);
            var properties = type.GetProperties();
            string result = "";

            foreach (var prop in properties)
            {
                result += prop.Name + ", ";
            }

            return result.Trim().TrimEnd(',');
        }
    }
}
