using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCartService
{
    public interface IProductCatalogClient
    {
        Task<IEnumerable<ShoppingCartItem>>
          GetShoppingCartItems(int[] productCatalogueIds);
    }
}
