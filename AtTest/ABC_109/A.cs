using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_109
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
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            string result = a % 2 == 1 && b % 2 == 1 ? "Yes" : "No";
            Console.WriteLine(result);
        }
    }
}
