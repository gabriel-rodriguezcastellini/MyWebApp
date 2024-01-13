using FastEndpoints;
using System.Text.Json;

namespace MyWebApp.PreProcessors
{
    public class RequestLogger : IGlobalPreProcessor
    {
        public Task PreProcessAsync(IPreProcessorContext context, CancellationToken ct)
        {
            _ = NewRelic.Api.Agent.NewRelic.GetAgent().CurrentTransaction.AddCustomAttribute("request", JsonSerializer.Serialize(context.Request));

            return Task.CompletedTask;
        }
    }
}
