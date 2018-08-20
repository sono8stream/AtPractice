using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ForBlue.ABC_078
{
    class D
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
            int z = int.Parse(input[1]);
            int w = int.Parse(input[2]);
            var array = new int[n];
            string[] input2 = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(input2[i]);
            }

            int abs1 = Math.Abs(array[array.Length - 1] - w);
            int abs2 = 0;
            if (n >= 2) abs2 = Math.Abs(array[array.Length - 2] - array[array.Length - 1]);
            if (abs1 < abs2)
            {
                Console.WriteLine(abs2);
            }
            else
            {
                Console.WriteLine(abs1);
            }
        }
    }
}
