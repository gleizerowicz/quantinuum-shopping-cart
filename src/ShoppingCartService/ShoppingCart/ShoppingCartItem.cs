namespace ShoppingCartService
{
    public class ShoppingCartItem
    {
        public int ProductCatalogId { get; }
        public string ProductName { get; }
        public string Desscription { get; }
        public Money Price { get; }

        public ShoppingCartItem(
          int productCatalogId,
          string productName,
          string description,
          Money price)
        {
            this.ProductCatalogId = productCatalogId;
            this.ProductName = productName;
            this.Desscription = description;
            this.Price = price;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var that = obj as ShoppingCartItem;
            return this.ProductCatalogId.Equals(that.ProductCatalogId);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.ProductCatalogId.GetHashCode();
        }
    }
}