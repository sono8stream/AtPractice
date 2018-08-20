using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ForBlue.ABC_088
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int h = int.Parse(input[0]);
            int w = int.Parse(input[1]);
            var grid = new bool[h, w];
            var gridTemp = new bool[h, w];
            int wallCnt = 0;
            for (int i = 0; i < h; i++)
            {
                string inText = Console.ReadLine();
                for(int j = 0; j < w; j++)
                {
                    if(inText[j] == '.')
                    {
                        grid[i, j] = true;//通れる
                    }
                    else
                    {
                        grid[i, j] = false;
                        wallCnt++;
                    }
                    gridTemp[i, j] = grid[i, j];
                }
            }

            Queue<Pos> poses = new Queue<Pos>();
            poses.Enqueue(new Pos(0, 0, 1));
            gridTemp[0,0] = false;
            bool canMove = false;
            int minDistance = 0;
            while (poses.Count > 0)
            {
                Pos nowPos = poses.Dequeue();
                if (nowPos.x == w - 1 && nowPos.y == h - 1)
                {
                    canMove = true;
                    minDistance = nowPos.minDistance;
                    break;
                }

                if (nowPos.x > 0 && gridTemp[nowPos.y, nowPos.x - 1])
                {
                    poses.Enqueue(new Pos(nowPos.x - 1, nowPos.y, nowPos.minDistance + 1));
                    gridTemp[nowPos.y, nowPos.x - 1] = false;
                }
                if (nowPos.x < w - 1 && gridTemp[nowPos.y, nowPos.x + 1])
                {
                    poses.Enqueue(new Pos(nowPos.x + 1, nowPos.y, nowPos.minDistance + 1));
                    gridTemp[nowPos.y, nowPos.x + 1] = false;
                }
                if (nowPos.y > 0 && gridTemp[nowPos.y - 1, nowPos.x])
                {
                    poses.Enqueue(new Pos(nowPos.x, nowPos.y - 1, nowPos.minDistance + 1));
                    gridTemp[nowPos.y - 1, nowPos.x] = false;
                }
                if (nowPos.y < h - 1 && gridTemp[nowPos.y + 1, nowPos.x])
                {
                    poses.Enqueue(new Pos(nowPos.x, nowPos.y + 1, nowPos.minDistance + 1));
                    gridTemp[nowPos.y + 1, nowPos.x] = false;
                }
            }
            if (!canMove)
            {
                Console.WriteLine(-1);
                return;
            }
            else
            {
                int resultCnt = h * w - wallCnt - minDistance;
                Console.WriteLine(resultCnt);
            }
        }
    }

    class Pos
    {
        public int x { get; }
        public int y { get; }
        public int minDistance { get; }
        public Pos(int x,int y,int minDistance)
        {
            this.x = x;
            this.y = y;
            this.minDistance = minDistance;
        }
    }
}
