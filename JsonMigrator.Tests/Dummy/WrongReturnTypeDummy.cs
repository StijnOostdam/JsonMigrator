using Newtonsoft.Json.Linq;

namespace JsonMigrator.Tests.Dummy
{
    public class WrongReturnTypeDummy
    {
        [Migration("1", "2")]
        private static void Migration_WrongReturnType(JToken jToken)
        {

        }
    }
}
