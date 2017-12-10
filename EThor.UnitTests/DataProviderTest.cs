using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EThor.DataAccess;
using System.Configuration;
using EThor.Core.DataAccess;
using System.Net.Http;

namespace EThor.UnitTests
{
    [TestClass]
    public class DataProviderTest
    {
        [TestMethod]
        [ExpectedException(typeof(ConfigurationErrorsException),
            "EndPoint Not Found")]
        public void When_NoEndPoint_DataProvider_Create_Fails()
        {
            new DataProvider();
        }

        [TestMethod]
        public void With_EndPoint_DataProvider_Create_Succeeds()
        {
            ConfigurationManager.AppSettings["EThorStatEndPoint"] = "http://ethor.com";
            var dataProvider = new DataProvider();
            Assert.IsNotNull(dataProvider);
            Assert.IsInstanceOfType(dataProvider, typeof(IDataProvider));
        }

        [TestMethod]
        public void With_InvalidRequest_Returns_Throws_Exception()
        {
            ConfigurationManager.AppSettings["EThorStatEndPoint"] = "http://abcxyz123";
            var dataProvider = new DataProvider();            
            var ex = Assert.ThrowsException<AggregateException>(() => dataProvider.Provide());
            Assert.IsInstanceOfType(ex.InnerException, typeof(HttpRequestException));
        }

        [TestMethod]
        public void With_ValidUrl_Returns_Json()
        {
            ConfigurationManager.AppSettings["EThorStatEndPoint"] = "http://test.ethorstat.com/test.ashx";
            var dataProvider = new DataProvider();
            string json = dataProvider.Provide();
            Assert.IsTrue(!string.IsNullOrEmpty(json));
            Assert.IsTrue(json.Contains("parm1"));
            Assert.IsTrue(json.Contains("parm2"));
            Assert.IsTrue(json.Contains("op"));
        }
    }
}