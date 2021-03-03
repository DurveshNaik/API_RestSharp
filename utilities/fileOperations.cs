using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;

namespace TestAssignmentProject.utilities
{
    class fileOperations
    {
        public static JObject GetScenarioSpecificTestData(string filePrefix)
        {
            string testDataLocation = System.IO.Path.GetFullPath(@"..\..\..\tests\testData\"+ filePrefix + ".json");

            string fileContent = String.Empty;

            using (StreamReader sr = new StreamReader(testDataLocation))
            {
                fileContent = sr.ReadToEnd();
            };
            return JObject.Parse(fileContent);
        }
    }
}
