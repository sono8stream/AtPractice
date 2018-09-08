using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Library.Permutation
{
    class Permutation
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            for (int i = 0; i < n; i++)
            {

            }
            Console.WriteLine("text");
        }

        static long Factorial(long n)
        {
            if (n == 0) return 1;

            return n * Factorial(n - 1);
        }

        static int[,] FactorialArray(int n)
        {
            long allPat = Factorial(n);
            var array = new int[allPat, n];
            var indexArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                indexArray[i] = i;
            }

            int modder = n;
            int divider = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < allPat; j++)
                {
                    array[j, i] = j / divider % modder;
                }
                divider *= modder;
                modder--;
            }

            var indexList = new List<int>();
            for (int i = 0; i < allPat; i++)
            {
                indexList.AddRange(indexArray);
                for (int j = 0; j < n; j++)
                {
                    int index = array[i, j];
                    array[i, j] = indexList[index];
                    indexList.RemoveAt(index);
                }
            }

            return array;
        }
    }
}
