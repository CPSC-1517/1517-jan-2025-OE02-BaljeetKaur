namespace DiscountCalculatorTest
{
    using ProjDiscountCalculator;

    public class UnitTest1
    {
        [Fact]
        public void CalculateDiscount_WithAmountLessThan100_Return0PercentageDiscount()
        {
            //Arrange

            var saleAmount = 80m;
            var expectedDiscountPercentage = 0;
            var discountCalculator = new DiscountCalculator();

            //Act

            var discountPercentage = discountCalculator.CalculateDiscountPercentage(saleAmount);
            
            //Assert

                Assert.Equal(expectedDiscountPercentage, discountPercentage);

        }
    }
}