using Newtonsoft.Json.Linq;

namespace JsonMigrator.Tests.Dummy
{
    public class TwoParametersDummy
    {
        [Migration("1", "2")]
        private static JToken Migration_TwoParameters(JToken jToken, string something)
        {
            return null;
        }
    }
}
