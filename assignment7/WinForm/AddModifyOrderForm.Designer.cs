namespace WinForm
{
    partial class AddModifyOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            A = new System.Windows.Forms.Button();
            B = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            dataGridView2 = new System.Windows.Forms.DataGridView();
            idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            unitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            orderBindingSource = new System.Windows.Forms.BindingSource(components);
            button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(262, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(175, 34);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(262, 174);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(175, 34);
            textBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(552, 270);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(131, 40);
            button1.TabIndex = 2;
            button1.Text = "确定";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSave_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(262, 270);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(131, 40);
            button2.TabIndex = 3;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnCancel_Click;
            // 
            // A
            // 
            A.Location = new System.Drawing.Point(552, 65);
            A.Name = "A";
            A.Size = new System.Drawing.Size(131, 40);
            A.TabIndex = 4;
            A.Text = "商品A";
            A.UseVisualStyleBackColor = true;
            A.Click += A_Click;
            // 
            // B
            // 
            B.Location = new System.Drawing.Point(552, 111);
            B.Name = "B";
            B.Size = new System.Drawing.Size(131, 40);
            B.TabIndex = 5;
            B.Text = "商品B";
            B.UseVisualStyleBackColor = true;
            B.Click += B_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(225, 65);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 28);
            label1.TabIndex = 6;
            label1.Text = "id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(181, 180);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 28);
            label2.TabIndex = 7;
            label2.Text = "用户名";
            // 
            // dataGridView2
            // 
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { idDataGridViewTextBoxColumn, productNameDataGridViewTextBoxColumn, quantityDataGridViewTextBoxColumn, unitPriceDataGridViewTextBoxColumn });
            dataGridView2.DataMember = "OrderDetails";
            dataGridView2.DataSource = orderBindingSource;
            dataGridView2.Location = new System.Drawing.Point(3, 354);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 72;
            dataGridView2.Size = new System.Drawing.Size(1361, 307);
            dataGridView2.TabIndex = 8;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 9;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 175;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            productNameDataGridViewTextBoxColumn.HeaderText = "ProductName";
            productNameDataGridViewTextBoxColumn.MinimumWidth = 9;
            productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            productNameDataGridViewTextBoxColumn.Width = 175;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            quantityDataGridViewTextBoxColumn.MinimumWidth = 9;
            quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            quantityDataGridViewTextBoxColumn.Width = 175;
            // 
            // unitPriceDataGridViewTextBoxColumn
            // 
            unitPriceDataGridViewTextBoxColumn.DataPropertyName = "UnitPrice";
            unitPriceDataGridViewTextBoxColumn.HeaderText = "UnitPrice";
            unitPriceDataGridViewTextBoxColumn.MinimumWidth = 9;
            unitPriceDataGridViewTextBoxColumn.Name = "unitPriceDataGridViewTextBoxColumn";
            unitPriceDataGridViewTextBoxColumn.Width = 175;
            // 
            // orderBindingSource
            // 
            orderBindingSource.DataSource = typeof(OrderManager.Order);
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(552, 157);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(131, 40);
            button3.TabIndex = 9;
            button3.Text = "商品C";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // AddModifyOrderForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1363, 660);
            Controls.Add(button3);
            Controls.Add(dataGridView2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(B);
            Controls.Add(A);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "AddModifyOrderForm";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button A;
        private System.Windows.Forms.Button B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.Button button3;
    }
}