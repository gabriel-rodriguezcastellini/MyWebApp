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