using SOLID_compliant_service_factory.Services.Models;
using SOLID_compliant_service_factory.Services.Parsers;

namespace SOLID_compliant_service_factory.Services.AreaCalculators
{
    public class SquareAreaCalculator : AreaCalculatorBase<Square>
    {
        public SquareAreaCalculator(ICustomParser shapeParser) : base(shapeParser) {}

        protected override double CalculateArea(Square square) 
            => Math.Pow(square.A, 2);
    }
}
