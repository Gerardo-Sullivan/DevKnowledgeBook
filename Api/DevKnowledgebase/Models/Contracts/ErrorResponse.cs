using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Contracts
{
    public class ErrorResponse
    {
        public string Request { get; set; }
        public DateTimeOffset ErrorTime { get; set; }
        public Error Error { get; set; }
    }
}
