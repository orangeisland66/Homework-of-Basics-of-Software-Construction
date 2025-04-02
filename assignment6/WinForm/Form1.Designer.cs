using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace WinForm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            orderIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalAmountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);
            orderDetailsBindingSource = new BindingSource(components);
            create_button = new Button();
            delete_button = new Button();
            search_button = new Button();
            search_textBox = new TextBox();
            search_comboBox = new ComboBox();
            modify_button = new Button();
            bindingSource2 = new BindingSource(components);
            orderDetailsBindingSource1 = new BindingSource(components);
            bindingSource3 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderDetailsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderDetailsBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource3).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { orderIdDataGridViewTextBoxColumn, customerDataGridViewTextBoxColumn, totalAmountDataGridViewTextBoxColumn });
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Location = new System.Drawing.Point(4, 427);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 72;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new System.Drawing.Size(2163, 869);
            dataGridView1.TabIndex = 0;
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            orderIdDataGridViewTextBoxColumn.DataPropertyName = "OrderId";
            orderIdDataGridViewTextBoxColumn.HeaderText = "OrderId";
            orderIdDataGridViewTextBoxColumn.MinimumWidth = 9;
            orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            orderIdDataGridViewTextBoxColumn.Width = 175;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            customerDataGridViewTextBoxColumn.HeaderText = "Customer";
            customerDataGridViewTextBoxColumn.MinimumWidth = 9;
            customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            customerDataGridViewTextBoxColumn.Width = 175;
            // 
            // totalAmountDataGridViewTextBoxColumn
            // 
            totalAmountDataGridViewTextBoxColumn.DataPropertyName = "TotalAmount";
            totalAmountDataGridViewTextBoxColumn.HeaderText = "TotalAmount";
            totalAmountDataGridViewTextBoxColumn.MinimumWidth = 9;
            totalAmountDataGridViewTextBoxColumn.Name = "totalAmountDataGridViewTextBoxColumn";
            totalAmountDataGridViewTextBoxColumn.ReadOnly = true;
            totalAmountDataGridViewTextBoxColumn.Width = 175;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(OrderManager.Order);
            // 
            // orderDetailsBindingSource
            // 
            orderDetailsBindingSource.DataMember = "OrderDetails";
            orderDetailsBindingSource.DataSource = bindingSource1;
            // 
            // create_button
            // 
            create_button.Location = new System.Drawing.Point(98, 225);
            create_button.Margin = new Padding(4);
            create_button.Name = "create_button";
            create_button.Size = new System.Drawing.Size(196, 103);
            create_button.TabIndex = 1;
            create_button.Text = "创建订单";
            create_button.UseVisualStyleBackColor = true;
            create_button.Click += create_modify_button_Click;
            // 
            // delete_button
            // 
            delete_button.Location = new System.Drawing.Point(340, 225);
            delete_button.Margin = new Padding(4);
            delete_button.Name = "delete_button";
            delete_button.Size = new System.Drawing.Size(196, 103);
            delete_button.TabIndex = 2;
            delete_button.Text = "删除订单";
            delete_button.UseVisualStyleBackColor = true;
            delete_button.Click += delete_button_Click;
            // 
            // search_button
            // 
            search_button.Location = new System.Drawing.Point(579, 225);
            search_button.Margin = new Padding(4);
            search_button.Name = "search_button";
            search_button.Size = new System.Drawing.Size(196, 103);
            search_button.TabIndex = 3;
            search_button.Text = "查询订单";
            search_button.UseVisualStyleBackColor = true;
            search_button.Click += search_button_Click;
            // 
            // search_textBox
            // 
            search_textBox.Location = new System.Drawing.Point(579, 174);
            search_textBox.Margin = new Padding(4);
            search_textBox.Name = "search_textBox";
            search_textBox.Size = new System.Drawing.Size(211, 34);
            search_textBox.TabIndex = 5;
            // 
            // search_comboBox
            // 
            search_comboBox.FormattingEnabled = true;
            search_comboBox.Items.AddRange(new object[] { "按订单号查询", "按商品名称查询", "按客户查询", "按订单金额查询" });
            search_comboBox.Location = new System.Drawing.Point(579, 112);
            search_comboBox.Name = "search_comboBox";
            search_comboBox.Size = new System.Drawing.Size(212, 36);
            search_comboBox.TabIndex = 6;
            // 
            // modify_button
            // 
            modify_button.Location = new System.Drawing.Point(813, 225);
            modify_button.Name = "modify_button";
            modify_button.Size = new System.Drawing.Size(196, 103);
            modify_button.TabIndex = 9;
            modify_button.Text = "修改订单";
            modify_button.UseVisualStyleBackColor = true;
            modify_button.Click += modify_button_Click;
            // 
            // bindingSource2
            // 
            bindingSource2.DataSource = typeof(OrderManager.Order);
            // 
            // orderDetailsBindingSource1
            // 
            orderDetailsBindingSource1.DataMember = "OrderDetails";
            orderDetailsBindingSource1.DataSource = bindingSource1;
            // 
            // bindingSource3
            // 
            bindingSource3.DataSource = typeof(OrderManager.Order);
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1115, 887);
            Controls.Add(modify_button);
            Controls.Add(search_comboBox);
            Controls.Add(search_textBox);
            Controls.Add(search_button);
            Controls.Add(delete_button);
            Controls.Add(create_button);
            Controls.Add(dataGridView1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderDetailsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderDetailsBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Button create_button;
        private Button delete_button;
        private Button search_button;
        private TextBox delete_textBox;
        private TextBox search_textBox;
        private ComboBox search_comboBox;
        private BindingSource bindingSource1;
        private Button modify_button;
        private BindingSource bindingSource2;
        private BindingSource orderDetailsBindingSource;
        private BindingSource orderDetailsBindingSource1;
        private BindingSource bindingSource3;
        private DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalAmountDataGridViewTextBoxColumn;
    }
}

