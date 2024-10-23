using Microsoft.EntityFrameworkCore;
using MVCproject.config;
using MVCproject.Models;

namespace MVCproject.Repository
{
    public class CartRepository : TRepository<Cart>, ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task RemoveFromCartAsync(int cartItemId)
        {
            // Find the cart item by its ID
            var cartItem = await _context.CartItems.FindAsync(cartItemId);

            // If the cart item exists, remove it from the context
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);

                // Save the changes to the database
                await _context.SaveChangesAsync();
            }
        }


        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<CartItem> GetCartItemByUserIdAndProductIdAsync(string userId, int productId)
        {
            var cart = await GetCartByUserIdAsync(userId);

            if (cart == null) { return null; }

            var cartItem=cart.CartItems.FirstOrDefault(c => c.ProductId == productId);
            return cartItem;
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            // Attach the cart to the context if it's not already being tracked
            var existingCart = await _context.Carts
                                .Include(c => c.CartItems)
                                .FirstOrDefaultAsync(c => c.CartId == cart.CartId);

            if (existingCart != null)
            {
                // Update the cart properties
                _context.Entry(existingCart).CurrentValues.SetValues(cart);

                // Update the cart items
                foreach (var item in cart.CartItems)
                {
                    var existingItem = existingCart.CartItems
                                       .FirstOrDefault(i => i.CartItemId == item.CartItemId);

                    if (existingItem != null)
                    {
                        // Update existing cart item
                        _context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                    else
                    {
                        // Add new item to the cart
                        existingCart.CartItems.Add(item);
                    }
                }

                // Remove items that are no longer in the cart
                foreach (var existingItem in existingCart.CartItems.ToList())
                {
                    if (!cart.CartItems.Any(i => i.CartItemId == existingItem.CartItemId))
                    {
                        _context.CartItems.Remove(existingItem);
                    }
                }

                // Save the changes
                await _context.SaveChangesAsync();
            }
        }
    }
}
