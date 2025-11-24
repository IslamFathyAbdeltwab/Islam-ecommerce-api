using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Errors
{
    public class ValidationErrors
    {
        public int statusCode { get; set; }=(int)HttpStatusCode.BadRequest;
        public string message { get; set; } = "Validation Errors";

        public IEnumerable<ValidationError> Errors { get; set; }
    }
}
