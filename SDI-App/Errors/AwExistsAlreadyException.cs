using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SDI_App.Errors
{
    public class AwExistsAlreadyException : Exception, IExceptionDetails
    {
        public AwExistsAlreadyException(string url) : base($"Website: {url} exists already")
        {
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