using System.Collections.Generic;

namespace FrappeMocha.Keygen.Platforms
{
    public class PlatformJava : KeygenBase
    {
        public PlatformJava()
        {
            Platform = "Java";
            Products.Add(new KeygenProduct(LicenseTypes.Java3270, "TN3270", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.Java5250, "TN5250", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.JavaTelnet, "Telnet", Platform));
        }

        public override List<string> GenerateLicencetypes(KeygenProduct p)
        {
            List<string> types = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                types.Add(((char)(i + 'A')).ToString());
            }
            return types;
        }

        /**
         * Pretty stright forward implementation as well
         * .NET is just a copy of PlatformJava afterall
         */
        public override string Generate(int itype, string paramCompany, LicenseTypes license)
        {
            char type = (char)(itype + 'A');
            string paramLicencekey = type.ToString() + '@';
            int sum = 0;

            int i = 0;
            while (i < paramCompany.Length)
            {
                if (paramCompany[i] > ' ')
                {
                    // 3270 and 5250 have a hardcoded 0x1b+2 here, we've just added it to the enum
                    sum += paramCompany[i] + (int)license;
                }
                ++i;
            }

            sum = sum * paramLicencekey[0];
            sum = sum * (sum & byte.MaxValue) & ushort.MaxValue;
            paramLicencekey += sum.ToString();
            return paramLicencekey;
        }

        /**
         * Straight outta da JAR
         */
        public override bool Check(string paramLicenseKey, string paramCompany, LicenseTypes license)
        {
            int i = 0;
            int n = 0;
            while (i < paramCompany.Length)
            {
                if (paramCompany[i] > ' ')
                {
                    // 3270 and 5250 have a hardcoded 0x1b+2 here, we've just added it to the enum
                    n += paramCompany[i] + (int)license;
                }
                ++i;
            }
            if (paramLicenseKey.Length > 0)
            {
                switch (paramLicenseKey[0])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'E':
                        break;

                    default:
                        return false;
                }
                int n2 = n * paramLicenseKey[0];
                n2 = n2 * (n2 & 0xFF) & 0xFFFF;

                string check = paramLicenseKey[0].ToString() + paramLicenseKey[1].ToString() + n2.ToString();
                if (paramLicenseKey[1] == '@' && check == paramLicenseKey)
                {
                    return true;
                }
            }
            return false;
        }
    }
}