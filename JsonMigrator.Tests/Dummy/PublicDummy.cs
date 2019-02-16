using Newtonsoft.Json.Linq;

namespace JsonMigrator.Tests.Dummy
{
    public class PublicDummy
    {
        [Migration("1", "2")]
        public static JToken Migration_Public(JToken jToken)
        {
            return null;
        }
    }
}
