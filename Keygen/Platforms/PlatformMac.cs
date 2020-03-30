using System.Collections.Generic;

namespace FrappeMocha.Keygen.Platforms
{
    public class PlatformMac : KeygenBase
    {
        public PlatformMac()
        {
            Platform = "MacOSX";
            Products.Add(new KeygenProduct(LicenseTypes.Mac3270, "TN3270", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.Mac5250, "TN5250", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.Mac3812, "TN3812", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.MacTelnet, "Telnet", Platform));
            Products.Add(new KeygenProduct(LicenseTypes.MacKeyboard, "Keyboard", Platform));
        }

        public override List<string> GenerateLicencetypes(KeygenProduct p)
        {
            if (p.Licence != LicenseTypes.Mac3812 &&
                p.Licence != LicenseTypes.MacTelnet &&
                p.Licence != LicenseTypes.MacKeyboard)
            {
                return base.GenerateLicencetypes(p);
            }
            List<string> types = new List<string>();
            types.Add("0");
            return types;
        }

        public override string Generate(int type, string paramCompany, LicenseTypes license)
        {
            switch (license)
            {
                // Prefix Num
                case LicenseTypes.Mac3270:
                case LicenseTypes.Mac5250:
                    return GeneratePrefixNumber(type, paramCompany, license);
                
                // Prefix Alpha
                case LicenseTypes.Mac3812:
                case LicenseTypes.MacTelnet:
                case LicenseTypes.MacKeyboard:
                    return GeneratePrefixAlpha(type, paramCompany, license);
            }
            return "";
        }

        /**
         * @todo: write some sanity checks
         * I doubt I'll be able to get something straight outta da Ghidra here...
         */
        public override bool Check(string paramLicenseKey, string paramCompany, LicenseTypes license)
        {
            switch (license)
            {
                // Prefix Num
                case LicenseTypes.Mac3270:
                case LicenseTypes.Mac5250:
                    return true;

                // Prefix Alpha
                case LicenseTypes.Mac3812:
                case LicenseTypes.MacTelnet:
                case LicenseTypes.MacKeyboard:
                    return true;
            }
            return false;
        }


        /**
         * Now the fun stuff..
         * 
         * Beware! the PlatformMac versions rely on datatype truncation
         * It's a real pain in the ass to make sure the datatypes are all accurate
         */
        public string GeneratePrefixAlpha(int itype, string param_company, LicenseTypes license)
        {
            // must start with an 'a' or 'b;
            char type = (char)(itype + (int)'a');
            string param_lickey = type.ToString();
            ushort sum = 0;

            for (int b = 0; b < param_company.Length; b++)
            {
                if (param_company[b] >= 0x21)
                    sum += (ushort)(param_company[b] + license);
            }

            sum = (ushort)(sum * (short)param_lickey[0]);
            param_lickey += (ushort)((sum & byte.MaxValue) * sum);
            return param_lickey;
        }

        /**
         * Beware! the PlatformMac versions rely on datatype truncation
         * It's a real pain in the ass to make sure the datatypes are all accurate
         * 
         * There's a special case for the MacKeyboard as it deviates from the rest of the algoritm
         * The (byte) cast is extmely important
         */
        public string GeneratePrefixNumber(int itype, string param_company, LicenseTypes license)
        {
            char type = (char)(itype + (int)'0');
            string param_lickey = type.ToString();
            uint num1 = 0;
            byte[] byteArray = StrToByteArray(param_company);
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if (license == LicenseTypes.MacKeyboard && (byte)(byteArray[index] + 0xbf) < 0x1a)
                {
                    byteArray[index] += 32;
                }
                else if (license != LicenseTypes.MacKeyboard && byteArray[index] + 0xbf < 0x1a)
                {
                    byteArray[index] += 32;
                }
            }

            for (int index = 0; index < byteArray.Length; ++index)
            {
                if (byteArray[index] >= 0x41) // 'A'
                    num1 += byteArray[index] + (uint)license;
            }

            uint num2 = (uint)(num1 * (int)param_lickey[0]);
            num2 = (num2 * (num2 & byte.MaxValue) & ushort.MaxValue);
            ulong num3 = 0xaa8;
            if (99 < num2)
            {
                num3 = num2;
            }

            param_lickey = param_lickey[0].ToString() + num3;


            return param_lickey;
        }
    }
}