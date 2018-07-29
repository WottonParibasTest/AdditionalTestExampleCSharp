using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointOfSaleTest;
using System;

namespace PointOfSaleUnitTests
{
    [TestClass()]
    public class BasketTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddToBasketThrowsExceptionIfProductNull()
        {
            Basket basket = new Basket();
            basket.AddToBasket(null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToBasketThrowsExceptionIfCountLessThanOne()
        {
            Basket basket = new Basket();
            basket.AddToBasket(new Product("a", 0.1), 0);
        }
    }
}
