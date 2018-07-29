using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointOfSaleTest;
using System;

namespace PointOfSaleUnitTests
{
    [TestClass()]
    public class CalculationTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculationConstructorThrowsExceptionIfBasketIsNull()
        {
            var calc = new Calculation(null);
        }
    }
}
