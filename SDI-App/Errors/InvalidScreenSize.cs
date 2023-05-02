using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SDI_App.Errors
{
    public class InvalidScreenSize : Exception, IExceptionDetails
    {
        private int ScreenSize;
        public InvalidScreenSize(int screenSize) : base($"Screen size {screenSize} is invalid!")
        {
            ScreenSize = screenSize;
        }
        public ProblemDetails GetDetails()
        {
            return new ProblemDetails
            {
                Status = (int)HttpStatusCode.BadRequest,
                Type = "invalid-os-type",
                Title = "Invalid OS type",
                Detail = this.Message
            };
        }
    }
}