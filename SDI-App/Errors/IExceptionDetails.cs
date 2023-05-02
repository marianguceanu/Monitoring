using Microsoft.AspNetCore.Mvc;

namespace SDI_App.Errors
{
    public interface IExceptionDetails
    {
        ProblemDetails GetDetails();
    }
}