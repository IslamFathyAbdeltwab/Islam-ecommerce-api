using Microsoft.Identity.Client;

namespace ECommerce.Web.ErrorsModel
{
    internal class ErrorResponse
    {
        public int statesCode { get; set; }

        public string message { get; set; }
        public List<string> errors { get; set; }
    }
}
