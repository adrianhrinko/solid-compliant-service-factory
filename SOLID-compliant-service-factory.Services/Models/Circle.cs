using System.Text.Json.Serialization;

namespace SOLID_compliant_service_factory.Services.Models
{
    public class Circle
    {
        public double R { get; }
        public Circle(double r)
        {
            R = r;
        }
    }
}
