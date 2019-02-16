using JsonMigrator.Exceptions;
using JsonMigrator.Tests.Dummy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace JsonMigrator.Tests
{
    [TestClass]
    public class ExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(JsonMigrationVersionException))]
        public void MissingVersionTest()
        {
            var jtoken = JToken.Parse("{\"StringValue\":\"String1\",\"IntegerValue\":1}");
            JsonMigrator.Migrate<DummyClass>(jtoken);
        }

        [TestMethod]
        [ExpectedException(typeof(JsonMigrationMethodException))]
        public void NonStaticTest()
        {
            var jtoken = JToken.Parse("{\"JsonVersion\":\"1\",\"StringValue\":\"String1\",\"IntegerValue\":1}");
            JsonMigrator.Migrate<NonStaticDummy>(jtoken);
        }

        [TestMethod]
        [ExpectedException(typeof(JsonMigrationMethodException))]
        public void PublicTest()
        {
            var jtoken = JToken.Parse("{\"JsonVersion\":\"1\",\"StringValue\":\"String1\",\"IntegerValue\":1}");
            JsonMigrator.Migrate<PublicDummy>(jtoken);
        }

        [TestMethod]
        [ExpectedException(typeof(JsonMigrationMethodException))]
        public void WrongReturnTypeTest()
        {
            var jtoken = JToken.Parse("{\"JsonVersion\":\"1\",\"StringValue\":\"String1\",\"IntegerValue\":1}");
            JsonMigrator.Migrate<WrongReturnTypeDummy>(jtoken);
        }

        [TestMethod]
        [ExpectedException(typeof(JsonMigrationMethodException))]
        public void TwoParametersTest()
        {
            var jtoken = JToken.Parse("{\"JsonVersion\":\"1\",\"StringValue\":\"String1\",\"IntegerValue\":1}");
            JsonMigrator.Migrate<TwoParametersDummy>(jtoken);
        }

        [TestMethod]
        [ExpectedException(typeof(JsonMigrationMethodException))]
        public void WrongParameterTypeTest()
        {
            var jtoken = JToken.Parse("{\"JsonVersion\":\"1\",\"StringValue\":\"String1\",\"IntegerValue\":1}");
            JsonMigrator.Migrate<WrongParameterTypeDummy>(jtoken);
        }
    }
}
