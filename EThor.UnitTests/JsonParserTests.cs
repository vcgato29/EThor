using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EThor.Core;
using EThor.Core.Models;

namespace EThor.UnitTests
{
    /// <summary>
    /// Summary description for JsonParserTests
    /// </summary>
    [TestClass]
    public class JsonParserTests
    {
        [TestMethod]
        public void With_NullOrEmptyJson_Returns_Null()
        {
            var obj = JsonParser.ConvertTo<string>(string.Empty);
            Assert.IsNull(obj);
        }

        [TestMethod]
        public void With_ValidOperationJson_Returns_OperationInstance()
        {
            string json = "{\r\n  \"parm1\": 8,\r\n  \"parm2\": 8,\r\n  \"op\": \"-\"\r\n}";
            var obj = JsonParser.ConvertTo<Operation>(json);
            Assert.IsNotNull(obj);
            Assert.AreEqual(obj.parm1, 8);
            Assert.AreEqual(obj.parm2, 8);
            Assert.AreEqual(obj.op, "-");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid JSON primitive: parm2.")]
        public void With_InValidOperationJson_Throws_Exception()
        {
            string json = "{\r\n  \"parm1\": parm2\": 8,\r\n  \"op\": \"-\"\r\n}";
            JsonParser.ConvertTo<Operation>(json);
        }
    }
}
