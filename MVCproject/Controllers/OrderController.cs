using Microsoft.AspNetCore.Mvc;
using MVCproject.Models;
using MVCproject.Repository;
using System.Security.Claims;
using System.Threading.Tasks;
 // Assume repositories are used

namespace YourProjectName.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;

        public OrderController(IOrderRepository orderRepository, ICartRepository cartRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
        }

        // POST: Order/ConfirmOrder
        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(int[] selectedItems, Dictionary<int, int> quantities)
        {
            if (selectedItems == null || selectedItems.Length == 0)
            {
                return RedirectToAction("Index", "Cart"); // No items selected, redirect back to cart
            }

            // Get the current user ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Create a new order
            var newOrder = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                OrderItems = new List<OrderItem>()
            };

            foreach (var productId in selectedItems)
            {
                var cartItem = await _cartRepository.GetCartItemByUserIdAndProductIdAsync(userId, productId);
                if (cartItem != null)
                {
                    var quantity = quantities.ContainsKey(productId) ? quantities[productId] : 1;

                    // Add selected items to order
                    newOrder.OrderItems.Add(new OrderItem
                    {
                        ProductId = cartItem.ProductId,
                        Quantity = quantity,
                       // UnitPrice = cartItem.Product.Price
                    });

                    // Remove item from cart
                    await _cartRepository.RemoveFromCartAsync(cartItem.CartItemId);
                }
            }

            // Save the order
             _orderRepository.Insert(newOrder);
            await _orderRepository.SaveAsync();

            // Redirect to a success page or order history
            return RedirectToAction("OrderDetails", new { Id = newOrder.OrderId });
        }

        // GET: Order/OrderDetails/{orderId}
        public async Task<IActionResult> OrderDetails(int Id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(Id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order); // Assuming you have an OrderDetails view
        }

        // GET: Order/OrderHistory
        public async Task<IActionResult> OrderHistory()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);

            if (orders == null || !orders.Any())
            {
                ViewBag.Message = "You have no order history.";
                return View("OrderHistory", null); // Pass null to the view if there are no orders
            }

            return View("OrderHistory", orders);
        }

    }
}
