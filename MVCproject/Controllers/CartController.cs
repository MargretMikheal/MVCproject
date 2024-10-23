using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCproject.Models;
using MVCproject.Repository;

namespace MVCproject.Controllers
{
    public class CartController : Controller
    {
        private readonly ITRepository<Product> _productRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITRepository<CartItem> _cartItemRepository;
        private readonly ICartRepository _CartRepository;

        public CartController(ITRepository<Product> productRepository,
                              UserManager<ApplicationUser> userManager,
                              ITRepository<CartItem> cartItemRepository,
                              ICartRepository cartRepository)
        {
            _productRepository = productRepository;
            _userManager = userManager;
            _cartItemRepository = cartItemRepository;
            _CartRepository = cartRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            // Get the current user ID
            var userId = _userManager.GetUserId(User);

            // Find the product by ID
            var product = _productRepository.GetById(productId);

            if (product == null)
            {
                return NotFound();
            }
            if (quantity > product.StockQuantity)
            {
                ModelState.AddModelError("", $"Only {product.StockQuantity} items are available for {product.Name}.");
                return RedirectToAction("ProductDetails", new { id = productId });
            }

            // Find if the cart already exists for this user
            var cart = await _CartRepository.GetCartByUserIdAsync(userId);

            // If the cart does not exist, create a new cart
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CartItems = new List<CartItem>()
                };

                _CartRepository.Insert(cart);
            }

            // Check if the product already exists in the cart
            var cartItem = cart.CartItems.FirstOrDefault(c => c.ProductId == productId);

            if (cartItem != null)
            {
                // Update the quantity if the product is already in the cart
                cartItem.Quantity += quantity;
            }
            else
            {
                // Add new cart item
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    //Price = product.Price
                });
            }

            await _cartItemRepository.SaveAsync();
            return RedirectToAction("Index", "Home"); // Redirect to Cart page or another suitable page
        }

        public async Task<IActionResult> Index()
        { 
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var cart= await _CartRepository.GetCartByUserIdAsync(user.Id);
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var cart = await _CartRepository.GetCartByUserIdAsync(user.Id);
            if (cart == null) return NotFound();

            var cartItem = cart.CartItems.FirstOrDefault(x => x.CartItemId == cartItemId);
            if (cartItem != null)
            {
                cart.CartItems.Remove(cartItem);
                await _CartRepository.UpdateCartAsync(cart);
            }

            return RedirectToAction("Index");
        }


    }
}
