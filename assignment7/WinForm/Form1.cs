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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.EntityFrameworkCore;

namespace WinForm
{
    public partial class Form1 : Form
    {
        private OrderService orderService;
        public BindingSource orderBindingSource;
        private OrderContext orderContext;

        public Form1()
        {
            InitializeComponent();
            // 创建数据库上下文实例
            orderContext = new OrderContext();
            // 将数据库上下文传递给 OrderService
            orderService = new OrderService(orderContext);
            orderBindingSource = new BindingSource();
            dataGridView1.DataSource = orderBindingSource;
            dataGridView1.AllowUserToAddRows = false;
            search_comboBox.SelectedIndex = 0;
            // 初始化时加载所有订单
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                orderBindingSource.DataSource = orderService.SortOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载订单时出错: {ex.Message}");
            }
        }

        private void create_modify_button_Click(object sender, EventArgs e)
        {
            AddModifyOrderForm form = new AddModifyOrderForm(null, orderService, orderBindingSource);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadOrders();
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int orderId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                try
                {
                    orderService.DeleteOrder(orderId);
                    LoadOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            string queryType = search_comboBox.SelectedItem.ToString();
            string queryValue = search_textBox.Text;
            List<Order> result = new List<Order>();
            switch (queryType)
            {
                case "按订单号查询":
                    if (int.TryParse(queryValue, out int orderId))
                    {
                        result = orderService.QueryByOrderId(orderId);
                    }
                    break;
                case "按商品名称查询":
                    result = orderService.QueryByProductName(queryValue);
                    break;
                case "按客户查询":
                    result = orderService.QueryByCustomer(queryValue);
                    break;
                case "按订单金额查询":
                    if (double.TryParse(queryValue, out double amount))
                    {
                        result = orderService.QueryByTotalAmount(amount);
                    }
                    break;
            }
            orderBindingSource.DataSource = result;
        }

        private void modify_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int orderId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                Order order = orderService.QueryByOrderId(orderId).FirstOrDefault();
                if (order != null)
                {
                    AddModifyOrderForm form = new AddModifyOrderForm(order, orderService, orderBindingSource);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadOrders();
                    }
                }
            }
        }
    }
}