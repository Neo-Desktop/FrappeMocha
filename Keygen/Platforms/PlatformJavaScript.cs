using System;

namespace FrappeMocha.Keygen.Platforms
{
    public class PlatformJavaScript : KeygenBase
    {
        public PlatformJavaScript()
        {
            Platform = "Google Chrome";
            Products.Add(new KeygenProduct(LicenseTypes.JavaScript3270, "TN3270", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.JavaScript5250, "TN5250", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.JavaScriptTelnet, "Telnet", Platform));
        }

        /**
         * This one was fun as well
         * Found out that the license must end with "45" in order to validate
         */
        public override string Generate(int itype, string paramCompany, LicenseTypes license)
        {
            char type = (char)(itype + '0');
            string param_lickey = type.ToString();
            ulong sum = 0;
            byte[] byteArray = StrToByteArray(paramCompany);
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if (byteArray[index] >= 'A' && byteArray[index] <= 'Z')
                    byteArray[index] += 32; // ASCII 'Space'
            }

            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((ulong)byteArray[index] >= 'A' && (ulong)byteArray[index] <= 'z')
                {
                    sum += byteArray[index] + (uint)license;
                }
            }
            sum = sum * param_lickey[0];
            sum = sum * (sum & byte.MaxValue) & ushort.MaxValue;
            if (sum < 100U)
                sum = 2728U;

            param_lickey = (param_lickey[0].ToString() + sum) + '-' +
                           (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
                           + "45"; // a little salt, as a treat

            return param_lickey;
        }

        /**
         * Straight outta da JS
         */
        public override bool Check(string paramLicenseKey, string paramCompany, LicenseTypes license)
        {
            ulong sum = 0;
            byte[] byteArray = this.StrToByteArray(paramCompany);
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((ulong)byteArray[index] >= 65 && (ulong)byteArray[index] <= 90)
                    byteArray[index] += 32;
            }

            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((ulong)byteArray[index] >= 65 && (ulong)byteArray[index] <= 122)
                {
                    sum += byteArray[index] + (uint)license;
                }
            }
            sum = sum * paramLicenseKey[0];
            sum = sum * (sum & byte.MaxValue) & ushort.MaxValue;
            if (sum < 100U)
                sum = 2728U;

            if (!paramLicenseKey.StartsWith(paramLicenseKey[0].ToString() + sum) || !paramLicenseKey.EndsWith("45"))
            {
                return false;
            }

            return true;
        }
    }
}