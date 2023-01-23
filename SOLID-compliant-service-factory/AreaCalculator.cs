using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Safetica.Casb.O365LogService.Core;
using SOLID_compliant_service_factory.Model;
using SOLID_compliant_service_factory.Services.AreaCalculators;

namespace SOLID_compliant_service_factory
{
    public class AreaCalculator
    {
        private readonly IAreaCalculatorFactory _calculatorFactory;
        private readonly ILogger<AreaCalculator> _logger;

        public AreaCalculator(IAreaCalculatorFactory calculatorFactory, ILogger<AreaCalculator> log)
        {
            _calculatorFactory = calculatorFactory;
            _logger = log;
        }

        [FunctionName(nameof(AreaCalculator))]
        [OpenApiOperation(operationId: "Run", tags: new[] { "areaCalculator" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "shape", In = ParameterLocation.Path, Required = true, Type = typeof(string), Description = "The shape (circle, square, rectangle, or thriangle)")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(AreaResult), Description = "The area of the shape specified, rounded to 2 decimal places")]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "calculateArea/{shape}")] HttpRequest req,
            string shape,
            CancellationToken ct)
        {
            _logger.LogInformation("Executing area calculator for shape: {shape}", shape);

            if (!Enum.TryParse(shape, true, out Shape shapeType))
                return new BadRequestObjectResult($"{shape} shape not supported");

            var calculator = _calculatorFactory.GetAreaCalculatorForShape(shapeType);

            var result = await calculator.CalculateAreaAsync(req.Body, ct);

            return new OkObjectResult(new AreaResult(result));
        }
    }
}

