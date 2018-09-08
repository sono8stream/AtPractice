using System;
using System.Collections.Generic;
using System.Linq;

namespace AtTest
{
    class ARC101_C
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
            int k = int.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            var minusX = new List<long>();
            var plusOrZeroX = new List<long>();

            for (int i = 0; i < n; i++)
            {
                long x = long.Parse(input[i]);
                if (x < 0)
                {
                    minusX.Add(x);
                }
                else
                {
                    plusOrZeroX.Add(x);
                }
            }
            long[] minuses = minusX.ToArray();
            Array.Reverse(minuses);
            minuses = minuses.Select(x => x *= -1).ToArray();
            long[] pluses = plusOrZeroX.ToArray();

            long minDistance = -1;
            if (k <= minuses.Length)
            {
                minDistance = minuses[k - 1];
            }
            for(int i = 0; i < pluses.Length; i++)
            {
                int minusCnt = k - i - 1;
                if (minusCnt > minuses.Length) continue;

                long plusDist = 2 * pluses[i];
                long minusDist = pluses[i];
                if (minusCnt > 0)
                {
                    plusDist += minuses[minusCnt - 1];
                    minusDist += 2 * minuses[minusCnt - 1];
                }
                long min = plusDist < minusDist ? plusDist : minusDist;
                if (minDistance == -1 || minDistance > min)
                {
                    minDistance = min;
                }
            }

            Console.WriteLine(minDistance);
        }
    }
}
