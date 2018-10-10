using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.AGC_027
{
    class C
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
    }
}
