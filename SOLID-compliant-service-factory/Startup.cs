using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(SOLID_compliant_service_factory.Startup))]
namespace SOLID_compliant_service_factory
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddFunctionServices(builder.GetContext().Configuration);
        }
    }
}
