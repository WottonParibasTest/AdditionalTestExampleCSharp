using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSaleTest
{
    public class Basket
    {
        private Dictionary<string, BasketItem> basket = new Dictionary<string, BasketItem>();

        public void AddToBasket(Product product, int count)
        {
            if (count < 1)
            {
                throw new ArgumentException(string.Format("Product can not be added to basket with a negative count, count is: {0}", count));
            }

            if (product == null)
            {
                throw new ArgumentNullException("Product can not be null");
            }

            string key = product.Id;

            if (basket.ContainsKey(key))
            {
                basket[key].IncrementCountBy(count);
            }
            else
            {
                var item = new BasketItem(product, count);
                basket.Add(key, item);
            }
        }

        public List<BasketItem> BasketItems()
        {
            return basket.Values.ToList();
        }
    }

    public class BasketItem
    {
        public Product Product { get; private set; }
        public int Count { get; private set; }

        public BasketItem(Product product, int count)
        {
            Product = product;
            Count = count;
        }

        public void IncrementCountBy(int incrementBy)
        {
            Count += incrementBy;
        }
    }
}
