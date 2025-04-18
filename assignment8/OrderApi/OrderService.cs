//using System;
//using System.Collections.Generic;
//using System.Linq;

//// 订单服务类
//namespace OrderManager
//{
//    public class OrderService
//    {
//        private List<Order> orders;

//        public OrderService()
//        {
//            orders = new List<Order>();
//        }

//        // 添加订单
//        public void AddOrder(Order order)
//        {
//            if (orders.Contains(order))
//            {
//                throw new Exception("订单已存在，不能重复添加。");
//            }
//            orders.Add(order);
//        }

//        // 删除订单
//        public void DeleteOrder(int orderId)
//        {
//            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
//            if (order == null)
//            {
//                throw new Exception($"未找到订单号为 {orderId} 的订单，删除失败。");
//            }
//            orders.Remove(order);
//        }

//        // 修改订单
//        public void ModifyOrder(Order newOrder)
//        {
//            var oldOrder = orders.FirstOrDefault(o => o.OrderId == newOrder.OrderId);
//            if (oldOrder == null)
//            {
//                throw new Exception($"未找到订单号为 {newOrder.OrderId} 的订单，修改失败。");
//            }
//            orders.Remove(oldOrder);
//            if (orders.Contains(newOrder))
//            {
//                throw new Exception("修改后的订单已存在，不能重复添加。");
//            }
//            orders.Add(newOrder);
//        }

//        // 按订单号查询
//        public List<Order> QueryByOrderId(int orderId)
//        {
//            return orders.Where(o => o.OrderId == orderId).OrderBy(o => o.TotalAmount).ToList();
//        }

//        // 按商品名称查询
//        public List<Order> QueryByProductName(string productName)
//        {
//            return orders.Where(o => o.OrderDetails.Any(d => d.ProductName == productName))
//                         .OrderBy(o => o.TotalAmount).ToList();
//        }

//        // 按客户查询
//        public List<Order> QueryByCustomer(string customer)
//        {
//            return orders.Where(o => o.Customer == customer).OrderBy(o => o.TotalAmount).ToList();
//        }

//        // 按订单金额查询
//        public List<Order> QueryByTotalAmount(double amount)
//        {
//            return orders.Where(o => o.TotalAmount == amount).OrderBy(o => o.TotalAmount).ToList();
//        }

//        // 默认按订单号排序
//        public List<Order> SortOrders()
//        {
//            return orders.OrderBy(o => o.OrderId).ToList();
//        }

//        // 自定义排序
//        public List<Order> SortOrders(Func<Order, Order, int> comparison)
//        {
//            return orders.OrderBy(o => o, new CustomOrderComparer(comparison)).ToList();
//        }

//        private class CustomOrderComparer : IComparer<Order>
//        {
//            private readonly Func<Order, Order, int> comparison;

//            public CustomOrderComparer(Func<Order, Order, int> comparison)
//            {
//                this.comparison = comparison;
//            }

//            public int Compare(Order x, Order y)
//            {
//                return comparison(x, y);
//            }
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrderManager;
// 订单服务类
namespace OrderManager
{
    public class OrderService
    {
        private readonly OrderContext _context;

        public OrderService(OrderContext context)
        {
            // _context = new OrderContext(); // 每次创建新的上下文实例
            _context = context; // 每次创建新的上下文实例
        }

        // 添加订单
        public void AddOrder(Order order)
        {
            order.CalculateTotalAmount();
            var existingOrder = _context.Orders.Find(order.OrderId);
            if (existingOrder != null)
            {
                // 如果订单已存在，更新现有订单
                existingOrder.Customer = order.Customer;
                existingOrder.OrderDetails = order.OrderDetails;
                existingOrder.CalculateTotalAmount();
            }
            else
            {
                // 如果订单不存在，添加新订单
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }

        public void ModifyOrder(Order order)
        {
            var existingOrder = _context.Orders.Find(order.OrderId);
            if (existingOrder != null)
            {
                existingOrder.Customer = order.Customer;
                existingOrder.OrderDetails = order.OrderDetails;
                existingOrder.CalculateTotalAmount();
                _context.SaveChanges();
            }
        }

        // 删除订单
        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new Exception($"未找到订单号为 {orderId} 的订单，删除失败。");
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        // 按订单号查询
        public List<Order> QueryByOrderId(int orderId)
        {
            return _context.Orders.Include(o => o.OrderDetails)
                                  .Where(o => o.OrderId == orderId)
                                  .OrderBy(o => o.TotalAmount)
                                  .ToList();
        }

        // 按商品名称查询
        public List<Order> QueryByProductName(string productName)
        {
            return _context.Orders.Include(o => o.OrderDetails)
                                  .Where(o => o.OrderDetails.Any(d => d.ProductName == productName))
                                  .OrderBy(o => o.TotalAmount)
                                  .ToList();
        }

        // 按客户查询
        public List<Order> QueryByCustomer(string customer)
        {
            return _context.Orders.Include(o => o.OrderDetails)
                                  .Where(o => o.Customer == customer)
                                  .OrderBy(o => o.TotalAmount)
                                  .ToList();
        }

        // 按订单金额查询
        public List<Order> QueryByTotalAmount(double amount)
        {
            return _context.Orders.Include(o => o.OrderDetails)
                                  .Where(o => o.TotalAmount == amount)
                                  .OrderBy(o => o.TotalAmount)
                                  .ToList();
        }

        // 默认按订单号排序
        public List<Order> SortOrders()
        {
            return _context.Orders.Include(o => o.OrderDetails)
                                  .OrderBy(o => o.OrderId)
                                  .ToList();
        }

        // 自定义排序
        public List<Order> SortOrders(Func<Order, Order, int> comparison)
        {
            var orders = _context.Orders.Include(o => o.OrderDetails).ToList();
            orders.Sort(new CustomOrderComparer(comparison));
            return orders;
        }

        private class CustomOrderComparer : IComparer<Order>
        {
            private readonly Func<Order, Order, int> comparison;

            public CustomOrderComparer(Func<Order, Order, int> comparison)
            {
                this.comparison = comparison;
            }

            public int Compare(Order x, Order y)
            {
                return comparison(x, y);
            }
        }
    }
}