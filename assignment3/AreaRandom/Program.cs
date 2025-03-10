using System;
using System.Runtime.InteropServices;

// 抽象形状类
public abstract class Shape
{
    public abstract double CalculateArea();
    public abstract bool judge();
    public abstract void judge_print();
}

// 长方形类
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
        return length > 0 && width > 0;
    }
    public override double CalculateArea()
    {
        return judge() ? length * width : -1;
    }
}

// 正方形类
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
        return length > 0 && width > 0 && length == width;
    }
}

// 三角形类
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
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        return -1;
    }
    public override bool judge()
    {
        return a + b > c && a + c > b && b + c > a && a > 0 && b > 0 && c > 0;
    }
    public override void judge_print()
    {
        if (judge())
            Console.WriteLine("三边可构成三角形");
        else
            Console.WriteLine("三边不能构成三角形");
    }
}

// 形状工厂类
public class ShapeFactory
{
    private Random random = new Random();

    public Shape CreateShape()
    {
        Shape shape;
        do
        {
            int shapeType = random.Next(3); // 0: Rectangle, 1: Square, 2: Triangle
            switch (shapeType)
            {
                case 0:
                    double length = random.NextDouble() * 100;
                    double width = random.NextDouble() * 100;
                    shape = new Rectangle(length, width);
                    break;
                case 1:
                    double side = random.NextDouble() * 100;
                    shape = new Square(side);
                    break;
                case 2:
                    double a = random.NextDouble() * 100;
                    double b = random.NextDouble() * 100;
                    double c = random.NextDouble() * 100;
                    shape = new Triangle(a, b, c);
                    break;
                default:
                    throw new ArgumentException("Invalid shape type");
            }
        } while (!shape.judge());

        return shape;
    }
}

class Program
{
    static void Main()
    {
        ShapeFactory factory = new ShapeFactory();
        Shape[] shapes = new Shape[10];

        // 创建 10 个形状对象
        for (int i = 0; i < 10; i++)
        {
            shapes[i] = factory.CreateShape();
        }

        // 计算面积之和
        double totalArea = 0;
        foreach (Shape shape in shapes)
        {
            double area = shape.CalculateArea();
            Console.WriteLine(area);
            totalArea += area;

        }

        Console.WriteLine($"这些形状的面积之和为: {totalArea}");
    }
}