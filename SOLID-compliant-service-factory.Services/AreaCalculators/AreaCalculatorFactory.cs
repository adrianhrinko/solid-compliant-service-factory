using Microsoft.Extensions.DependencyInjection;
using Safetica.Casb.O365LogService.Core;

namespace SOLID_compliant_service_factory.Services.AreaCalculators
{
    public class AreaCalculatorFactory : IAreaCalculatorFactory
    {
        private Dictionary<Shape, Type> _registeredCalculators;

        private readonly IServiceProvider _serviceProvider;

        public AreaCalculatorFactory(IServiceProvider serviceProvider, Dictionary<Shape, Type> registeredCalculators)
        {
            _registeredCalculators = registeredCalculators;
            _serviceProvider = serviceProvider;
        }

        public IAreaCalculatorService GetAreaCalculatorForShape(Shape shape)
        {
            if (!_registeredCalculators.TryGetValue(shape, out var calculatorType) || calculatorType == null)
                throw new InvalidOperationException($"No calculator registered for shape {shape}");

            return (IAreaCalculatorService)_serviceProvider.GetRequiredService(calculatorType);
        }
    }
}
