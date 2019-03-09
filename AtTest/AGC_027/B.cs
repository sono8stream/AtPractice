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
            long[] sums = new long[n];
            sums[0] = xs[0];
            for(int i = 1; i < n; i++)
            {
                sums[i] = sums[i - 1] + xs[i];
            }
            double res = double.MaxValue;
            for(long k = 1; k <= n; k++)
            {
                double tmp = 0;
                double cnt = 1;
                for(long now = n - k; now >= 0; now -= k)
                {
                    if (cnt == 1)
                    {
                        tmp += sums[now + k - 1] * 5.0;
                        if (now > 0) tmp -= sums[now - 1] * 5.0;
                    }
                    else
                    {
                        tmp += sums[now + k - 1] * (2 * cnt + 1);
                        if (now > 0) tmp -= sums[now - 1] * (2 * cnt + 1);
                    }
                    cnt++;
                }
                long margin = n % k;
                if (margin > 0)
                {
                    tmp += sums[margin - 1] * (2 * cnt + 1);
                }
                tmp += (k + n) * x;
                res = Math.Min(res, tmp);
            }
            Console.WriteLine(res);
        }
    }
}
