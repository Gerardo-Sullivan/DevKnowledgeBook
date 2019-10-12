using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
    }
}