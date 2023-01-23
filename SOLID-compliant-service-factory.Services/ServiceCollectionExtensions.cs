using Microsoft.Extensions.DependencyInjection;
using Safetica.Casb.O365LogService.Core;
using SOLID_compliant_service_factory.Services.AreaCalculators;
using SOLID_compliant_service_factory.Services.Parsers;

namespace SOLID_compliant_service_factory.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Parsers
            services.AddScoped<ICustomParser, ShapeParser>();

            // Area calculators
            var areaCalculatorFactoryBuilder = new AreaCalculatorFactoryBuilder(services)
                .RegisterCalculatorForType<TriangleAreaCalculator>(Shape.Triangle)
                .RegisterCalculatorForType<SquareAreaCalculator>(Shape.Square)
                .RegisterCalculatorForType<RectangleAreaCalculator>(Shape.Rectangle)
                .RegisterCalculatorForType<CircleAreaCalculator>(Shape.Circle);
            services.AddScoped(x => areaCalculatorFactoryBuilder.Build(x));
            return services;
        }
    }
}
