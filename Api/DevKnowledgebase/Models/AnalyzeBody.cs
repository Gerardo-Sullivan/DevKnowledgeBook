using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class AnalyzeBody
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
        public AnalyzeBody()
        {
            Tags = new List<string>();
        }
    }
}
