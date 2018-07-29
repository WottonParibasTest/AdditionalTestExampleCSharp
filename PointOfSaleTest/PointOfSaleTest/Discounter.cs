using System;
using System.Collections.Generic;

namespace PointOfSaleTest
{
    public class Discounter
    {
        //In java this would be achieved with the Callable interface and a Set<Future<Pair<double,String>>
        private Dictionary<string, DiscountDelegate> products = new Dictionary<string, DiscountDelegate>();

        private delegate Tuple<double, string> DiscountDelegate(Product product, int count);

        public Tuple<double, string> ApplyDiscount(Product product, int count)
        {
            string key = product.Id;
            if (!products.ContainsKey(key))
            {
                return null;
            }

            DiscountDelegate discount = products[key];

            return discount(product, count);
        }

        public Discounter(List<Product> productsForDiscount3For2, List<Product> productsForDiscountBogOf)
        {
            //rule is item can only receive 1 discount.
            if (productsForDiscount3For2 != null)
            {
                foreach (Product p in productsForDiscount3For2)
                {
                    string key = p.Id;
                    if (!products.ContainsKey(key))
                    {
                        products.Add(key, GetDiscount3For2);
                    }
                }
            }

            if (productsForDiscountBogOf != null)
            {
                foreach (Product p in productsForDiscountBogOf)
                {
                    string key = p.Id;
                    if (!products.ContainsKey(key))
                    {
                        products.Add(key, GetDiscountBogOf);
                    }
                }
            }

        }

        private Tuple<double, string> GetDiscount3For2(Product product, int count)
        {
            int numberFree = count / 3;
            if (numberFree == 0)
            {
                return null;
            }

            double discountValue = product.Price * numberFree;
            string discountText = string.Format("3 for 2 on {0}, {1} free, save £{2}", product.Name, numberFree, discountValue.ToString("F2"));

            return new Tuple<double, string>(discountValue, discountText);
        }

        private Tuple<double, string> GetDiscountBogOf(Product product, int count)
        {
            int numberFree = count / 2;
            if (numberFree == 0)
            {
                return null;
            }

            double discountValue = product.Price * numberFree;
            string discountText = string.Format("2 for 1 on {0}, {1} free, save £{2}", product.Name, numberFree, discountValue.ToString("F2"));

            return new Tuple<double, string>(discountValue, discountText);
        }

    }
}