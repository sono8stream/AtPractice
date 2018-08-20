using System;
using System.Collections.Generic;
using System.Linq;

//未完です
namespace AtTest.Library.RangeScheduling
{
    class ABC_038_D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var boxes = new Pos[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int w = int.Parse(input[0]);
                int h = int.Parse(input[1]);
                boxes[i] = new Pos(w, h);
            }
            Array.Sort(boxes);
            var dp = new int[n];
            dp[0] = 1;
            for (int i = 1; i < n; i++)
            {
                int cnt = 0;
                for(int j = 0; j < i; j++)
                {
                    if(boxes[j].x<boxes[i].x
                        && boxes[j].y < boxes[i].x)
                    {

                    }
                }
            }
            Console.WriteLine("text");
        }
    }
    
    class Pos : IComparable
    {
        public int x, y;
        public Pos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int CompareTo(object obj)
        {
            Pos comparer = (Pos)obj;
            if (y < comparer.y
                || (y == comparer.y && x < comparer.x))
            {
                return -1;
            }
            else if (y == comparer.y && x == comparer.x)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
