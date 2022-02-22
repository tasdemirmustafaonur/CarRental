using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Core.Extensions.Exception
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
