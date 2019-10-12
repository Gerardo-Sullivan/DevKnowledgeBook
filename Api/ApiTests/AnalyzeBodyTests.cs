using Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiTests
{
    [TestClass]
    public class AnalyzeBodyTests
    {
        [TestMethod]
        public void UrlSetterNoTrimTest()
        {
            var body = new AnalyzeBody { Url = "https://www.google.com" };

            Assert.AreEqual("https://www.google.com", body.Url);
        }

        [TestMethod]
        public void UrlSetterTrimTest1()
        {
            var body = new AnalyzeBody { Url = "https://www.google.com/" };

            Assert.AreEqual("https://www.google.com", body.Url);
        }

        [TestMethod]
        public void UrlSetterTrimTest2()
        {
            var body = new AnalyzeBody { Url = "https://www.google.com//////" };

            Assert.AreEqual("https://www.google.com", body.Url);
        }
    }
}