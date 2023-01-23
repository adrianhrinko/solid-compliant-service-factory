using SOLID_compliant_service_factory.Services.Models;
using SOLID_compliant_service_factory.Services.Parsers;

namespace SOLID_compliant_service_factory.Services.AreaCalculators
{
    public class CircleAreaCalculator : AreaCalculatorBase<Circle>
    {
        public CircleAreaCalculator(ICustomParser shapeParser) : base(shapeParser) { }

        protected override double CalculateArea(Circle circle)
            => Math.Pow(circle.R, 2) * Math.PI;
    }
}
