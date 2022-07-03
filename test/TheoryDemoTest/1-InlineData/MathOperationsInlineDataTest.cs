using Utilities;

namespace TheoryDemoTest.InlineData
{
    public class MathOperationsInlineDataTest
    {
        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(15, 10, 5)]
        [InlineData(10, 5, 5)]
        [InlineData(10, 8, 2)]
        public void Add_ShouldBeExpected(int expected, int a, int b)
        {
            //Arrange

            //Act
            var result = MathOperations.Add(a, b);

            //Assert
            Assert.Equal(expected, result);
        }

    }
}
