namespace ShoppingCartService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCart
    {
        private HashSet<ShoppingCartItem> items = new HashSet<ShoppingCartItem>();

        public int UserId { get; }
        public IEnumerable<ShoppingCartItem> Items { get { return items; } }

        public ShoppingCart(int userId)
        {
            this.UserId = userId;
        }

        public void AddItems(
          IEnumerable<ShoppingCartItem> shoppingCartItems,
          IEventStore eventStore)
        {
            foreach (var item in shoppingCartItems)
                if (this.items.Add(item))
                    eventStore.Raise(
                      "ShoppingCartItemAdded",
                      new { UserId, item });
        }

        public void RemoveItems(
          int[] productCatalogIds,
          IEventStore eventStore)
        {
            items.RemoveWhere(i => productCatalogIds.Contains(i.ProductCatalogId));
        }
    }
}