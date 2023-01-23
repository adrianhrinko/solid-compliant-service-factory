using System.Text.Json.Serialization;

namespace SOLID_compliant_service_factory.Services.Models
{
    public class Triangle
    {
        public double A { get; }
        public double B { get; }
        public double Alpha { get; }

        public Triangle(double a, double b, double alpha)
        {
            A = a;
            B = b;
            Alpha = alpha;
        }
    }
}
