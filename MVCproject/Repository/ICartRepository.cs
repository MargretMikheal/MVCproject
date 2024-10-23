using MVCproject.Models;

namespace MVCproject.Repository
{
    public interface ICartRepository:ITRepository<Cart>
    {
        Task RemoveFromCartAsync(int cartItemId);
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task<CartItem> GetCartItemByUserIdAndProductIdAsync(string userId, int productId);
        Task UpdateCartAsync(Cart cart);
    }
}
