using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_046
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var ta = new long[n, 2];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                ta[i, 0] = int.Parse(input[0]);
                ta[i, 1] = int.Parse(input[1]);
            }

            long takahashi = ta[0,0];
            long aoki = ta[0, 1];
            for(int i = 1; i < n; i++)
            {
                long rateT = 0, rateA = 0;
                rateT= takahashi / ta[i, 0];
                if (takahashi % ta[i, 0] > 0) rateT++;
                rateA = aoki / ta[i, 1];
                if (aoki % ta[i, 1] > 0) rateA++;

                if (ta[i, 1] * rateT < aoki)
                {
                    takahashi = ta[i, 0] * rateA;
                    aoki = ta[i, 1] * rateA;
                }
                else if(ta[i, 0] * rateA < takahashi)
                {
                    takahashi = ta[i, 0] * rateT;
                    aoki = ta[i, 1] * rateT;
                }
                else
                {
                    long rate = rateA < rateT ? rateA : rateT;
                    takahashi = ta[i, 0] * rate;
                    aoki = ta[i, 1] * rate;
                }
            }

            Console.WriteLine(takahashi + aoki);
        }
    }
}
