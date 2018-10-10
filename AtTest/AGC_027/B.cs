using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.AGC_027
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            long x = long.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            var xs = new long[n];
            for (int i = 0; i < n; i++)
            {
                xs[i] = long.Parse(input[i]);
            }
            /*
            var cost = new long[n, n];//いくつより近いゴミまで持ち帰るか、そのときのエネルギー
            for (int i = n - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    cost[i, 0] = xs[i] + x + 4 * (xs[i]);
                }
                else
                {
                    cost[i, 0] = xs[i] + x + 4 * (xs[i] - xs[i - 1]);
                }

                for (int j = 0; j < n - i; j++)
                {
                    if (i == 0)
                    {
                        cost[i, j] = cost[i + 1, j];
                        cost[i, j] = xs[i] + 2 * x + 4 * xs[i];
                    }
                    else
                    {

                    }
                }
            }
            */
            /*var geted = new bool[n];
            int getCnt = n;
            int ungetMaxIndex = n - 1;
            long eng = 0;
            while (getCnt > 0)
            {
                eng += xs[ungetMaxIndex];
                getCnt--;
                geted[ungetMaxIndex] = true;
                int nowGetCnt = 1;
                int lastGetIndex = ungetMaxIndex;
                for (int i = ungetMaxIndex - 1; i >= 0; i--)
                {
                    if (geted[i]) continue;
                    //if (nowGetCnt < (2.0f * xs[i] + x) / 3 / xs[i])
                    if (2 * xs[i] * (nowGetCnt - 1) < x)
                    {//拾う
                        getCnt--;
                        geted[i] = true;
                        eng += (nowGetCnt + 1) * (nowGetCnt + 1)
                            * (xs[lastGetIndex] - xs[i]);
                        nowGetCnt++;
                        lastGetIndex = i;
                    }
                    else if (lastGetIndex == ungetMaxIndex)
                    {
                        ungetMaxIndex = i;
                    }
                }
                eng += (nowGetCnt + 1) * (nowGetCnt + 1) * xs[lastGetIndex];
                eng += x * (nowGetCnt + 1);
            }
            Console.WriteLine(eng);*/

            /*var eng = new long[n];
            eng[0] = xs[0] + 2 * 2 * xs[0] + x * 2;
            
            for(int i = 1; i < n; i++)
            {
                long delta1 = xs[i] + 2 * 2 * xs[i] + x * 2;
                Console.WriteLine(eng[i - 1] + delta1);
                long engTemp = xs[i];
                for (int j = i; j >= 0; j--)
                {
                    if (j > 0)
                    {
                        engTemp += (i - j + 2) * (i - j + 2)
                            * (xs[j] - xs[j - 1]);
                    }
                    else
                    {
                        engTemp += (i - j + 2) * (i - j + 2) * xs[j];
                    }
                }
                engTemp += x * (i + 2);
                Console.WriteLine(engTemp);
                if (eng[i - 1] + delta1 < engTemp)
                {
                    eng[i] = eng[i - 1] + delta1;
                }
                else
                {
                    eng[i] = engTemp;
                }
            }
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine(eng[i]);
            }*/
            //Console.WriteLine(eng[n - 1]);
        }
    }
}
