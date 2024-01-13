using FastEndpoints;

namespace MyWebApp.Features.Comments.Get;

internal sealed class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("api/comments");
        AllowAnonymous();
        _ = Route<string>("CommentID", isRequired: false);
    }

    public override Task HandleAsync(Request req, CancellationToken ct)
    {
        return SendOkAsync(new()
        {
            CommentID = req.CommentID
        }, ct);
    }
}