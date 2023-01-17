using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Soma.Domain.Exceptions;

namespace Soma.Api.Filters;

public class NotFoundExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is NotFoundException)
            context.Result = new NotFoundResult();
    }
}