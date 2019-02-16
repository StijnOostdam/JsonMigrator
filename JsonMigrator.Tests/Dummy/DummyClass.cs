using Newtonsoft.Json.Linq;

namespace JsonMigrator.Tests.Dummy
{
    public class DummyClass
    {
        public string JsonVersion { get; set; }

        public string StringValue3 { get; set; }

        public int IntegerValue3 { get; set; }

        [Migration("1", "2")]
        private static JToken Migration_1_2(JToken jToken)
        {
            //We assume that version 1 had properties called StringValue and IntegerValue
            jToken["StringValue"].Rename("StringValue2");
            jToken["IntegerValue"].Rename("IntegerValue2");

            return jToken;
        }

        [Migration("2", "3")]
        private static JToken Migration_2_3(JToken jToken)
        {
            //We assume that version 2 had properties called StringValue2 and IntegerValue2
            jToken["StringValue2"].Rename("StringValue3");
            jToken["IntegerValue2"].Rename("IntegerValue3");

            return jToken;
        }
    }
}
