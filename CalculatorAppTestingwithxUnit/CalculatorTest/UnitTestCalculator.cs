using CalculatorApp;

namespace CalculatorTest
{
    public class UnitTestCalculator
    {
        [Fact]
        public void verify_Addition_OfTwoNumbers()
        {
            // Arrange
            int a = 6;
            int b = 7;
            var cal = new Calculator();

            //Act
            
            var result = cal.AddTwoNumbers(a, b);


            //Assert

            Assert.Equal(13, result);


        }

        [Fact]
        public void verify_Subtraction_OfTwoNumbers()
        {
            // Arrange
            int a = 9;
            int b = 7;
            var cal = new Calculator();

            //Act

            var result = cal.SubtractTwoNumbers(a, b);


            //Assert

            Assert.Equal(2, result);


        }
    }
}