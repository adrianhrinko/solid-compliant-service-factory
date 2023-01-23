using Microsoft.Extensions.DependencyInjection;
using Safetica.Casb.O365LogService.Core;

namespace SOLID_compliant_service_factory.Services.AreaCalculators
{
    public class AreaCalculatorFactoryBuilder
    {
        private Dictionary<Shape, Type> _registeredCalculators;
        private readonly IServiceCollection _services;

        public AreaCalculatorFactoryBuilder(IServiceCollection services)
        {
            _registeredCalculators = new Dictionary<Shape, Type>();
            _services = services;
        }

        public AreaCalculatorFactoryBuilder RegisterCalculatorForType<TCalculator>(Shape shape)
            where TCalculator : IAreaCalculatorService
        {
            _services.AddScoped(typeof(TCalculator));
            _registeredCalculators.Add(shape, typeof(TCalculator));

            return this;
        }

        public IAreaCalculatorFactory Build(IServiceProvider serviceProvider)
        {
            return new AreaCalculatorFactory(serviceProvider, _registeredCalculators);
        }
    }
}
