using CalculatorApp;

namespace CalculatorAppTest
{
    public class UnitTest1
    {
        [Fact]
        public void verify_Addition_OfTwoNumbers()
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