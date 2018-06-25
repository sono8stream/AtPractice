using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class Snk
    {
        static double CalcSunuke(long num)
        {
            long tmp = num;
            long sn = 0;

            while (tmp > 0)
            {
                sn += (tmp % 10);
                tmp /= 10;
            }

            return num / (double)sn;
        }

        public static long[] PrintSunuke(long k)
        {
            long[] snks = new long[k];
            int count = 0;
            for (int i = 1; i < 10; i++)
            {
                //Console.WriteLine(i.ToString());
                snks[count] = i;
                ++count;

                if (count >= k)
                {
                    return snks;
                }
            }

            long baseNum = 9;
            long baseDigit = 10;
            long nextCandidate = 0;

            while (count < k)
            {
                long topNum = 1;
                long nowCandidate = topNum * baseDigit + baseNum;

                while (nowCandidate <= nextCandidate)
                {
                    ++topNum;
                    nowCandidate = topNum * baseDigit + baseNum;
                }

                double sunuke = CalcSunuke(nowCandidate);
                while (count < k)
                {
                    ++topNum;
                    nextCandidate = topNum * baseDigit + baseNum;
                    double tmpSunuke = CalcSunuke(nextCandidate);

                    if (sunuke < tmpSunuke)
                    {
                        //Console.WriteLine(nowCandidate.ToString());
                        snks[count] = nowCandidate;
                        nowCandidate = nextCandidate;
                        sunuke = tmpSunuke;
                        ++count;
                    }
                    else
                    {
                        baseNum = baseNum * 10 + 9;
                        baseDigit *= 10;
                        break;
                    }
                }

            }
            return snks;
        }
    }
}
