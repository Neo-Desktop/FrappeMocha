using System.Reflection;
using FrappeMocha.Keygen;
using FrappeMocha.Keygen.Platforms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlatformUnitTests
{
    [TestClass]
    public class PlatformUnitTest
    {
        private KeygenBase platform;
        private readonly string[] _testCompanyUserStrings = {"Test", "FrappeMocha", "abcd", "1234"};

        [TestMethod]
        public void TestWindowsPlatform()
        {
            platform = new PlatformWindows();
            foreach (var product in platform.Products)
            {
                var types = platform.GenerateLicencetypes(product);
                for (int i = 0; i < types.Count; i++)
                {
                    foreach (string company in _testCompanyUserStrings)
                    {
                        var key = platform.Generate(i, company, product.Licence);
                        Assert.IsTrue(platform.Check(key, company, product.Licence));
                    }
                }
            }
        }

        [TestMethod]
        public void TestMacOsxPlatform()
        {
            platform = new PlatformMac();
            foreach (var product in platform.Products)
            {
                var types = platform.GenerateLicencetypes(product);
                for (int i = 0; i < types.Count; i++)
                {
                    foreach (string company in _testCompanyUserStrings)
                    {
                        var key = platform.Generate(i, company, product.Licence);
                        Assert.IsTrue(platform.Check(key, company, product.Licence));
                    }
                }
            }
        }

        [TestMethod]
        public void TestAndroidPlatform()
        {
            platform = new PlatformAndroid();
            foreach (var product in platform.Products)
            {
                var types = platform.GenerateLicencetypes(product);
                for (int i = 0; i < types.Count; i++)
                {
                    foreach (string company in _testCompanyUserStrings)
                    {
                        var key = platform.Generate(i, company, product.Licence);
                        Assert.IsTrue(platform.Check(key, company, product.Licence));
                    }
                }
            }
        }

        [TestMethod]
        public void TestJavaPlatform()
        {
            platform = new PlatformJava();
            foreach (var product in platform.Products)
            {
                var types = platform.GenerateLicencetypes(product);
                for (int i = 0; i < types.Count; i++)
                {
                    foreach (string company in _testCompanyUserStrings)
                    {
                        var key = platform.Generate(i, company, product.Licence);
                        Assert.IsTrue(platform.Check(key, company, product.Licence));
                    }
                }
            }
        }

        [TestMethod]
        public void TestJavaScriptPlatform()
        {
            platform = new PlatformJavaScript();
            foreach (var product in platform.Products)
            {
                var types = platform.GenerateLicencetypes(product);
                for (int i = 0; i < types.Count; i++)
                {
                    foreach (string company in _testCompanyUserStrings)
                    {
                        var key = platform.Generate(i, company, product.Licence);
                        Assert.IsTrue(platform.Check(key, company, product.Licence));
                    }
                }
            }
        }
    }
}
