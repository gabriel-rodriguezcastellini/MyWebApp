using FastEndpoints;
using System.Text;

namespace MyWebApp.PostProcessors
{
    public class ResponseLogger : IGlobalPostProcessor
    {
        public async Task PostProcessAsync(IPostProcessorContext context, CancellationToken ct)
        {
            MemoryStream captureStream = new();

            _ = captureStream.Seek(0, SeekOrigin.Begin);
            using StreamReader reader = new(captureStream, Encoding.UTF8);
            _ = NewRelic.Api.Agent.NewRelic.GetAgent().CurrentTransaction.AddCustomAttribute("response.body", await reader.ReadToEndAsync(ct));
        }
    }
}
