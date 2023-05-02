using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SDI_App.Errors
{
    public class TabletExistsAlreadyException : Exception, IExceptionDetails
    {
        private int ModelNumber;
        public TabletExistsAlreadyException(int modelNumber) : base($"Tablet with model number {modelNumber} already exists")
        {
            ModelNumber = modelNumber;
        }
        public ProblemDetails GetDetails()
        {
            return new ProblemDetails
            {
                Status = (int)HttpStatusCode.Forbidden,
                Type = "Tablet-exists-already",
                Title = "Tablet already exists",
                Detail = this.Message
            };
        }
    }
}