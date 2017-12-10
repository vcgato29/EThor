using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EThor.Core.DataAccess;
using EThor.ApplicationService;
using EThor.Core;
using System.Data;

namespace EThor.UnitTests
{
    /// <summary>
    /// Summary description for OperationEngineTests
    /// </summary>
    [TestClass]
    public class OperationEngineTests
    {
        [TestMethod]
        public void With_ValidData_Return_Complete_Dto()
        {
            Mock<IDataProvider> dataProvider = new Mock<IDataProvider>();
            string json = "{\r\n  \"parm1\": 8,\r\n  \"parm2\": 8,\r\n  \"op\": \"-\"\r\n}";
            dataProvider.Setup(d => d.Provide()).Returns(json);
            IOperationEngine engine = new OperationEngine(dataProvider.Object);
            var dto = engine.Run();
            Assert.IsNotNull(dto);
            Assert.AreEqual(dto.Operator, "-");
            Assert.AreEqual(dto.Parameter1, "8");
            Assert.AreEqual(dto.Parameter2, "8");
            Assert.AreEqual(dto.Result, "0");
        }

        [TestMethod]
        public void With_EmptyJson_Return_Null()
        {
            Mock<IDataProvider> dataProvider = new Mock<IDataProvider>();
            dataProvider.Setup(d => d.Provide()).Returns("");
            IOperationEngine engine = new OperationEngine(dataProvider.Object);
            Assert.IsNull(engine.Run());
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxErrorException))]
        public void With_InvalidOperator_Throws_Exception()
        {
            Mock<IDataProvider> dataProvider = new Mock<IDataProvider>();
            string json = "{\r\n  \"parm1\": 8,\r\n  \"parm2\": 8,\r\n  \"op\": \"abc\"\r\n}";
            dataProvider.Setup(d => d.Provide()).Returns(json);
            IOperationEngine engine = new OperationEngine(dataProvider.Object);
            Assert.IsNull(engine.Run());
        }
    }
}
