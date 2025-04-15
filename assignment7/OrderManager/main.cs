using System;
using System.Collections.Generic;
using OrderManager;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        // 创建 OrderContext 实例
        using (var context = new OrderContext())
        {
            // 将 OrderContext 实例传入 OrderService 构造函数
            OrderService orderService = new OrderService(context);

            // 测试添加订单
            try
            {
                List<OrderDetails> details1 = new List<OrderDetails>
                {
                    new OrderDetails(1, "商品A", 2, 10.0),
                    new OrderDetails(2, "商品B", 3, 20.0)
                };
                Order order1 = new Order(1, "客户甲", details1);
                orderService.AddOrder(order1);
                Console.WriteLine("订单添加成功：");
                Console.WriteLine(order1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                List<OrderDetails> details2 = new List<OrderDetails>
                {
                    new OrderDetails(3, "商品C", 1, 30.0),
                    new OrderDetails(4, "商品D", 2, 25.0)
                };
                Order order2 = new Order(2, "客户乙", details2);
                orderService.AddOrder(order2);
                Console.WriteLine("订单添加成功：");
                Console.WriteLine(order2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                List<OrderDetails> details3 = new List<OrderDetails>
                {
                    new OrderDetails(5, "商品A", 4, 10.0),
                    new OrderDetails(6, "商品E", 3, 15.0)
                };
                Order order3 = new Order(3, "客户甲", details3);
                orderService.AddOrder(order3);
                Console.WriteLine("订单添加成功：");
                Console.WriteLine(order3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 测试删除订单
            try
            {
                orderService.DeleteOrder(1);
                Console.WriteLine("订单删除成功。");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 重新添加订单用于后续测试
            List<OrderDetails> details4 = new List<OrderDetails>
            {
                new OrderDetails(1, "商品A", 2, 10.0),
                new OrderDetails(2, "商品B", 3, 20.0)
            };
            Order order4 = new Order(1, "客户甲", details4);
            orderService.AddOrder(order4);

            // 测试修改订单
            try
            {
                List<OrderDetails> newDetails = new List<OrderDetails>
                {
                    new OrderDetails(1, "商品A", 3, 10.0),
                    new OrderDetails(2, "商品B", 4, 20.0)
                };
                Order newOrder = new Order(1, "客户甲", newDetails);
                orderService.ModifyOrder(newOrder);
                Console.WriteLine("订单修改成功：");
                Console.WriteLine(newOrder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 测试按订单号查询
            var ordersByOrderId = orderService.QueryByOrderId(1);
            Console.WriteLine("按订单号查询结果：");
            foreach (var order in ordersByOrderId)
            {
                Console.WriteLine(order);
            }

            // 测试按商品名称查询
            var ordersByProductName = orderService.QueryByProductName("商品A");
            Console.WriteLine("按商品名称查询结果：");
            foreach (var order in ordersByProductName)
            {
                Console.WriteLine(order);
            }

            // 测试按客户查询
            var ordersByCustomer = orderService.QueryByCustomer("客户甲");
            Console.WriteLine("按客户查询结果：");
            foreach (var order in ordersByCustomer)
            {
                Console.WriteLine(order);
            }

            // 测试按订单金额查询
            var ordersByTotalAmount = orderService.QueryByTotalAmount(110.0);
            Console.WriteLine("按订单金额查询结果：");
            foreach (var order in ordersByTotalAmount)
            {
                Console.WriteLine(order);
            }

            // 测试默认排序
            var sortedOrders = orderService.SortOrders();
            Console.WriteLine("默认按订单号排序结果：");
            foreach (var order in sortedOrders)
            {
                Console.WriteLine(order);
            }

            // 测试自定义排序
            var sortedCostomizedOrders = orderService.SortOrders((x, y) => x.TotalAmount.CompareTo(y.TotalAmount));
            Console.WriteLine("按订单总金额自定义排序结果：");
            foreach (var order in sortedCostomizedOrders)
            {
                Console.WriteLine(order);
            }
        }
    }
}