using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_102
{
    class ABC_102_B
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] array = new long[n];
            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                array[i] = long.Parse(input[i]);
            }

            long marginMax = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    long margin = Math.Abs(array[i] - array[j]);
                    if (margin > marginMax)
                    {
                        marginMax = margin;
                    }
                }
            }

            Console.WriteLine(marginMax);
        }
    }
}
