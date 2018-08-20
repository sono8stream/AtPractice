using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.SoundHound2018
{
    class A
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            long c = long.Parse(input[0]);
            long d = long.Parse(input[1]);

            //初期周期まで
            long firstPow = 1;//最低指数
            while (170 <= c / firstPow)
            {
                firstPow *= 2;
            }
            long cnt = 0;


            for (long pow = firstPow; 140 * pow < d; pow *= 2)
            {
                long min;
                if (pow == firstPow && 140 * pow < c)
                {
                    min = c;
                }
                else
                {
                    min = 140 * pow;
                }

                long length;
                if (d <= 170 * pow)//上限削る
                {
                    length= d - min;
                }
                else
                {
                    length= 170 * pow - min;
                }
                //Console.WriteLine(length);
                cnt += length;
            }
            Console.WriteLine(cnt);
        }
    }
}
