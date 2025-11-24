using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Errors
{
    public class BadRequestExeption(List<string> Errors) : Exception("ValidationErrors")
    {
        public  List<string> errors = Errors;
    }
}
