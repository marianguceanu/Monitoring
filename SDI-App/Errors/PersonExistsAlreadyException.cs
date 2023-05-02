using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SDI_App.Errors
{
    public class PersonExistsAlreadyException : Exception, IExceptionDetails
    {
        private string CNP;
        public PersonExistsAlreadyException(string cnp) : base($"Phone with model number {cnp} already exists")
        {
            CNP = cnp;
        }
        public ProblemDetails GetDetails()
        {
            return new ProblemDetails
            {
                Status = (int)HttpStatusCode.Forbidden,
                Type = "person-exists-already",
                Title = "Person already exists",
                Detail = this.Message
            };
        }
    }
}
