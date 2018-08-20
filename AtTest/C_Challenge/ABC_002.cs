using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_002
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int xa = int.Parse(input[0]);
            int ya = int.Parse(input[1]);
            int xb = int.Parse(input[2]);
            int yb = int.Parse(input[3]);
            int xc = int.Parse(input[4]);
            int yc = int.Parse(input[5]);

            int xb2 = xb - xa;
            int yb2 = yb - ya;
            int xc2 = xc - xa;
            int yc2 = yc - ya;

            double s = Math.Abs(1.0 * xb2 * yc2 - 1.0 * yb2 * xc2) / 2;

            Console.WriteLine(s);
        }
    }
}
