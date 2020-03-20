using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiContracts.Analyze;

namespace WebApiTests
{
    [TestClass]
    public class AnalyzeBodyTests
    {
        [TestMethod]
        public void UrlSetterNoTrimTest()
        {
            var body = new AnalyzeRequest { Url = "https://www.google.com" };

            Assert.AreEqual("https://www.google.com", body.Url);
        }

        [TestMethod]
        public void UrlSetterTrimTest1()
        {
            var body = new AnalyzeRequest { Url = "https://www.google.com/" };

            Assert.AreEqual("https://www.google.com", body.Url);
        }

        [TestMethod]
        public void UrlSetterTrimTest2()
        {
            var body = new AnalyzeRequest { Url = "https://www.google.com//////" };

            Assert.AreEqual("https://www.google.com", body.Url);
        }
    }
}
