using System;

namespace FrappeMocha.Keygen.Platforms
{
    public class PlatformAndroid : KeygenBase
    {
        public PlatformAndroid()
        {
            Platform = "Android";
            Products.Add(new KeygenProduct(LicenseTypes.Android3270, "TN3270", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.Android5250, "TN5250", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.AndroidTelnet, "TN3812", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.AndroidVnc, "VNC", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.AndroidBarcode, "Barcode", Platform));
        }

        /**
         * This was also a piece of cake since PlatformJava is the underlying tech on PlatformAndroid
         * The Dex object engine keept pretty good tabs on the types and var names as well!
         */
        public override string Generate(int itype, string paramCompany, LicenseTypes license)
        {
            char type = (char)(itype + '0');
            string paramLicencekey = type.ToString();
            long sum = 0;
            byte[] byteArray = StrToByteArray(paramCompany);
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((long)byteArray[index] >= 'A' && (long)byteArray[index] <= 'Z')
                    byteArray[index] += 32; // this is basically str.toLower()
            }

            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((ulong)byteArray[index] >= 'A' && (ulong)byteArray[index] <= 'z')
                {
                    sum += byteArray[index] + (uint)license;
                }
            }
            sum = sum * paramLicencekey[0];
            sum = sum * (sum & byte.MaxValue) & ushort.MaxValue;
            if (sum < 100U)
                sum = 2728U;

            paramLicencekey = (paramLicencekey[0].ToString() + sum) + '-' +
                           (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            return paramLicencekey;
        }

        /**
         * Straight outta da Dex
         */
        public override bool Check(string paramLicenseKey, string paramCompany, LicenseTypes license)
        {
            byte[] bArr = new byte[255];
            byte[] bArr2 = new byte[255];
            if (paramCompany.Length < 2 || paramLicenseKey.Length < 2)
            {
                return false;
            }
            for (int i = 0; i < paramLicenseKey.Length; i++)
            {
                bArr2[i] = (byte)paramLicenseKey[i];
            }
            for (int i2 = 0; i2 < paramCompany.Length; i2++)
            {
                bArr[i2] = (byte)paramCompany[i2];
                if (paramCompany[i2] >= 'A' && paramCompany[i2] <= 'Z')
                {
                    bArr[i2] = (byte)(bArr[i2] + 32);
                }
            }
            long j = 0;
            for (int i3 = 0; i3 < paramCompany.Length; i3++)
            {
                if (bArr[i3] >= 65 && bArr[i3] <= 122)
                {
                    j += (bArr[i3] + (long)license);
                }
            }
            long j2 = j * bArr2[0];
            long j3 = (j2 * (j2 & 255)) & 65535;
            if (j3 < 100)
            {
                j3 = 2728;
            }
            string sb = "";
            sb += paramLicenseKey[0];
            sb += (object)j3;
            if (paramLicenseKey.StartsWith(sb))
            {
                // lictype = bArr2[0] - 48;
                // is_lite2 = false;
                return true;
            }
            // lictype = -1;
            return false;
        }
    }
}