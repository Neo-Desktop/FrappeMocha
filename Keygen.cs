using System;
using System.Text;

namespace FrappeMocha
{
    public class Keygen
    {
        private int param_encoding;

        public enum LicenseTypes
        {
            License3270 = 140,
            License5250 = 128,
            License3812 = 160,
            LicenseTelnet = 155,
            LicenseJava3270 = 30,
            LicenseJava5250 = 30,
            LicenseJavaTelnet = 0x1b,
            LicenseMac3270 = 0x5d,
            LicenseMac5250 = 0x16,
        }

        public Keygen()
        {
            this.param_encoding = 0;
        }

        public bool CheckLicense(string param_lickey, string param_company, LicenseTypes license)
        {
            switch (license)
            {
                case LicenseTypes.License3270:
                case LicenseTypes.License3812:
                case LicenseTypes.License5250:
                case LicenseTypes.LicenseTelnet:
                    return CheckLicenseWindows(param_lickey, param_company, license);

                case LicenseTypes.LicenseJavaTelnet:
                case LicenseTypes.LicenseJava3270:
                // case LicenseTypes.LicenseJava5250:
                    return CheckLicenseJava(param_lickey, param_company, license);

                case LicenseTypes.LicenseMac3270:
                case LicenseTypes.LicenseMac5250:
                    return CheckLicenseMac(param_lickey, param_company, license);
            }
            return false;
        }

        public bool CheckLicenseJava(string param_lickey, string param_company, LicenseTypes license)
        {
            return true;
        }

        public bool CheckLicenseMac(string param_lickey, string param_company, LicenseTypes license)
        {
            return true;
        }

        public bool CheckLicenseWindows(string param_lickey, string param_company, LicenseTypes license)
        {
            uint num1 = 0;
            if (param_company == null || param_company.Length < 2)
                return false;
            byte[] byteArray = this.StrToByteArray(param_company);
            if (param_lickey == null || param_lickey.Length < 6)
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
            uint num2 = num1 * (uint)param_lickey[0];
            uint num3 = (uint)((int)num2 * ((int)num2 & (int)byte.MaxValue) & (int)ushort.MaxValue);
            if (num3 < 100U)
                num3 = 2728U;

            if (param_lickey.StartsWith((param_lickey[0].ToString() ?? "") + (object)num3))
            {
                //this.aa = param_lickey.Substring(0, 1);
                return true;
            }
            //this.aa = "";
            return false;
        }

        public string GenLicense(int type, string param_company, LicenseTypes license)
        {
            switch (license)
            {
                case LicenseTypes.License3270:
                case LicenseTypes.License3812:
                case LicenseTypes.License5250:
                case LicenseTypes.LicenseTelnet:
                    return GenLicenseWindows(type, param_company, license);

                case LicenseTypes.LicenseJavaTelnet:
                case LicenseTypes.LicenseJava3270:
                    // case LicenseTypes.LicenseJava5250:
                    return GenLicenseJava(type, param_company, license);

                case LicenseTypes.LicenseMac3270:
                case LicenseTypes.LicenseMac5250:
                    return GenLicenseMac(type, param_company, license);
            }
            return "";
        }

        public string GenLicenseWindows(int type, string param_company, LicenseTypes license)
        {
            string param_lickey = type.ToString();
            uint num1 = 0;
            byte[] byteArray = this.StrToByteArray(param_company);
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((int)byteArray[index] >= 65 && (int)byteArray[index] <= 90)
                    byteArray[index] += (byte)32; // this is basically str.toLower()
            }

            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((int)byteArray[index] >= 65) // 'A'
                    num1 += (uint)byteArray[index] + (uint)license;
            }
            uint num2 = num1 * (uint)param_lickey[0];
            uint num3 = (uint)((int)num2 * ((int)num2 & (int)byte.MaxValue) & (int)ushort.MaxValue);
            if (num3 < 100U)
                num3 = 2728U;

            param_lickey = ((param_lickey[0].ToString() ?? "") + (object)num3) + '-' +
                           (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;


            return param_lickey;
        }

        public string GenLicenseJava(int itype, string param_company, LicenseTypes license)
        {
            char type = (char)(itype + (int)'A');
            string param_lickey = type.ToString() + '@';
            byte[] byteArray = this.StrToByteArray(param_company);
            uint num1 = 0;

            for (int b = 0; b < byteArray.Length; b++)
            {
                if (param_company.ToCharArray()[b] > ' ')
                    num1 += param_company.ToCharArray()[b] + (uint)license;
            }

            uint num2 = num1 * (uint)param_lickey[0];
            uint num3 = (uint)((int)num2 * ((int)num2 & (int)byte.MaxValue) & (int)ushort.MaxValue);
            param_lickey += (object) num3;
            return param_lickey;
        }

        public string GenLicenseMac(int itype, string param_company, LicenseTypes license)
        {
            char type = (char)(itype + (int)'a');
            string param_lickey = type.ToString() + '@';
            byte[] byteArray = this.StrToByteArray(param_company);
            uint num1 = 0;

            for (int b = 0; b < byteArray.Length; b++)
            {
                if (param_company.ToCharArray()[b] > ' ')
                    num1 += param_company.ToCharArray()[b] + (uint)license;
            }

            uint num2 = num1 * (uint)param_lickey[0];
            uint num3 = (uint)((int)num2 * ((int)num2 & (int)byte.MaxValue) & (int)ushort.MaxValue);
            param_lickey += (object)num3;
            return param_lickey;
        }

        public byte[] StrToByteArray(string str)
        {
            try
            {
                return Encoding.GetEncoding(this.param_encoding).GetBytes(str);
            }
            catch (Exception ex1)
            {
                try
                {
                    return Encoding.GetEncoding(0).GetBytes(str);
                }
                catch (Exception ex2)
                {
                    return new byte[1] { (byte)63 };
                }
            }
        }

        public string ByteArrayToStr(byte[] barr, int index, int length)
        {
            try
            {
                return Encoding.GetEncoding(this.param_encoding).GetString(barr, index, length);
            }
            catch (Exception ex1)
            {
                try
                {
                    return Encoding.GetEncoding(0).GetString(barr, index, length);
                }
                catch (Exception ex2)
                {
                    return "?";
                }
            }
        }

    }
}