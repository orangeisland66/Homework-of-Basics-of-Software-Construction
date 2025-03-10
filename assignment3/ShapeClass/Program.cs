using System;
using System.Runtime.InteropServices;
namespace ConsoleApp
{
    public abstract class Shape
    {
        //public Shape() { }
        public abstract double CalculateArea();
        public abstract bool judge();
        public abstract void judge_print();


    }
    public class Rectangle : Shape
    {
        protected double length, width;
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public override void judge_print()
        {
            if (judge())
            {
                Console.WriteLine("能构成长方形");
            }
            else
            {
                Console.WriteLine("不构成长方形");
            }
        }
        public override bool judge()
        {
            if (length > 0 && width > 0) return true;
            return false;
        }
        public override double CalculateArea()
        {
            if (judge())return length * width;
            return -1;
        }
    }
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }
        public override void judge_print()
        {
            if (judge())
            {
                Console.WriteLine("能构成正方形");
            }
            else
            {
                Console.WriteLine("不构成正方形");
            }
        }
        public override bool judge()
        {
            if (length > 0 && width > 0 && length == width) return true;
            return false;
        }
    }
    public class Triangle : Shape
    {
        double a, b, c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double CalculateArea()
        {
            if (judge())
            {
                double p = (a + b + c) / 2;
                double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                return area;
            }
            return -1;
        }
        public override bool judge()
        {
            if (a + b > c && a + c > b && b + c > a && a > 0 && b > 0 && c > 0)
                return true;
            else return false;
        }
        public override void judge_print()
        {
            if (judge()) Console.WriteLine("三边可构成三角形");
            else Console.WriteLine("三边不能构成三角形");
        }
    }
    class Program
    {
        static void Main()
        {
            Shape shape1 = new Rectangle(6, 7);
            Shape shape2 =new Square(5);
            Shape shape3 =new Triangle(2,2,2);
            shape1.judge_print();
            shape2.judge_print();
            shape3.judge_print();

            Console.WriteLine(shape1.CalculateArea().ToString());
            Console.WriteLine(shape2.CalculateArea().ToString());
            Console.WriteLine(shape3.CalculateArea().ToString());

        }
    }
}