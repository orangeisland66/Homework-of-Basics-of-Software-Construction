using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManager;
//using WinForm;
namespace WinForm
{
    public partial class AddModifyOrderForm : Form
    {

        private Order order;
        private OrderService orderService;
        List<OrderDetails> details = new List<OrderDetails> { };
        public BindingSource orderDetailsBindingSource;
        public AddModifyOrderForm(Order order, OrderService orderService, BindingSource orderBindingSource)
        {
            InitializeComponent();
            this.order = order;
            this.orderService = orderService;
            orderDetailsBindingSource = new BindingSource();

            if (order != null)
            {
                textBox1.Text = order.OrderId.ToString();
                textBox2.Text = order.Customer;
                // 初始化details为现有订单的明细副本
                details = order.OrderDetails.ToList();
                orderDetailsBindingSource.DataSource = details; // 直接绑定到details列表
                dataGridView2.DataSource = order;
            }
            else
            {
                this.order = new Order(0, "", new List<OrderDetails>());
                details = this.order.OrderDetails.ToList();
                orderDetailsBindingSource.DataSource = details;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                order.OrderId = int.Parse(textBox1.Text);
                order.Customer = textBox2.Text;
                // 更新订单的明细列表为当前details
                order.OrderDetails = details;
                if (orderService.QueryByOrderId(order.OrderId).Count == 0)
                {
                    orderService.AddOrder(order);
                }
                else
                {
                    orderService.ModifyOrder(order);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void A_Click(object sender, EventArgs e)
        {
            details.Add(new OrderDetails(1, "商品A", 1, 10));
            dataGridView2.DataSource = orderDetailsBindingSource;
            orderDetailsBindingSource.ResetBindings(false); // 刷新绑定
        }

        private void B_Click(object sender, EventArgs e)
        {
            details.Add(new OrderDetails(2, "商品B", 1, 5));
            dataGridView2.DataSource = orderDetailsBindingSource;
            orderDetailsBindingSource.ResetBindings(false); // 刷新绑定
        }

        private void button3_Click(object sender, EventArgs e)
        {
            details.Add(new OrderDetails(2, "商品C", 1, 15));
            dataGridView2.DataSource = orderDetailsBindingSource;
            orderDetailsBindingSource.ResetBindings(false); // 刷新绑定
        }
    }
}
