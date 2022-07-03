using Utilities;

namespace TheoryDemoTest.CustomAttribute
{
    public class MathOperationsCustomAttributeTest
    {
        [Theory]
        [JsonData("DataMath.json")]
        public void Add_ShouldBeExpected_WithCustomAttribute(int expected, int a, int b)
        {
            //Arrange

            //Act
            var result = MathOperations.Add(a, b);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
