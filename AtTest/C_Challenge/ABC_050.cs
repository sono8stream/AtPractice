using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_050
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            var array = new int[n];
            var cnts = new int[n];
            for (int i = 0; i < n; i++)
            {
                cnts[int.Parse(input[i])]++;
            }
            bool even = n % 2 == 0;
            int itr = even ? 1 : 2;
            if (!even && cnts[0] != 1)
            {
                Console.WriteLine(0);
                return;
            }

            int pairCnt = 0;
            for (; itr < n; itr += 2)
            {
                if (cnts[itr] != 2)
                {
                    Console.WriteLine(0);
                    return;
                }
                else
                {
                    pairCnt++;
                }
            }

            long allPat = 1;
            for(int i = 0; i < pairCnt; i++)
            {
                allPat *= 2;
                allPat %= 1000000007;
            }

            Console.WriteLine(allPat);
        }
    }
}
