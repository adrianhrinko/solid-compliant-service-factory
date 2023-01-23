namespace SOLID_compliant_service_factory.Services.AreaCalculators
{
    public interface IAreaCalculatorService
    {
        /// <summary>
        /// Calculates area of the shape defined in JSON 
        /// </summary>
        /// <param name="stream">stream containing shape data in JSON format</param>
        /// <returns></returns>
        Task<double> CalculateAreaAsync(Stream stream, CancellationToken ct);
    }
}
