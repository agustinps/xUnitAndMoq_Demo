using Newtonsoft.Json;
using System.Reflection;
using Xunit.Sdk;

namespace TheoryDemoTest.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class JsonDataAttribute : DataAttribute
    {
        private readonly string path;

        public JsonDataAttribute(string path)
        {
            this.path = path;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }            

            if (!File.Exists(path))
                throw new ArgumentException($"Fichero no existe {path}");

            var data = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<object[]>>(data);
        }
    }

   
}
