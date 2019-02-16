using Newtonsoft.Json.Linq;

namespace JsonMigrator.Tests.Dummy
{
    public class WrongParameterTypeDummy
    {
        [Migration("1", "2")]
        private static JToken Migration_WrongParameterType(string jToken)
        {
            return null;
        }
    }
}
