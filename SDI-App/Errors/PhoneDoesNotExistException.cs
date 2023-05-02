using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SDI_App.Errors
{
    public class PhoneDoesNotExistException : Exception, IExceptionDetails
    {
        private int PhoneId;
        public PhoneDoesNotExistException(int id) : base($"Phone with id {id} does not exist")
        {
            PhoneId = id;
        }

        public ProblemDetails GetDetails()
        {
            return new ProblemDetails
            {
                Status = (int)HttpStatusCode.NotFound,
                Type = "phone-does-not-exist",
                Title = "Phone does not exist",
                Detail = this.Message
            };
        }
    }
}