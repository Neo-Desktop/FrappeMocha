using System;
using System.Text;

namespace FrappeMocha
{
    public class Keygen
    {
        private int param_encoding;

        public enum LicenseTypes
        {
            LicenseWindows3270 = 0x8c,
            LicenseWindows5250 = 0x80,
            LicenseWindows3812 = 0xa0,
            LicenseWindowsTelnet = 0x9b,
            LicenseJava3270 = 0x1e,
            LicenseJava5250 = 0x1e,
            LicenseJavaTelnet = 0x1b,
            LicenseMac3270 = 0x5d,
            LicenseMac5250 = 0x16,
            LicenseMac3812 = 0x22,
            LicenseMacTelnet = 0x5e,
            LicenseMacKeyboard = 0xa5,
            LicenseChrome3270 = 0xb3,
            LicenseChrome5250 = 0xb2,
            LicenseChromeTelnet = 0xb4,
            LicenseAndroid3270 = 0x94,
            LicenseAndroid5250 = 0x91,
            LicenseAndroidTelnet = 0x96,
            LicenseAndroidVnc = 0x92,
            LicenseAndroidBarcode = 0x9c,
        }

        public Keygen()
        {
            this.param_encoding = 0;
        }


        public string GenLicense(int type, string param_company, LicenseTypes license)
        {
            switch (license)
            {
                case LicenseTypes.LicenseWindows3270:
                case LicenseTypes.LicenseWindows3812:
                case LicenseTypes.LicenseWindows5250:
                case LicenseTypes.LicenseWindowsTelnet:
                    return GenLicenseWindows(type, param_company, license);

                case LicenseTypes.LicenseJavaTelnet:
                case LicenseTypes.LicenseJava3270:
                    // case LicenseTypes.LicenseJava5250:
                    return GenLicenseJava(type, param_company, license);

                case LicenseTypes.LicenseMac3270:
                case LicenseTypes.LicenseMac5250:
                    return GenLicenseMacAlpha(type, param_company, license);

                case LicenseTypes.LicenseMac3812:
                case LicenseTypes.LicenseMacTelnet:
                case LicenseTypes.LicenseMacKeyboard:
                    return GenLicenseMacNum(type, param_company, license);

                case LicenseTypes.LicenseChrome3270:
                case LicenseTypes.LicenseChrome5250:
                case LicenseTypes.LicenseChromeTelnet:
                    return GenLicenseJavascript(type, param_company, license);

                case LicenseTypes.LicenseAndroid3270:
                case LicenseTypes.LicenseAndroid5250:
                case LicenseTypes.LicenseAndroidTelnet:
                case LicenseTypes.LicenseAndroidVnc:
                case LicenseTypes.LicenseAndroidBarcode:
                    return GenLicenseAndroid(type, param_company, license);
            }
            return "";
        }

        /**
         * By far the easiest implemntation, everything was already in .NET :P
         */
        public string GenLicenseWindows(int type, string param_company, LicenseTypes license)
        {
            string param_lickey = type.ToString();
            uint num1 = 0;
            byte[] byteArray = this.StrToByteArray(param_company);
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((int) byteArray[index] >= 65 && (int) byteArray[index] <= 90)
                    byteArray[index] += (byte) 32; // this is basically str.toLower()
            }

            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((int) byteArray[index] >= 65) // 'A'
                    num1 += (uint) byteArray[index] + (uint) license;
            }
            uint num2 = num1 * (uint) param_lickey[0];
            uint num3 = (uint) ((int) num2 * ((int) num2 & (int) byte.MaxValue) & (int) ushort.MaxValue);
            if (num3 < 100U)
                num3 = 2728U;

            param_lickey = (param_lickey[0].ToString() + (object) num3) + '-' +
                           (Int32) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;


