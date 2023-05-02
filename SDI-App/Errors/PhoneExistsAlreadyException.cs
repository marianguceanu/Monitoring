using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SDI_App.Errors
{
    public class PhoneExistsAlreadyException : Exception, IExceptionDetails
    {
        private int ModelNumber;
        public PhoneExistsAlreadyException(int modelNumber) : base($"Phone with model number {modelNumber} already exists")
        {
            ModelNumber = modelNumber;
        }
        public ProblemDetails GetDetails()
        {
            return new ProblemDetails
            {
                Status = (int)HttpStatusCode.Forbidden,
                Type = "phone-exists-already",
                Title = "Phone already exists",
                Detail = this.Message
            };
        }
    }
}