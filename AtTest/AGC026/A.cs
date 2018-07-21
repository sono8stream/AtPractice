using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.AGC026
{
    class A
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(input[i]);
            }

            int count = 0;
            for(int i = 1; i < n; i++)
            {
                if (array[i - 1] == array[i])
                {
                    array[i]++;
                    count++;
                    if (i < n - 1 && array[i] == array[i + 1])
                    {
                        array[i] += array[i + 1];
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
