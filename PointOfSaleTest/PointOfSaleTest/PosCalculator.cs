using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSaleTest
{
    public class PosCalculator
    {
        private Discounter discounter;

        public PosCalculator(List<Product> productsOn3For2, List<Product> productsOnBogOf)
        {
            discounter = new Discounter(productsOn3For2, productsOnBogOf);
        }

        /*
         * By outputting results in as an output parameter we do not have to interate twice to 
         * call the apply discount function when we also wish to print the output.
         * If we were doing this in Java then pass in a Set<Pair<double, String>> and populate by reference.
         */
        public Calculation CalculateBasket(Basket basket, out List<Tuple<double, string>> results)
        {
            results = new List<Tuple<double, string>>();

            Calculation calculation = new Calculation(basket);
            foreach (BasketItem item in basket.BasketItems())
            {
                int count = item.Count;
                Product product = item.Product;
                string key = product.Id;

                Tuple<double, string> result = discounter.ApplyDiscount(product, count);
                if (result != null)
                {
                    results.Add(result);
                    calculation.Discounts.Add(new Discount(product, result.Item1, result.Item2));
                }

            }

            return calculation;
        }

        public void PrintCalculation(Calculation calculation, List<Tuple<double, string>> results)
        {
            foreach (BasketItem item in calculation.Basket.BasketItems())
            {
                var product = item.Product;
                for (int i=0; i < item.Count; i++)
                {
                    Console.WriteLine("{0} {1}", product.NameWithRightPadding, product.ItemPrice2DecimalPlaces);
                }
            }

            if (results.Any())
            {
                Console.WriteLine();
                Console.WriteLine("Balance before savings £{0}", calculation.TotalBeforeDiscount().ToString("F2"));

                foreach (Tuple<double, string> result in results)
                {
                    Console.WriteLine(result.Item2);
                }

                Console.WriteLine("Total discount £{0}", calculation.TotalDiscount().ToString("F2"));
            }

            Console.WriteLine("Balance to pay £{0}", calculation.TotalAfterDiscount().ToString("F2"));
        }

        public void CalculateAndPrintBasket(Basket basket)
        {
            List<Tuple<double, string>> results = null;
            Calculation calculation = CalculateBasket(basket, out results);
            PrintCalculation(calculation, results);
        }
    }
}
