using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManager;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrderController(OrderContext context)
        {
            this._context = context;
        }

        // 获取所有订单
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
        }

        // 根据订单ID获取单个订单
        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetOrder(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // 创建新订单
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            order.CalculateTotalAmount();
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { orderId = order.OrderId }, order);
        }

        // 更新订单
        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId, Order order)
        {
            if (orderId != order.OrderId)
            {
                return BadRequest();
            }

            order.CalculateTotalAmount();
            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(orderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // 删除订单
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int orderId)
        {
            return _context.Orders.Any(e => e.OrderId == orderId);
        }
    }
}