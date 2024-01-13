using FastEndpoints;
using System.Text.Json;

namespace MyWebApp.PostProcessors
{
    public class ResponseLogger : IGlobalPostProcessor
    {
        public Task PostProcessAsync(IPostProcessorContext context, CancellationToken ct)
        {
            _ = NewRelic.Api.Agent.NewRelic.GetAgent().CurrentTransaction.AddCustomAttribute("response", JsonSerializer.Serialize(context.Response));

            return Task.CompletedTask;
        }
    }
}
