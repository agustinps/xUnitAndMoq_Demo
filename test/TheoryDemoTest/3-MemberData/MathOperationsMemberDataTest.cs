using Utilities;

namespace TheoryDemoTest.MemberData
{
    public class MathOperationsMemberDataTest
    {
        [Theory]
        [MemberData(nameof(FactoryDataMemberData.GetData1), MemberType = typeof(FactoryDataMemberData))]
        public void Add_ShouldBeExpected_WithGetData1(int expected, int a, int b)
        {
            //Arrange

            //Act
            var resultado = MathOperations.Add(a, b);

            //Assert
            Assert.Equal(expected, resultado);
        }


        /// <summary>
        /// Uso de parámetros
        /// </summary>        
        [Theory]
        [MemberData(nameof(FactoryDataMemberData.GetData2), parameters: 3, MemberType = typeof(FactoryDataMemberData))]
        public void Add_ShouldBeExpected_WithGetData2(int expected, int a, int b)
        {
            //Arrange

            //Act
            var resultado = MathOperations.Add(a, b);

            //Assert
            Assert.Equal(expected, resultado);
        }


        /// <summary>
        /// Uso de clase TheoryData con atributo MemberData
        /// </summary>        
        [Theory]
        [MemberData(nameof(FactoryDataMemberData.GetData3), MemberType = typeof(FactoryDataMemberData))]
        public void Add_ShouldBeExpected_WithGetData3(int expected, int a, int b)
        {
            //Arrange

            //Act
            var resultado = MathOperations.Add(a, b);

            //Assert
            Assert.Equal(expected, resultado);
        }


    }
}
