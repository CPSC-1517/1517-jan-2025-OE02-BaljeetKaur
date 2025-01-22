namespace DiscountCalculatorTest
{
    using DiscountCalculator;


    /*A higher sales amount results in a higher discount.
    The discount percentage should be determined based on predefined ranges:
        0) Sales amount below 100: 0% discount
        1) Sales amount between 100 and 500: 10% discount
        2) Sales amount between 500 and 1000: 20% discount
        3) Sales amount above 1000: 30% discount
    Calculate the final price based on the discount percentage
     * 
     */
    public class UnitTest1
    {
        [Fact]
        public void CalculateDiscount_WithAmountLessThan100_Return0PercentageDiscountTest1()
        {
            // Arrange
            var saleAmount = 80m;
            var expectedDiscountPercentage = 0;
            var discountCalculator= new DiscountCalculator();


            //Act

            var discountPercentage = discountCalculator.CalculateDiscountPercentage(saleAmount);

            // Assert

            Assert.Equal(expectedDiscountPercentage, discountPercentage);

        }

        [Fact]
        public void CalculateDiscount_WithAmountBetween100_and_500_Return10PercentageDiscountTest1()
        {
            // Arrange
            var saleAmount = 169m;
            var expectedDiscountPercentage = 10;
            var discountCalculator = new DiscountCalculator();


            //Act

            var discountPercentage = discountCalculator.CalculateDiscountPercentage(saleAmount);

            // Assert

            Assert.Equal(expectedDiscountPercentage, discountPercentage);


        }

        [Fact]
        public void CalculateDiscount_WithAmountBetwee500_and_1000_Return0PercentageDiscountTest1()
        {
            // Arrange
            var saleAmount = 680m;
            var expectedDiscountPercentage = 20;
            var discountCalculator = new DiscountCalculator();


            //Act

            var discountPercentage = discountCalculator.CalculateDiscountPercentage(saleAmount);

            // Assert

            Assert.Equal(expectedDiscountPercentage, discountPercentage);


        }

        [Fact]
        public void CalculateDiscount_WithAmountMoreThan1000_Return30PercentageDiscountTest1()
        {
            // Arrange
            var saleAmount = 80m;
            var expectedDiscountPercentage = 0;
            var discountCalculator = new DiscountCalculator();


            //Act

            var discountPercentage = discountCalculator.CalculateDiscountPercentage(saleAmount);

            // Assert

            Assert.Equal(expectedDiscountPercentage, discountPercentage);


        }
    }

}