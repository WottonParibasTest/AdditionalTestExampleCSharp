namespace PointOfSaleTest
{
    public class Discount
    {
        public Product Product { get; private set; }
        public double DiscountValue { get; private set; }
        public string DiscountText { get; private set; }

        public Discount(Product product, double discountValue, string discountText)
        {
            Product = product;
            DiscountValue = discountValue;
            DiscountText = discountText;
        }
    }
}
