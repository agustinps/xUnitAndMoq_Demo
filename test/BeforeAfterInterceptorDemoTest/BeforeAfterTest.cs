using BeforeAfterInterceptorDemoTest.Attributes;

namespace BeforeAfterInterceptorDemoTest
{
    public class BeforeAfterTest
    {
        /// <summary>
        /// Utiliza el atributo WriteConsole que se ejecutará antes y despues de la prueba
        /// El atributo se puede utilizar tambien a nivel de clase y se pueden añadir todos los que se necesiten
        /// </summary>
        [Fact, WriteConsole]
        public void BeforeAfter_ShouldExecuted_BeforeAndAfterTest()
        {
            //Arrange
                //Some Arrange
            
            //Act
                //Some Act

            //Assert
            Assert.True(1 == 1);
        }
    }
}
