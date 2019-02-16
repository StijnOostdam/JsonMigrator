using Newtonsoft.Json.Linq;

namespace JsonMigrator.Tests.Dummy
{
    public class NonStaticDummy
    {
        [Migration("1", "2")]
        private JToken Migration_NonStatic(JToken jToken)
        {
            return null;
        }
    }
}
