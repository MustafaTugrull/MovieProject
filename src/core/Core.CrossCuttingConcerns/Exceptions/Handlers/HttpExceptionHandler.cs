using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.CrossCuttingConcerns.Exceptions.HtppProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers;

public sealed class HttpExceptionHandler : ExceptionHandler
{
    private HttpResponse response;
    //public HttpResponse Response
    //{
    //    get => response ?? throw new ArgumentNullException(nameof(response));

    //    set => response = value;

    //}

    public HttpResponse Response { get; set; }

    protected override Task HandleException(NotFoundException notFoundException)
    {
        response.StatusCode = StatusCodes.Status404NotFound;
        NotFoundProblemDetails problem = new NotFoundProblemDetails(notFoundException.Message);
        string details = JsonSerializer.Serialize(problem);

        return Response.WriteAsync(details);
    }

    protected override Task HandleException(BusinessException businessException)
    {
        response.StatusCode = StatusCodes.Status404NotFound;
        string details = new BusinessProblemDetails(businessException.Message).AsJson();
        return Response.WriteAsync(details);
    }

    protected override Task HandleException(Exception exception)
    {
        response.StatusCode = StatusCodes.Status500InternalServerError;
        string details = new ServerErrorProblemDetails().AsJson();
        return Response.WriteAsync(details);
    }
}
