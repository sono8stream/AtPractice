using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.BFS
{
    class ABC_007_C
    {
        static int[,] mapInfo;
        static Pos start, goal;
        static Queue<Pos> queue;
        static bool onGoal;

        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int h = int.Parse(input[0]);
            int w = int.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            start = new Pos(int.Parse(input[1]) - 1, int.Parse(input[0]) - 1, 0);
            input = Console.ReadLine().Split(' ');
            goal = new Pos(int.Parse(input[1]) - 1, int.Parse(input[0]) - 1, 0);
            mapInfo = new int[h, w];
            for (int i = 0; i < h; i++)
            {
                string lineInfo = Console.ReadLine();
                for (int j = 0; j < w; j++)
                {
                    if (lineInfo[j] == '#')
                    {
                        mapInfo[i, j] = -2;//移動不可
                    }
                    else
                    {
                        mapInfo[i, j] = -1;//未移動
                    }
                }
            }

            queue = new Queue<Pos>();
            queue.Enqueue(start);
            while (queue.Count > 0 && !onGoal)
            {
                BFS(queue.Dequeue());
            }

            /*for(int i = 0; i < h; i++)
            {
                string s = "";
                for(int j = 0; j < w; j++)
                {
                    s += mapInfo[i, j].ToString();
                }
                Console.WriteLine(s);
            }
            Console.WriteLine(string.Format("{0},{1}", goal.x, goal.y));*/
            Console.WriteLine(mapInfo[goal.y, goal.x]);
        }

        static void BFS(Pos p)
        {
            int x = p.x;
            int y = p.y;
            int cnt = p.count;
            if (x < 0 || mapInfo.GetLength(1) <= x
                || y < 0 || mapInfo.GetLength(0) <= y
                || mapInfo[y, x] != -1) return;

            mapInfo[y, x] = p.count;
            if (goal.x == x && goal.y == y)
            {
                onGoal = true;
            }
            else
            {
                queue.Enqueue(new Pos(x + 1, y, cnt + 1));
                queue.Enqueue(new Pos(x, y + 1, cnt + 1));
                queue.Enqueue(new Pos(x - 1, y, cnt + 1));
                queue.Enqueue(new Pos(x, y - 1, cnt + 1));
            }
        }
    }

    struct Pos
    {
        public int x;
        public int y;
        public int count;
        public Pos(int x,int y,int count)
        {
            this.x = x;
            this.y = y;
            this.count = count;
        }
    }
}
