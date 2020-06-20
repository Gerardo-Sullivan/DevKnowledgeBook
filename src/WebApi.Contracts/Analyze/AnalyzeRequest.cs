using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Contracts.Analyze
{
    public class AnalyzeRequest
    {
        private string _url;

        [Required]
        [Url]
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value.TrimEnd('/'); ;
            }
        }

        public List<string> Tags { get; set; }
        public AnalyzeRequest()
        {
            Tags = new List<string>();
        }
    }
}
