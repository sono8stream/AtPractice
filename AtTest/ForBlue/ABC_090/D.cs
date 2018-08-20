using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ForBlue.ABC_090
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
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);

            long cnt = 0;
            for (int i = k + 1; i <= n; i++)
            {
                //1周期中の個数
                int length = i - k;
                //周期数
                int f = n / i;
                cnt += f * length;
                if (n % i >= k)//余り処理
                {
                    if (k == 0)
                    {
                        cnt += n % i;
                    }
                    else
                    {
                        cnt += n % i - k + 1;
                    }
                }
            }
            Console.WriteLine(cnt);
        }
    }
}
