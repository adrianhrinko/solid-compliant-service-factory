using System.Text.Json.Serialization;

namespace SOLID_compliant_service_factory.Services.Models
{
    public class Rectangle
    {
        public double A { get; }
        public double B { get; }
        public Rectangle(double a, double b)
        {
            A = a;
            B = b;
        }
    }
}
