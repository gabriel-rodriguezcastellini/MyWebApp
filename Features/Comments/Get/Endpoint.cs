using FastEndpoints;

namespace MyWebApp.Features.Comments.Get;

internal sealed class Endpoint : EndpointWithoutRequest<Response>
{
    public override void Configure()
    {
        Get("api/comments");
        AllowAnonymous();
        _ = Route<string>("CommentID", isRequired: false);
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        return SendOkAsync(new() { CommentID = "" }, ct);
    }
}