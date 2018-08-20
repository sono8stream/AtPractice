using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.DFS
{
    class ATC_001_A
    {
        static bool canReach = false;
        static int[,] mapInfo;
        static bool[,] flags;
        static Stack<Pos> stack;

        static void main(string[] args)
        {
            Method2(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int h = int.Parse(input[0]);
            int w = int.Parse(input[1]);
            mapInfo = new int[h, w];
            flags = new bool[h, w];
            int x = 0, y = 0;
            for (int i = 0; i < h; i++)
            {
                string lineInfo = Console.ReadLine();
                for (int j = 0; j < w; j++)
                {
                    switch (lineInfo[j])
                    {
                        case 's':
                            mapInfo[i, j] = 0;
                            x = j;
                            y = i;
                            break;
                        case 'g':
                            mapInfo[i, j] = 1;
                            break;
                        case '.':
                            mapInfo[i, j] = 0;
                            break;
                        case '#':
                            mapInfo[i, j] = -1;
                            flags[i, j] = true;
                            break;
                    }
                }
            }

            DFS(x, y);

            if (canReach)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        static void DFS(int x, int y)
        {
            if (x < 0 || mapInfo.GetLength(1) <= x
                || y < 0 || mapInfo.GetLength(0) <= y
                || flags[y, x] || mapInfo[y, x] == -1) return;

            flags[y, x] = true;

            switch (mapInfo[y, x])
            {
                case 0:
                    DFS(x + 1, y);
                    DFS(x, y + 1);
                    DFS(x - 1, y);
                    DFS(x, y - 1);
                    break;
                case 1:
                    canReach = true;
                    break;
            }
        }

        static void Method2(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int h = int.Parse(input[0]);
            int w = int.Parse(input[1]);
            mapInfo = new int[h, w];
            flags = new bool[h, w];
            int x = 0, y = 0;
            for (int i = 0; i < h; i++)
            {
                string lineInfo = Console.ReadLine();
                for (int j = 0; j < w; j++)
                {
                    switch (lineInfo[j])
                    {
                        case 's':
                            mapInfo[i, j] = 0;
                            x = j;
                            y = i;
                            break;
                        case 'g':
                            mapInfo[i, j] = 1;
                            break;
                        case '.':
                            mapInfo[i, j] = 0;
                            break;
                        case '#':
                            mapInfo[i, j] = -1;
                            flags[i, j] = true;
                            break;
                    }
                }
            }

            stack = new Stack<Pos>();
            stack.Push(new Pos(x, y));
            while (stack.Count > 0)
            {
                Pos p = stack.Pop();
                DFS2(p);
            }

            if (canReach)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        static void DFS2(Pos pos)
        {
            int x = pos.x;
            int y = pos.y;

            if (x < 0 || mapInfo.GetLength(1) <= x
                || y < 0 || mapInfo.GetLength(0) <= y
                || flags[y, x] || mapInfo[y, x] == -1) return;

            flags[y, x] = true;

            switch (mapInfo[y, x])
            {
                case 0:
                    stack.Push(new Pos(x + 1, y));
                    stack.Push(new Pos(x - 1, y));
                    stack.Push(new Pos(x, y + 1));
                    stack.Push(new Pos(x, y - 1));
                    break;
                case 1:
                    canReach = true;
                    break;
            }
        }
    }

    public struct Pos
    {
        public int x;
        public int y;
        public Pos(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
