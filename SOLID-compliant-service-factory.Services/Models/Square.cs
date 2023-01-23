using System.Text.Json.Serialization;

namespace SOLID_compliant_service_factory.Services.Models
{
    public class Square
    {
        public double A { get; }
        public Square(double a)
        {
            A = a;
        }
    }
}
