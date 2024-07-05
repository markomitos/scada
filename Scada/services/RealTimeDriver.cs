using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Scada.services
{
    public class RealTimeDriver
    {
        static Dictionary<string, double>  rtus = new Dictionary<string, double>();

        public static double getValue(string address)
        {
            if (rtus.TryGetValue(address, out double value))
            {
                return value;
            }
            return Double.NegativeInfinity;
        }

        public static void setValue(string address, double value)
        {
            rtus[address] = value;
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