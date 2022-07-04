using System.Reflection;
using Xunit.Sdk;

namespace BeforeAfterInterceptorDemoTest.Attributes
{
    public class WriteConsoleAttribute : BeforeAfterTestAttribute
    {        
        
        public override void Before(MethodInfo methodUnderTest)
        {            
            Console.WriteLine($"{methodUnderTest.Name} ejecutando antes de inicio de prueba");
        }

        public override void After(MethodInfo methodUnderTest)
        {
            Console.WriteLine($"{methodUnderTest.Name} ejecutando tras fin de prueba");
        }


    }
}
