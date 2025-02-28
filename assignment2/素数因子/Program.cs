using System;
namespace ConsoleApp
{
    class Program
    {

        static void Main()
        {
            string s_num = Console.ReadLine();
            int num = int.Parse(s_num);


            bool[] isPrime = new bool[1001];
            int[] primeNums = new int[1001];
            int size_of_primeNums = 0;
            for (int i = 2; i < isPrime.Length; i++)
            {
                isPrime[i] = true;
            }
            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i] == true)
                {
                    for (int j = 2; j * i < primeNums.Length; j++)
                    {
                        isPrime[i * j] = false;
                    }
                    primeNums[size_of_primeNums++] = i;
                }

            }
            //for (int i = 0; i < size_of_primeNums; i++)
            //{
            //    Console.WriteLine(isPrime[i]);
            //}
            int sqrt_num = (int)Math.Sqrt(num);
            for (int i = 2; i < (int)sqrt_num; i++)
            {
                //Console.WriteLine(isPrime[2].ToString());
                if (isPrime[i] == true)
                {

                    while (num % i == 0)
                    {
                        num /= i;
                        Console.WriteLine(i.ToString());

                    }

                }
                if (num == 1) break;
                if (i == sqrt_num - 1) Console.WriteLine(num.ToString());
            }

        }

    }

}

