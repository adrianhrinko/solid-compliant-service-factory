using SOLID_compliant_service_factory.Services.Models;
using SOLID_compliant_service_factory.Services.Parsers;

namespace SOLID_compliant_service_factory.Services.AreaCalculators
{
    public class TriangleAreaCalculator : AreaCalculatorBase<Triangle>
    {
        public TriangleAreaCalculator(ICustomParser shapeParser) : base(shapeParser) {}

        protected override double CalculateArea(Triangle triangle)
            => (triangle.A * triangle.B * Math.Sin(triangle.Alpha)) / 2;
    }
}
