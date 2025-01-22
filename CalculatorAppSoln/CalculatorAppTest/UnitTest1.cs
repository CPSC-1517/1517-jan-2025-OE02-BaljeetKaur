using CalculatorApp;

namespace CalculatorAppTest
{
    public class UnitTest1
    {
        [Fact]
        public void Verify_Addition_OfTwoNumbers0()
        {
            // Arrange-
            int a = 5;
            int b = 6;
            var cal = new Calculator();

            //Act
            var result = cal.AddTwoNumbers(a, b);

            //Assert
            Assert.Equal(11, result);
      
        }
        [Theory]
        [InlineData(5,6,11)]
        [InlineData(6,12,18)]
        [InlineData(12,13,25)]
        public void Verify_Addition_OfTwoNumbers1( int a, int b, int expectedValue)
        {
            // Arrange-
            var cal = new Calculator();

            //Act
            var result = cal.AddTwoNumbers(a, b);

            //Assert
            Assert.Equal(expectedValue, result);

        }
        [Fact]
        public void Verify_Subtraction_OfTwoNumbers()
        {
            // Arrange-
            int a = 8;
            int b = 6;
            var cal = new Calculator();

            //Act

            var result = cal.SubtractTwoNumbers(a, b);

            //Assert

            Assert.Equal(2, result);

        }
    }
}