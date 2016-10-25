using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Tests
{
    class ShoppingCart
    {
        //很努力,但功力確實還不夠,以下以參考原程式,手打模仿版
        //多看幾次測試的就懂了,反而這支需要多花一點點時間瞭解
        //每本書100元
        private const double unitBookPrice = 100;
        private Dictionary<int, double> discountLevel;

        public ShoppingCart()
        {
            //幾本書,折扣數
            this.discountLevel = new Dictionary<int, double>()
            {
                {1,1},
                {2,0.95},
                {3,0.9},
                {4,0.8},
                {5,0.75}
            };
        }

             internal double CalculateFee(Dictionary<string, int> books)
        {
            var bookCount = books.Sum(x => x.Value);
            if (bookCount == 0)
            {
                return 0;
            }

            //總共買了不同策數的書 6
            var maxBooksCount = books.Max(x => x.Value);

            //每策各多少本
            var unCheckedOutBooks = books.ToDictionary(x => x.Key, y => y.Value); 

            
            double newOrdAmount = 0;

            //檢查是否成套，每結帳一套（依據該套書本數的折扣），結帳過的集數書本數就扣1
            //假設買3,2,1
            for (int i = maxBooksCount; i > 0; i--)
            {
                //大於一的都會出現
                var groupOfEditionMoreThanOneBook = unCheckedOutBooks.Where(x => x.Value > 0).ToList();

                //所以這邊的 第一次3,第二2,第三次3
                var groupCount = groupOfEditionMoreThanOneBook.Count;

                // 只剩下某一集有書，直接把剩下的書x單價，加上原本的fee，即為總價
                if (groupCount == 1)
                {
                    newOrdAmount += groupOfEditionMoreThanOneBook.First().Value * unitBookPrice;
                    break;
                }

                //找到折扣
                var discountRatio = this.discountLevel[groupCount]; //

                //(3*100*0.9)+ (2*100*.95
                newOrdAmount += groupCount * unitBookPrice * discountRatio;

                //把已計算的書抽離,-- 
                foreach (var group in groupOfEditionMoreThanOneBook)
                {
                    unCheckedOutBooks[group.Key]--;
                }
            }

            return newOrdAmount;
        }

    }
}