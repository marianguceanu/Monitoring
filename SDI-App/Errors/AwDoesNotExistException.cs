using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SDI_App.Errors
{
    public class AwDoesNotExistException : Exception, IExceptionDetails
    {
        public AwDoesNotExistException(int id) : base($"Website with id {id} does not exist")
        {
        }

        public ProblemDetails GetDetails()
        {
            return new ProblemDetails
            {
                Status = (int)HttpStatusCode.NotFound,
                Type = "person-does-not-exist",
                Title = "Person does not exist",
                Detail = this.Message
            };
        }
    }
}