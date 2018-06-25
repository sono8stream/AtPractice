using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CumulativeSum
{
    class ABC_087_C
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] array = new int[2, n];
            for(int i = 0; i < 2; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = int.Parse(input[j]);
                }
            }

            int maxPoint = 0;
            for(int i = 0; i < n; i++)
            {
                int sum = 0;
                int y = 0;
                for(int j = 0; j < n; j++)
                {
                    if (j == i)
                    {
                        sum += array[y, j];
                        y++;
                        sum += array[y, j];
                    }
                    else
                    {
                        sum += array[y, j];
                    }
                }
                if (sum > maxPoint)
                {
                    maxPoint = sum;
                }
            }

            Console.WriteLine(maxPoint);
        }
    }
}
