using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_003
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
            int k = int.Parse(input[1]);
            var rateVideo = new int[n];
            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                rateVideo[i] = int.Parse(input[i]);
            }
            Array.Sort(rateVideo);
            double firstRate = 0;
            for (int i = n - k; i < n; i++)
            {
                firstRate = (firstRate + rateVideo[i]) * 0.5;
            }
            Console.WriteLine(firstRate);
        }
    }
}
