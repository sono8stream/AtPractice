using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_104
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
            int r = int.Parse(Console.ReadLine());

            if (r < 1200)
            {
                Console.WriteLine("ABC");
            }
            else if (r < 2800)
            {
                Console.WriteLine("ARC");
            }
            else
            {
                Console.WriteLine("AGC");
            }
        }
    }
}
