using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ForBlue.ABC_070
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
            var ts = new long[n];
            for (int i = 0; i < n; i++)
            {
                ts[i] = long.Parse(Console.ReadLine());
            }

            Array.Sort(ts);
            long gcm = 1;
            long lcm = 1;

            for (int i = 0; i < n; i++)
            {
                if (ts[i] < lcm)
                {
                    gcm = GCM(lcm, ts[i]);
                }
                else
                {
                    gcm = GCM(ts[i], lcm);
                }
                lcm = lcm / gcm * ts[i];
                //Console.WriteLine(gcm);
                //Console.WriteLine(lcm);
            }

            Console.WriteLine(lcm);
        }

        static long GCM(long a,long b)
        {
            if (b == 0) return a;

            return GCM(b, a % b);
        }
    }
}