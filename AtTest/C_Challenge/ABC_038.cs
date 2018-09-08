using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_038
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            var array = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(input[i]);
            }
            array[n] = 0;

            int l = 0, r = 1;
            long allPat = 0;
            for (; r <= n; r++)
            {
                if (array[r] <= array[r - 1])
                {
                    allPat += (r - l) * (r - l + 1) / 2;
                    l = r;
                }
            }

            Console.WriteLine(allPat);
        }
    }
}
