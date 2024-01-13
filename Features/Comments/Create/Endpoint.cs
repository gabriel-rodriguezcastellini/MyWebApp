using FastEndpoints;

namespace MyWebApp.Features.Comments.Create;

internal sealed class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Post("api/comments");
        AllowAnonymous();
    }

    public override Task HandleAsync(Request req, CancellationToken ct)
    {
        return SendOkAsync(ct);
    }
}