using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.Warshall_Floyd
{
    class WarshallFloyd
    {
        int n;
        public long[,] costs;

        public WarshallFloyd(int n)
        {
            this.n = n;
            costs = new long[n, n];
        }

        public void Calculate(long[,] origin)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        costs[j, k] = Min(costs[j, k], costs[j, i] + costs[i, k]);
                    }
                }
            }
        }
    }
}
