using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApplication
{

    // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> current = head;
            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }

            Console.WriteLine("链表元素:");
            intlist.ForEach(x => Console.Write(x+" "));
            Console.WriteLine();

            int max = int.MinValue;
            intlist.ForEach(x => max = Math.Max(max, x));
            Console.WriteLine($"最大值: {max}");

            int min = int.MaxValue;
            intlist.ForEach(x => min = Math.Min(min, x));
            Console.WriteLine($"最小值: {min}");

            int sum = 0;
            intlist.ForEach(x => sum += x);
            Console.WriteLine($"求和: {sum}");


            //GenericList<string> strList = new GenericList<string>();
            //for (int x = 0; x < 10; x++)
            //{
            //    strList.Add("str" + x);
            //}

            //Console.WriteLine("\n字符串链表元素:");
            //strList.ForEach(x => Console.WriteLine(x));



        }

    }
}