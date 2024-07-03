using System;
using System.Collections.Generic;

namespace Scada.services
{
    public class RealTimeDriver
    {
        Dictionary<string, double> rtus = new Dictionary<string, double>();

        public double getValue(string address)
        {
            if (rtus.TryGetValue(address, out double value))
            {
                return value;
            }
            return Double.NegativeInfinity;
        }

        public void setValue(string address, double value)
        {
            rtus[address] = value;
        }
    }
}