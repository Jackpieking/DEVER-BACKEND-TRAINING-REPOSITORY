//middle ware:
//khai niem: nhung block code nam giua request va response de phan loai
//duong request va response:
//Request - Reponse pipeline

using FU_DEVER_BACKEND_TRAINING;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args: args);

//Service configurations.
var services = builder.Services;

//DbContext
services.AddDbContextPool<SchoolContext>(config =>
{
    config
        .UseNpgsql(
            builder
                .Configuration
                .GetRequiredSection("Database")
                .GetRequiredSection("ConnectionString")
                .Value)
        .EnableSensitiveDataLogging(true)
        .EnableDetailedErrors(true)
        .EnableServiceProviderCaching(true)
        .EnableThreadSafetyChecks(true);
});

//Controllers
services.AddControllers(config => config.SuppressAsyncSuffixInActionNames = false);

var app = builder.Build();

//Request - reponse pipeline
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();