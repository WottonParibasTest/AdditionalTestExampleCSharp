namespace PointOfSaleTest
{
    public class Product
    {

        public double Price { get; private set; }
        public string Name { get; private set; }

        public Product(string name, double price)
        {
            Price = price;
            Name = name;
        }

        public string Id => Name.ToLowerInvariant();

        public string NameWithRightPadding => string.Format("{0, 20}", Name);

        public string ItemPrice2DecimalPlaces => Price.ToString("F2");
    }
}
