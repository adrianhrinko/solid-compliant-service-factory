using SOLID_compliant_service_factory.Services.Models;
using SOLID_compliant_service_factory.Services.Parsers;

namespace SOLID_compliant_service_factory.Services.AreaCalculators
{
    public abstract class AreaCalculatorBase<TShape> : IAreaCalculatorService
    {
        private readonly ICustomParser _shapeParser;

        public AreaCalculatorBase(ICustomParser shapeParser)
        {
            _shapeParser = shapeParser;
        }

        private async Task<TShape> GetShapeAsync(Stream stream, CancellationToken ct) 
            => await _shapeParser.ParseJsonBodyAsync<TShape>(stream, ct);

        public async Task<double> CalculateAreaAsync(Stream stream, CancellationToken ct)
            => CalculateArea(await GetShapeAsync(stream, ct));

        protected abstract double CalculateArea(TShape shape);
    }
}
