using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculate_window_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetDomainUpDownItems();
            domainUpDown1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            string t = textBox2.Text;
            string op = domainUpDown1.Text;
            double a, b, ans;
            a = Double.Parse(s);
            b = Double.Parse(t);
            switch(op)
            {
                case "+":
                    ans = a + b;
                    break;
                case "-":
                    ans = a - b;
                    break;
                case "*":
                    ans = a * b;
                    break;
                case "/":
                    ans = a / b;
                    break;
                default:
                    ans = 0;
                    break;
            }
            label1.Text = ans.ToString();

        }


        private void SetDomainUpDownItems()
        {
   
            domainUpDown1.Items.Clear();
            string[] items = { "+", "-", "*","/" };
            domainUpDown1.Items.AddRange(items);

        }
 
    }
}
