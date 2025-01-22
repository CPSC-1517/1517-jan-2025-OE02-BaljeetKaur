using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCalculator
{
    public class DiscountCalculator
    {
        public decimal? CalculateDiscountPercentage( decimal saleAmount)
        {
            if (saleAmount < 100)
                return 0;
              else if (saleAmount >= 100 && saleAmount < 500)
                  return 10;
              else if (saleAmount >= 500 && saleAmount < 1000)
                 return 20;
            return 30;

            

                    
        }
    }
}
