using Microsoft.AspNetCore.Mvc;
using SDI_App.Errors;
using System.Text.Json;
using System.Net;

namespace SDI_App.Middleware
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                ProblemDetails error;

                switch (exception)
                {
                    case PhoneDoesNotExistException phoneDoesNotExist:
                        error = phoneDoesNotExist.GetDetails();
                        break;
                    case PhoneExistsAlreadyException phoneExists:
                        error = phoneExists.GetDetails();
                        break;
                    case PersonDoesNotExistException personDoesNotExist:
                        error = personDoesNotExist.GetDetails();
                        break;
                    case PersonExistsAlreadyException personExists:
                        error = personExists.GetDetails();
                        break;
                    case InvalidScreenSize invalidScreen:
                        error = invalidScreen.GetDetails();
                        break;
                    case TabletDoesNotExistException tabletDoesNotExist:
                        error = tabletDoesNotExist.GetDetails();
                        break;
                    case TabletExistsAlreadyException tabletExists:
                        error = tabletExists.GetDetails();
                        break;
                    default:
                        error = new ProblemDetails();
                        break;
                }
                var result = JsonSerializer.Serialize(error);
                context.Response.StatusCode = error.Status.GetValueOrDefault((int)HttpStatusCode.InternalServerError);
                await response.WriteAsync(result);
            }
        }
    }
}