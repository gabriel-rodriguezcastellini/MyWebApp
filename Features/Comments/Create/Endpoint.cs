using FastEndpoints;

namespace MyWebApp.Features.Comments.Create;

internal sealed class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("api/comments");
        AllowAnonymous();
    }

    public override Task HandleAsync(Request req, CancellationToken ct)
    {
        return SendOkAsync(new()
        {
            FullName = req.FirstName + " " + req.LastName,
            IsOver18 = req.Age > 18
        }, ct);
    }
}