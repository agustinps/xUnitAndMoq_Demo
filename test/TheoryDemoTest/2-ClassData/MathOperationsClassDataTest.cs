using Utilities;

namespace TheoryDemoTest.ClassData
{
    public class MathOperationsClassDataTest
    {
        [Theory]
        [ClassData(typeof(FactoryDataClassData))]
        public void Add_ShouldBeExpected(int expected, int a, int b)
        {
            //Arrange

            //Act
            var resultado = MathOperations.Add(a, b);

            //Assert
            Assert.Equal(expected, resultado);
        }

    }
}
