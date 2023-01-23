
using Microsoft.AspNetCore.Http;

namespace SOLID_compliant_service_factory.Services.Parsers
{
    public interface ICustomParser
    {
        /// <summary>
        /// Parses JSON body according the generic type parameter specified.
        /// </summary>
        /// <typeparam name="T">the deserialized type</typeparam>
        /// <param name="stream">stream containing json to be deserialized</param>
        /// <param name="ct">cancellation token</param>
        /// <returns>deserialized type</returns>
        Task<T> ParseJsonBodyAsync<T>(Stream stream, CancellationToken ct = default);
    }
}
