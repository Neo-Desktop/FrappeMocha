using System.Collections.Generic;

namespace FrappeMocha.Keygen
{
    public class KeygenProduct
    {
        public LicenseTypes Licence;
        public string Description;

        public KeygenProduct(LicenseTypes licence, string description, string platform)
        {
            Licence = licence;
            Description = description + " for " + platform;
        }

        public override string ToString()
        {
            return Description;
        }

        public override bool Equals(object obj)
        {
            return obj is KeygenProduct product && Description == product.Description || 
                   obj is string description && description == Description;
        }

        public override int GetHashCode()
        {
            var hashCode = -1651123971;
            hashCode = hashCode * -1521134295 + Licence.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            return hashCode;
        }
    }
}