            return param_lickey;
        }

        /**
         * Pretty stright forward implementation as well
         * .NET is just a copy of Java afterall
         */
        public string GenLicenseJava(int itype, string param_company, LicenseTypes license)
        {
            char type = (char) (itype + (int) 'A');
            string param_lickey = type.ToString() + '@';
            byte[] byteArray = this.StrToByteArray(param_company);
            uint num1 = 0;

            for (int b = 0; b < byteArray.Length; b++)
            {
                if (param_company.ToCharArray()[b] > ' ')
                    num1 += param_company.ToCharArray()[b] + (uint) license;
            }

            uint num2 = num1 * (uint) param_lickey[0];
            uint num3 = (uint) ((int) num2 * ((int) num2 & (int) byte.MaxValue) & (int) ushort.MaxValue);
            param_lickey += (object) num3;
            return param_lickey;
        }

        /**
         * Now the fun stuff..
         * 
         * Beware! the Mac versions rely on datatype truncation
         * It's a real pain in the ass to make sure the datatypes are all accurate
         */
        public string GenLicenseMacAlpha(int itype, string param_company, LicenseTypes license)
        {
            // must start with an 'a' or 'b;
            char type = (char) (itype + (int) 'a');
            string param_lickey = type.ToString();
            byte[] byteArray = this.StrToByteArray(param_company);
            short num1 = 0;

            for (int b = 0; b < byteArray.Length; b++)
            {
                if (param_company.ToCharArray()[b] >= 0x21)
                    num1 += (short) (param_company.ToCharArray()[b] + license);
            }

            ushort num2 = (ushort) (num1 * (short) param_lickey[0]);
            param_lickey += (ushort) ((num2 & byte.MaxValue) * num2);
            return param_lickey;
        }

        /**
         * Beware! the Mac versions rely on datatype truncation
         * It's a real pain in the ass to make sure the datatypes are all accurate
         * 
         * There's a special case for the MacKeyboard as it deviates from the rest of the algoritm
         * The (byte) cast is extmely important
         */
        public string GenLicenseMacNum(int itype, string param_company, LicenseTypes license)
        {
            char type = (char) (itype + (int) '0');
            string param_lickey = type.ToString();
            uint num1 = 0;
            byte[] byteArray = this.StrToByteArray(param_company);
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if (license == LicenseTypes.LicenseMacKeyboard && (byte) (byteArray[index] + 0xbf) < 0x1a)
                {
                    byteArray[index] += 32;
                }
                else if (license != LicenseTypes.LicenseMacKeyboard && byteArray[index] + 0xbf < 0x1a)
                {
                    byteArray[index] += 32;
                }
            }

            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((int) byteArray[index] >= 0x41) // 'A'
                    num1 += (uint) byteArray[index] + (uint) license;
            }

            uint num2 = (uint) (num1 * (int) param_lickey[0]);
            num2 = (uint) (num2 * (num2 & byte.MaxValue) & ushort.MaxValue);
            ulong num3 = 0xaa8;
            if (99 < num2)
            {
                num3 = (ulong) num2;
            }

            param_lickey = param_lickey[0].ToString() + (object) num3;


            return param_lickey;
        }

        /**
         * This one was fun as well
         * Found out that the license must end with "45" in order to validate
         */
        public string GenLicenseJavascript(int itype, string param_company, LicenseTypes license)
        {
            char type = (char) (itype + (int) '0');
            string param_lickey = type.ToString();
            ulong sum = 0;
            byte[] byteArray = this.StrToByteArray(param_company);
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((ulong) byteArray[index] >= 65 && (ulong) byteArray[index] <= 90)
                    byteArray[index] += 32; // this is basically str.toLower()
            }

            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((ulong) byteArray[index] >= 65 && (ulong) byteArray[index] <= 122)
                {
                    sum += byteArray[index] + (uint) license;
                }
            }
            sum = sum * param_lickey[0];
            sum = sum * (sum & byte.MaxValue) & ushort.MaxValue;
            if (sum < 100U)
                sum = 2728U;

            param_lickey = (param_lickey[0].ToString() + (object) sum) + '-' +
                           (Int32) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
                           + "45"; // a little salt, as a treat

            return param_lickey;
        }


        public string GenLicenseAndroid(int itype, string param_company, LicenseTypes license)
        {
            char type = (char) (itype + (int) '0');
            string param_lickey = type.ToString();
            long sum = 0;
            byte[] byteArray = this.StrToByteArray(param_company);
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((long) byteArray[index] >= 65 && (long) byteArray[index] <= 90)
                    byteArray[index] += 32; // this is basically str.toLower()
            }

            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((ulong) byteArray[index] >= 65 && (ulong) byteArray[index] <= 122)
                {
                    sum += byteArray[index] + (uint) license;
                }
            }
            sum = sum * param_lickey[0];
            sum = sum * (sum & byte.MaxValue) & ushort.MaxValue;
            if (sum < 100U)
                sum = 2728U;

            param_lickey = (param_lickey[0].ToString() + (object) sum) + '-' +
                           (Int32) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            return param_lickey;
        }


        public bool CheckLicense(string param_lickey, string param_company, LicenseTypes license)
        {
            switch (license)
            {
                case LicenseTypes.LicenseWindows3270:
                case LicenseTypes.LicenseWindows3812:
                case LicenseTypes.LicenseWindows5250:
                case LicenseTypes.LicenseWindowsTelnet:
                    return CheckLicenseWindows(param_lickey, param_company, license);

                case LicenseTypes.LicenseJavaTelnet:
                case LicenseTypes.LicenseJava3270:
                    // case LicenseTypes.LicenseJava5250:
                    return CheckLicenseJava(param_lickey, param_company, license);

                case LicenseTypes.LicenseMac3270:
                case LicenseTypes.LicenseMac5250:
                case LicenseTypes.LicenseMac3812:
                case LicenseTypes.LicenseMacTelnet:
                case LicenseTypes.LicenseMacKeyboard:
                    return CheckLicenseMac(param_lickey, param_company, license);

                case LicenseTypes.LicenseChrome3270:
                case LicenseTypes.LicenseChrome5250:
                case LicenseTypes.LicenseChromeTelnet:
                    return CheckLicenseJavaScript(param_lickey, param_company, license);

                case LicenseTypes.LicenseAndroid3270:
                case LicenseTypes.LicenseAndroid5250:
                case LicenseTypes.LicenseAndroidTelnet:
                case LicenseTypes.LicenseAndroidVnc:
                case LicenseTypes.LicenseAndroidBarcode:
                    return CheckLicenseAndroid(param_lickey, param_company, license);
            }
            return false;
        }

        /**
         * @todo: write some sanity checks
         */
        public bool CheckLicenseAndroid(string param_lickey, string param_company, LicenseTypes license)
        {
            byte[] bArr = new byte[255];
            byte[] bArr2 = new byte[255];
            if (param_company.Length < 2 || param_lickey.Length < 2)
            {
                return false;
            }
            for (int i = 0; i < param_lickey.Length; i++)
            {
                bArr2[i] = (byte) param_lickey[i];
            }
            for (int i2 = 0; i2 < param_company.Length; i2++)
            {
                bArr[i2] = (byte) param_company[i2];
                if (param_company[i2] >= 'A' && param_company[i2] <= 'Z')
                {
                    bArr[i2] = (byte) (bArr[i2] + 32);
                }
            }
            long j = 0;
            for (int i3 = 0; i3 < param_company.Length; i3++)
            {
                if (bArr[i3] >= 65 && bArr[i3] <= 122)
                {
                    j += (bArr[i3] + (long) license);
                }
            }
            long j2 = j * bArr2[0];
            long j3 = (j2 * (j2 & 255)) & 65535;
            if (j3 < 100)
            {
                j3 = 2728;
            }
            string sb = "";
            sb += param_lickey[0];
            sb += (object) j3;
            if (param_lickey.StartsWith(sb))
            {
                // lictype = bArr2[0] - 48;
                // is_lite2 = false;
                return true;
            }
            // lictype = -1;
            return false;
        }

        /**
         * All Javascript licenses need to end with "45" in order to validate
         */
        public bool CheckLicenseJavaScript(string param_lickey, string param_company, LicenseTypes license)
        {
            ulong sum = 0;
            byte[] byteArray = this.StrToByteArray(param_company);
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((ulong) byteArray[index] >= 65 && (ulong) byteArray[index] <= 90)
                    byteArray[index] += 32; // this is basically str.toLower()
            }

            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((ulong) byteArray[index] >= 65 && (ulong) byteArray[index] <= 122)
                {
                    sum += byteArray[index] + (uint) license;
                }
            }
            sum = sum * param_lickey[0];
            sum = sum * (sum & byte.MaxValue) & ushort.MaxValue;
            if (sum < 100U)
                sum = 2728U;

            if (!param_lickey.StartsWith(param_lickey[0].ToString() + (object) sum) || !param_lickey.EndsWith("45"))
            {
                return false;
            }

            return true;
        }


        /**
         * @todo: write some sanity checks
         */
        public bool CheckLicenseJava(string param_lickey, string param_company, LicenseTypes license)
        {
            return true;
        }


        /**
         * @todo: write some sanity checks
         */
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
                if ((int) byteArray[index] >= 65 && (int) byteArray[index] <= 90)
                    byteArray[index] += (byte) 32;
            }
            for (int index = 0; index < byteArray.Length; ++index)
            {
                if ((int) byteArray[index] >= 65) // 'A'
                    num1 += (uint) byteArray[index] + (uint) license;
            }
            uint num2 = num1 * (uint) param_lickey[0];
            uint num3 = (uint) ((int) num2 * ((int) num2 & (int) byte.MaxValue) & (int) ushort.MaxValue);
            if (num3 < 100U)
                num3 = 2728U;

            if (param_lickey.StartsWith((param_lickey[0].ToString() ?? "") + (object) num3))
            {
                //this.aa = param_lickey.Substring(0, 1);
                return true;
            }
            //this.aa = "";
            return false;
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
                    return new byte[1] {(byte) 63};
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