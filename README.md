# JsonMigrator

[Nuget](https://www.nuget.org/packages/StijnOostdam.JsonMigrator/)

Small library to implement migration methods for classes serialized and stored as JSON

# Usage

Firstly, it is required to add a string property called JsonVersion to any class using migration methods. This property is used by JsonMigrator to determine which migration methods to execute. Secondly, JsonMigrator will automatically update the JsonVersion property, but it is not responsible for setting the correct version when creating an object using migration.

Say you have this class:

    public class DummyClass  
    {  
        public string JsonVersion { get; set; }      
        public string StringValue { get; set; }      
        public int IntegerValue { get; set; }      
    }
    
Then you update your program and your class looks like this:

    public class DummyClass  
    {  
        public string JsonVersion { get; set; }      
        public string StringValue2 { get; set; }      
        public int IntegerValue2 { get; set; }      
    }

After another update, your class looks like this:

    public class DummyClass  
    {  
        public string JsonVersion { get; set; }      
        public string StringValue3 { get; set; }      
        public int IntegerValue3 { get; set; }      
    }
    
For users running the first or second version, their JSON will not deserialize correctly after updating to the latest version. To fix this, add migration methods:

    public class DummyClass
    {
        public string JsonVersion { get; set; }

        public string StringValue3 { get; set; }

        public int IntegerValue3 { get; set; }

        [Migration("1", "2")]
        private static JToken Migration_1_2(JToken jToken)
        {
            //Version 1 had properties called StringValue and IntegerValue
            jToken["StringValue"].Rename("StringValue2");
            jToken["IntegerValue"].Rename("IntegerValue2");

            return jToken;
        }

        [Migration("2", "3")]
        private static JToken Migration_2_3(JToken jToken)
        {
            //Version 2 had properties called StringValue2 and IntegerValue2
            jToken["StringValue2"].Rename("StringValue3");
            jToken["IntegerValue2"].Rename("IntegerValue3");

            return jToken;
        }
    }
    
Note that the <code>Rename</code> method is an extension method offered by JsonMigrator and not part of the standard Json.Net library.

The migration can then be called using the following code:

    var jtoken = JToken.Parse("{\"JsonVersion\":\"1\",\"StringValue\":\"String1\",\"IntegerValue\":1}");
    jtoken = JsonMigrator.Migrate<DummyClass>(jtoken);
    var dummy = jtoken.ToObject<DummyClass>();
    
The dummy object will now have migrated to version 3.
