using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FrappeMocha.Keygen
{
    public abstract class KeygenBase
    {
        public const string CompanyLicense = "Company License";
        public const string SingleUserLicense = "Single User License";

        protected string Platform;
        protected int ByteEncoding = 0;
        public List<KeygenProduct> Products = new List<KeygenProduct>();

        public abstract string Generate(int type, string paramCompany, LicenseTypes license);
        public abstract bool Check(string paramLicenseKey, string paramCompany, LicenseTypes license);


        public virtual List<string> GenerateLicencetypes(KeygenProduct p)
        {
            List<string> licenses = new List<string>();
            licenses.Add(CompanyLicense);
            licenses.Add(SingleUserLicense);
            return licenses;
        }

        public override string ToString()
        {
            return Platform;
        }

        public byte[] StrToByteArray(string str)
        {
            try
            {
                return Encoding.GetEncoding(this.ByteEncoding).GetBytes(str);
            }
            catch (Exception)
            {
                try
                {
                    return Encoding.GetEncoding(0).GetBytes(str);
                }
                catch (Exception)
                {
                    return new byte[1] { (byte)63 };
                }
            }
        }

        public string ByteArrayToStr(byte[] barr, int index, int length)
        {
            try
            {
                return Encoding.GetEncoding(this.ByteEncoding).GetString(barr, index, length);
            }
            catch (Exception)
            {
                try
                {
                    return Encoding.GetEncoding(0).GetString(barr, index, length);
                }
                catch (Exception)
                {
                    return "?";
                }
            }
        }
    }
}