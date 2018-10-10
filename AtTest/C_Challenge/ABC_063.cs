using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_063
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var ss = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                ss[i] = int.Parse(Console.ReadLine());
                sum += ss[i];
            }
            Array.Sort(ss);
            if (sum % 10 == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    if (ss[i] % 10 == 0) continue;

                    Console.WriteLine(sum - ss[i]);
                    return;
                }
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(sum);
            }
        }
    }
}
