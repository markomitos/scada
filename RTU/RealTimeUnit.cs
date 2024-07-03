using System;

namespace RTU
{
    public class RealTimeUnit
    {
        public string DriverAddress { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }

        public RealTimeUnit(string address, double lowLimit, double highLimit)
        {
            DriverAddress = address;
            LowLimit = lowLimit;
            HighLimit = highLimit;
        }

        public double GenerateValue()
        {
            return new Random().NextDouble() * (HighLimit - LowLimit) + LowLimit;
        }
    }
}