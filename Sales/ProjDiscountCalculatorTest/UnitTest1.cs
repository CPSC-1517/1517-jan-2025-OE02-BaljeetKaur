namespace DiscountCalculatorTest
{
    using ProjDiscountCalculator;

    /*
     *  Sales amount below 100: 0% discount
        Sales amount between 100 and 500: 10% discount
        Sales amount between 500 and 1000: 20% discount
        Sales amount above 1000: 30% discount

     * */



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