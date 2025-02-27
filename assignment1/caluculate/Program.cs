using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caluculate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s,t,op;
            double a, b,ans;
            Console.WriteLine("Enter the first number");
            s = Console.ReadLine();
            a=Double.Parse(s);
            Console.WriteLine("Enter the second number");
            t = Console.ReadLine();
            b = Double.Parse(t);
            Console.WriteLine("Enter the operator");
            op = Console.ReadLine();
            bool flag = true;
            if (op == "+")
            {
                ans = a + b;
                //Console.WriteLine("The sum is " + ans);
            }
            else if (op == "-")
            {
                ans = a - b;
                //Console.WriteLine("The difference is " + ans);
            }
            else if (op == "*")
            {
                ans = a * b;
                //Console.WriteLine("The product is " + ans);
            }
            else if (op == "/")
            {
                ans = a / b;
                //Console.WriteLine("The division is " + ans);
            }
            else
            {
                Console.WriteLine("Invalid operator");
                ans = 0;
                flag= false;
            }
            if (flag == true)
                Console.WriteLine($"ans is {ans}");

        }
    }
}
