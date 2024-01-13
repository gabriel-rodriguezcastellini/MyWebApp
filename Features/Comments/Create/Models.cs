using FastEndpoints;

namespace MyWebApp.Features.Comments.Create;

internal sealed class Request
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int Age { get; set; }
}

internal sealed class Validator : Validator<Request>
{
    public Validator()
    {

    }
}

internal sealed class Response
{
    public required string FullName { get; set; }
    public bool IsOver18 { get; set; }
}
