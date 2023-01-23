using System;

namespace SOLID_compliant_service_factory.Model
{
    public class AreaResult
    {
        public double Area { get; }

        public AreaResult(double area)
        {
            Area = Math.Round(area, 2);
        }
    }
}
