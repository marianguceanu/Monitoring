using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SDI_App.Errors
{
    public class PersonDoesNotExistException : Exception, IExceptionDetails
    {
        private int PersonId;
        public PersonDoesNotExistException(int id) : base($"Person with id {id} does not exist")
        {
            PersonId = id;
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