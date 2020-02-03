using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Contracts
{
    public class GetBookmarksRequest
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Concepts { get; set; }
        public List<string> Keywords { get; set; }
        public List<string> Tags { get; set; }

        public GetBookmarksRequest()
        {
            Categories = new List<string>();
            Concepts = new List<string>();
            Keywords = new List<string>();
            Tags = new List<string>();
        }
    }
}
