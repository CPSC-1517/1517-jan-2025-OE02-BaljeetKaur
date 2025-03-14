using CalculatorApp;

namespace CalculatorAppTest
{
    public class UnitTest1
    {
        [Fact]
        public void verify_Addition_OfTwoNumbers0()
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
        [Fact]
        public void verify_Addition_OfTwoNumbers1()
        {
            // Arrange-
            int a = 12;
            int b = 13;
            var cal = new Calculator();

            //Act
            var result = cal.AddTwoNumbers(a, b);

            //Assert
            Assert.Equal(25, result);

        }

        [Theory]

        [InlineData(2,3,5)]
        [InlineData(3,4,7)]
        [InlineData(4,5,9)]
        [InlineData(5,6,11)]
        [InlineData(6,7,13)]
        [InlineData(7,8,15)]
        public void verify_Addition_OfTwoNumbers_Theory(int a, int b, int expectedValue)
        {
            // Arrange-
          
            var cal = new Calculator();

            //Act
            var result = cal.AddTwoNumbers(a, b);

            //Assert
            Assert.Equal(expectedValue, result);

        }
        [Fact]
        public void verify_Subtraction_OfTwoNumbers()
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