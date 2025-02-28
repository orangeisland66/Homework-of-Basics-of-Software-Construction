using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            string[] m_n_line = Console.ReadLine().Split();
            int m = int.Parse(m_n_line[0]);
            int n = int.Parse(m_n_line[1]);
            //Console.WriteLine(m);
            //Console.WriteLine(n);
            int[,] matrix = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                string[] temp = Console.ReadLine().Split();
                //Console.Write(temp.Length);
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse((temp[j]));
                    //Console.Write(matrix[i, j]);
                }
            }

            bool is_toeplitz_matrix = true;
            for (int i = 0; i < m; i++)
            {
                if (i != 0 && (matrix[i - 1,i - 1] != matrix[i, i]))
                {
                    is_toeplitz_matrix = false;
                    break;
                }
                if (is_toeplitz_matrix) Console.WriteLine("这个矩阵是托普利茨矩阵");
                else Console.WriteLine("这个矩阵不是托普利茨矩阵");
            }
        }
    }
}
