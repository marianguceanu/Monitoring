using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SDI_App.Errors
{

    public class TabletDoesNotExistException : Exception, IExceptionDetails
    {
        private int TabletId;
        public TabletDoesNotExistException(int id) : base($"Tablet with id {id} does not exist")
        {
            TabletId = id;
        }

        public ProblemDetails GetDetails()
        {
            return new ProblemDetails
            {
                Status = (int)HttpStatusCode.NotFound,
                Type = "Tablet-does-not-exist",
                Title = "Tablet does not exist",
                Detail = this.Message
            };
        }
    }
}
