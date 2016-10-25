using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{

    class DiscountLevel
    {
        private Dictionary<int, double> disLevel;
        DiscountLevel()
        {
            this.disLevel = new Dictionary<int, double>()
                {
                    {1,1},
                    {2,0.95},
                    {3,0.9},
                    {4,0.8},
                    {5,0.75}
                };
        }

    }
}


