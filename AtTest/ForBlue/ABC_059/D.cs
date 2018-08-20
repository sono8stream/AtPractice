using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ForBlue.ABC_059
{
    class D
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            long x = long.Parse(input[0]);
            long y = long.Parse(input[1]);

            if (Math.Abs(x - y) <= 1)
            {
                Console.WriteLine("Brown");
            }
            else
            {
                Console.WriteLine("Alice");
            }
        }
    }
}
