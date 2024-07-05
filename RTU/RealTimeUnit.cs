using System;
using System.Security.Cryptography;
using System.Text;

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

        public byte[] SignMessage(string message, out byte[] hashValue)
        {
            using (SHA256 sha = SHA256.Create())
            {
                hashValue = sha.ComputeHash(Encoding.UTF8.GetBytes(message));
                CspParameters csp = new CspParameters
                {
                    KeyContainerName = "KeyContainer"
                };
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp))
                {
                    var formatter = new RSAPKCS1SignatureFormatter(rsa);
                    formatter.SetHashAlgorithm("SHA256");
                    return formatter.CreateSignature(hashValue);
                }
            }
        }
    }
}
