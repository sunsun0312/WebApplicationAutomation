using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace WebApplicationAutomation.utilities
{
    public class JsonReader
    {
        public JsonReader()
        {
        }

        public String extractData(String tokenName)
        {
            String myJsonString = File.ReadAllText("utilities/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<String>();
        }

        public String[] extractDataArray(String tokenName)
        {
            String myJsonString = File.ReadAllText("utilities/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            List<String> productsList = jsonObject.SelectTokens(tokenName).Values<String>().ToList();
            return productsList.ToArray();
        }
    }
}
