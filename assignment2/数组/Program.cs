using System;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("请输入一位数组的长度：");
            int length = int.Parse(Console.ReadLine());
            
            int[] arr = new int[length];
            Console.WriteLine("请输入一位数组：");
            string[] inputElements = Console.ReadLine().Split();

            for (int i=0;i<length;i++)
            {
                arr[i]=int.Parse(inputElements[i]);
            }


            double max = arr[0], min = arr[0];
            double avg = 0;
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            avg = sum / arr.Length;
            //max = ToString(max);
            Console.WriteLine(max.ToString());
            Console.WriteLine(min.ToString());
            Console.WriteLine(avg.ToString());
            Console.WriteLine(sum.ToString());
            //con.ToString(),avg.ToString(),sum.ToString());
        }
    }
}
