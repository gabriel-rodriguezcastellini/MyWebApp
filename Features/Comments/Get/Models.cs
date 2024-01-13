using FastEndpoints;

namespace MyWebApp.Features.Comments.Get;

internal sealed class Request
{
    public string? CommentID { get; set; }
}

internal sealed class Validator : Validator<Request>
{
    public Validator()
    {

    }
}

internal sealed class Response
{
    public string? CommentID { get; set; }
}
