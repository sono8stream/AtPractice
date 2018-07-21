using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_102
{
    class ABC_102_C
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            long[] array = new long[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = long.Parse(input[i]) - (i + 1);
            }

            Array.Sort(array);
            long med;
            if (n % 2 == 0)
            {
                med = (array[n / 2-1] + array[n / 2]) / 2;
            }
            else
            {
                med = array[n / 2];
            }

            long result = 0;
            for (int i = 0; i < n; i++)
            {
                result += Math.Abs(array[i] - med);
            }
            Console.WriteLine(result);
        }
    }
}