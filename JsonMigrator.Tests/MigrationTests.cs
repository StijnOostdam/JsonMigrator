using JsonMigrator.Tests.Dummy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonMigrator.Tests
{
    [TestClass]
    public class MigrationTests
    {
        [TestMethod]
        public void MigrationTest()
        {
            var jtoken = JToken.Parse("{\"JsonVersion\":\"1\",\"StringValue\":\"String1\",\"IntegerValue\":1}");
            jtoken = JsonMigrator.Migrate<DummyClass>(jtoken);

            var dummy = JsonConvert.DeserializeObject<DummyClass>(jtoken.ToString());

            Assert.AreEqual(dummy.StringValue3, "String1");
            Assert.AreEqual(dummy.IntegerValue3, 1);
            Assert.AreEqual(dummy.JsonVersion, "3");
        }
    }
}
