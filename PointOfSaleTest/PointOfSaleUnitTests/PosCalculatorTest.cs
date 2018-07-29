using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointOfSaleTest;
using System;
using System.Collections.Generic;

namespace PointOfSaleUnitTests
{
    [TestClass()]
    public class PosCalculatorTest
    {
        private double delta = 0.00000001;

        [TestMethod]
        public void TestBogOfAppliedCorrectly()
        {
            var apple = new Product("Apple", 0.2);

            var basket = new Basket();
            basket.AddToBasket(apple, 5);

            var bogof = new List<Product> { apple };
            var threeForTwo = new List<Product>();

            var calculator = new PosCalculator(threeForTwo, bogof);
            List<Tuple<double, string>> results;
            var calc = calculator.CalculateBasket(basket, out results);
            Assert.AreEqual(0.4, calc.TotalDiscount(), delta);
        }

        [TestMethod]
        public void TestThreeForTwoCorrectlyApplied()
        {
            var watermelon = new Product("Watermelon", 0.8);

            var basket = new Basket();
            basket.AddToBasket(watermelon, 5);

            var bogof = new List<Product>();
            var threeForTwo = new List<Product> { watermelon };

            var calculator = new PosCalculator(threeForTwo, bogof);
            List<Tuple<double, string>> results;
            var calc = calculator.CalculateBasket(basket, out results);
            Assert.AreEqual(0.8, calc.TotalDiscount(), delta);
        }

        [TestMethod]
        public void TestMixedOffersTotalsCorrect()
        {
            var apple = new Product("Apple", 0.2);
            var orange = new Product("Orange", 0.5);
            var watermelon = new Product("Watermelon", 0.8);

            var basket = new Basket();
            basket.AddToBasket(apple, 4);
            basket.AddToBasket(orange, 3);
            basket.AddToBasket(watermelon, 5);

            var bogof = new List<Product> { apple };
            var threeForTwo = new List<Product> { watermelon };

            var calculator = new PosCalculator(threeForTwo, bogof);
            List<Tuple<double, string>> results;
            var calc = calculator.CalculateBasket(basket, out results);
            Assert.AreEqual(6.3, calc.TotalBeforeDiscount(), delta);
            Assert.AreEqual(5.1, calc.TotalAfterDiscount(), delta);
            Assert.AreEqual(1.2, calc.TotalDiscount(), delta);
        }

    }
}
