using System.Collections.Generic;

namespace Carts
{
    public interface ICartDao
    {
        void Save(Cart newCart);
        IList<Cart> GetAllCarts();
    }
}