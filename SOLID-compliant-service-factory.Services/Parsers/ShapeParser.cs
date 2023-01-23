using System.Text.Json;

namespace SOLID_compliant_service_factory.Services.Parsers
{
    public class ShapeParser : ICustomParser
    {
        private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public async Task<T> ParseJsonBodyAsync<T>(Stream stream, CancellationToken ct = default)
        {
            T? val = await JsonSerializer.DeserializeAsync<T>(stream, SerializerOptions, ct);
            if (val == null)
            {
                throw new JsonException("Null payload");
            }

            return val;
        }
    }
}
