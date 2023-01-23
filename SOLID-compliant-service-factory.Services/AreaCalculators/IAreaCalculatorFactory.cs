using Safetica.Casb.O365LogService.Core;

namespace SOLID_compliant_service_factory.Services.AreaCalculators
{
    public interface IAreaCalculatorFactory
    {
        /// <summary>
        /// Factory method that provides area calculator for the given shape.
        /// </summary>
        /// <param name="shape">Shape for which the area calculator service will be provided</param>
        /// <returns>AreaCalculator for given shape</returns>
        /// <exception cref="InvalidOperationException">thrown in the case there is no area calculator registered for the given shape</exception>
        public IAreaCalculatorService GetAreaCalculatorForShape(Shape shape);
    }
}