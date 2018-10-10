using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.AGC_027
{
    class A
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
            long x = long.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            var array = new long[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = long.Parse(input[i]);
            }
            Array.Sort(array);
            for(int i = 0; i < n; i++)
            {
                if (x < array[i])
                {
                    Console.WriteLine(i);
                    return;
                }
                x -= array[i];
                if (i == n - 1 && x > 0)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine(n);
        }
    }
}
