using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class Traveling
    {
        public static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] ts = new int[n+1];
            int[] xs = new int[n+1];
            int[] ys = new int[n+1];

            ts[0] = 0;
            xs[0] = 0;
            ys[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                ts[i] = int.Parse(inputs[0]);
                xs[i] = int.Parse(inputs[1]);
                ys[i] = int.Parse(inputs[2]);
            }
            for(int i = 1; i <= n; i++)
            {
                if (!CanTravel(ts[i - 1], xs[i - 1], ys[i - 1], ts[i], xs[i], ys[i]))
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");
        }

        public static bool CanTravel(int t1,int x1,int y1,int t2,int x2,int y2)
        {
            int distance = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            return distance <= t2 - t1 && distance % 2 == (t2 - t1) % 2;
        }
    }
}
