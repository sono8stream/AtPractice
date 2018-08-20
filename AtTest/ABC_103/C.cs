﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_103
{
    class C
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
            var array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(input[i]);
            }
            long f = 0;
            for(int i = 0; i < n; i++)
            {
                f += array[i] - 1;
            }
            Console.WriteLine(f);
        }
    }
}
