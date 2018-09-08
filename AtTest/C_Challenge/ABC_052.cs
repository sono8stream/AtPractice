using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_052
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }
            var cnt = new int[n + 1];
            for (int i = 2; i <= n; i++)
            {
                int sub = i;
                while (sub > 1)
                {
                    for (int j = 2; j <= i; j++)
                    {
                        if (sub % j == 0)
                        {
                            sub /= j;
                            cnt[j]++;
                            break;
                        }
                    }
                }
            }
            long allPat = 1;
            long mask = 1000000007;
            for(int i = 2; i <= n; i++)
            {
                allPat *= (cnt[i] + 1);
                allPat %= mask;
            }


            Console.WriteLine(allPat);
        }
    }
}
