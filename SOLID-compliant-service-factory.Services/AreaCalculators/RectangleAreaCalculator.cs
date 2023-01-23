using SOLID_compliant_service_factory.Services.Models;
using SOLID_compliant_service_factory.Services.Parsers;

namespace SOLID_compliant_service_factory.Services.AreaCalculators
{
    public class RectangleAreaCalculator : AreaCalculatorBase<Rectangle>
    {
        public RectangleAreaCalculator(ICustomParser shapeParser) : base(shapeParser) {}

        protected override double CalculateArea(Rectangle rectangle) 
            => rectangle.A * rectangle.B;
    }
}
