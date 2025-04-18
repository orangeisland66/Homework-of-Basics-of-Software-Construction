using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

// 订单明细类
namespace OrderManager
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Order Order { get; set; }

        public OrderDetails(int id, string productName, int quantity, double unitPrice)
        {
            Id = id;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   Id == details.Id &&
                   ProductName == details.ProductName &&
                   Quantity == details.Quantity &&
                   UnitPrice == details.UnitPrice;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ProductName, Quantity, UnitPrice);
        }

        public override string ToString()
        {
            return $"Id: {Id}, ProductName: {ProductName}, Quantity: {Quantity}, UnitPrice: {UnitPrice}";
        }
    }

    // 订单类
    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        //public ICollection<OrderDetail> OrderDetails { get; set; }
        public double TotalAmount { get; set; }

        // 计算总金额的方法
        public void CalculateTotalAmount()
        {
            TotalAmount = OrderDetails.Sum(d => d.Quantity * d.UnitPrice);
        }

        public Order(int orderId, string customer, List<OrderDetails> orderDetails)
        {
            OrderId = orderId;
            Customer = customer;
            OrderDetails = orderDetails;
        }
        public Order()
        {
        }
        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   OrderId == order.OrderId &&
                   Customer == order.Customer &&
                   OrderDetails.SequenceEqual(order.OrderDetails);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderId, Customer, OrderDetails);
        }

        public override string ToString()
        {
            string details = string.Join("\n  ", OrderDetails.Select(d => d.ToString()));
            return $"OrderId: {OrderId}, Customer: {Customer}, TotalAmount: {TotalAmount}\n  {details}";
        }
    }
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        // 添加接受 DbContextOptions<OrderContext> 参数的构造函数
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
            this.Database.EnsureCreated(); // 确保数据库已创建
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;user=root;password=123456;database=orderservice";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}