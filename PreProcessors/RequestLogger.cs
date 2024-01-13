using FastEndpoints;

namespace MyWebApp.PreProcessors
{
    public class RequestLogger : IGlobalPreProcessor
    {
        public async Task PreProcessAsync(IPreProcessorContext context, CancellationToken ct)
        {
            _ = context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            using StreamReader stream = new(context.HttpContext.Request.Body);
            _ = NewRelic.Api.Agent.NewRelic.GetAgent().CurrentTransaction.AddCustomAttribute("request.body", await stream.ReadToEndAsync(ct));
        }
    }
}
