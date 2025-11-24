using Azure;
using ECommerce.Domain.Errors;
using ECommerce.Web.ErrorsModel;

namespace ECommerce.Web.Middelware
{
    internal class ExeptionHandelingMiddelware
    {
        public RequestDelegate Next { get; }
        public ILogger Logger { get; }

        public ExeptionHandelingMiddelware(RequestDelegate next, ILogger<ExeptionHandelingMiddelware> logger)
        {
            Next = next;
            Logger = logger;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            //logic for request
            try
            {

                await Next(context);//call next middelware
                //here we handel the errors not exeptions    
                //01 handel 404
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    // here have a problem if another middelware set 404 and this middelware not userouting and useendpoint so the message is static for the path may be error not for the path

                    var res = new ErrorResponse()
                    {
                        statesCode = context.Response.StatusCode,
                        message = $"the path:{context.Request.Path} is not found"
                    };
                    await context.Response.WriteAsJsonAsync(res);
                }

                


            }
            catch (Exception ex)
            {

                var res = new ErrorResponse()
                {

                   

                    message = ex.Message

                };

                Logger.LogError(ex, ex.Message);
                context.Response.StatusCode = ex switch
                {
                    //here check type of exeption and set states code 
                    NotFoundExeption => StatusCodes.Status404NotFound,
                    UnAuthorizeExeption=>StatusCodes.Status401Unauthorized,
                    BadRequestExeption badex=> SetErrors(badex,res),
                    _ => StatusCodes.Status500InternalServerError


                };


                res.statesCode = context.Response.StatusCode;
                await context.Response.WriteAsJsonAsync(res);

            }
            //logic for response
        }

        int SetErrors(BadRequestExeption ex,ErrorResponse err)
        {
            err.errors = ex.errors;
             
            return StatusCodes.Status400BadRequest;
        }
    }
}
