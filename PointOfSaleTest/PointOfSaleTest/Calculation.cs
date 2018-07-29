using System;
using System.Collections.Generic;

namespace PointOfSaleTest
{
    public class Calculation
    {
        public List<Discount> Discounts { get; private set; }
        public Basket Basket { get; private set; }

        public Calculation(Basket basket)
        {
            if (basket == null)
            {
                throw new ArgumentNullException("Basket must not be null");
            }

            Basket = basket;
            Discounts = new List<Discount>();
        }

        public double TotalBeforeDiscount()
        {
            double total = 0;

            foreach(BasketItem item in Basket.BasketItems())
            {
                total += item.Product.Price * item.Count;
            }

            return total;
        }

        public double TotalDiscount()
        {
            double total = 0;
            foreach(Discount discount in Discounts)
            {
                total += discount.DiscountValue;
            }

            return total;
        }

        public double TotalAfterDiscount()
        {
            return TotalBeforeDiscount() - TotalDiscount();
        }

    }
}
