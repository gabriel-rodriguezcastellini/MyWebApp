using FastEndpoints;
using FastEndpoints.Swagger;
using MyWebApp.PostProcessors;
using MyWebApp.PreProcessors; //add this

WebApplicationBuilder bld = WebApplication.CreateBuilder();

bld.Services
   .AddFastEndpoints()
   .SwaggerDocument(); //define a swagger document

WebApplication app = bld.Build();

app.UseFastEndpoints(c =>
{
    c.Endpoints.Configurator = ep =>
    {
        ep.PreProcessor<RequestLogger>(Order.Before);
        ep.PostProcessor<ResponseLogger>(Order.After);
    };
})
   .UseSwaggerGen(); //add this
app.Run();
