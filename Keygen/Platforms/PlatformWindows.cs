using System;

namespace FrappeMocha.Keygen.Platforms
{
    public class PlatformWindows : KeygenBase
    {
        public PlatformWindows()
        {
            Platform = "Windows";
            Products.Add(new KeygenProduct(LicenseTypes.Windows3270, "TN3270", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.Windows5250, "TN5250", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.Windows3812, "TN3812", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.WindowsTelnet, "Telnet", Platform));
        }
        
        public override string Generate(int type, string paramCompany, LicenseTypes license)
        {
            string licenseKey = type.ToString();
            uint sum = 0;
            byte[] byteArray = StrToByteArray(paramCompany);
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if (byteArray[index] >= 'A' && byteArray[index] <= 'Z')
                    byteArray[index] += 32; // ASCII 'Space'
            }

            for (int index = 0; index < byteArray.Length; ++index)
            {
                if (byteArray[index] >= 'A')
                    sum += byteArray[index] + (uint)license;
            }
            sum = sum * licenseKey[0];
            sum = (uint)((int)sum * ((int)sum & byte.MaxValue) & ushort.MaxValue);
            if (sum < 100U)
                sum = 2728U;

            licenseKey = (licenseKey[0].ToString() + sum) + '-' +
                           (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;


            return licenseKey;
        }

        /**
         * Straight outta da Assembley
         */
        public override bool Check(string paramLicenseKey, string paramCompany, LicenseTypes license)
        {
            uint num1 = 0;
            if (paramCompany == null || paramCompany.Length < 2)
                return false;
            byte[] byteArray = this.StrToByteArray(paramCompany);
            if (paramLicenseKey == null || paramLicenseKey.Length < 6)
                return false;

            for (int index = 0; index < byteArray.Length; ++index)
            {
                // >= 'A' && <= 'Z'
                if ((int)byteArray[index] >= 65 && (int)byteArray[index] <= 90)
                    byteArray[index] += (byte)32;
            }
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((int)byteArray[index] >= 65) // 'A'
                    num1 += (uint)byteArray[index] + (uint)license;
            }
            uint num2 = num1 * (uint)paramLicenseKey[0];
            uint num3 = (uint)((int)num2 * ((int)num2 & (int)byte.MaxValue) & (int)ushort.MaxValue);
            if (num3 < 100U)
                num3 = 2728U;

            if (paramLicenseKey.StartsWith((paramLicenseKey[0].ToString() ?? "") + (object)num3))
            {
                //this.aa = param_lickey.Substring(0, 1);
                return true;
            }
            //this.aa = "";
            return false;
        }
    }
}