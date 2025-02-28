using System;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            bool[] isPrime = new bool[101];
            int[] primeNums = new int[101];
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
            for (int i = 0; i < size_of_primeNums; i++)
            {
                Console.Write(primeNums[i]);
                Console.Write(' ');

            }
        }
    }
}
