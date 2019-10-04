using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_29
{
    class C
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int[] dx = new int[4] { 1, -1, 0, 0 };
            int[] dy = new int[4] { 0, 0, 1, -1 };
            while (true)
            {
                int[] wh = ReadInts();
                int w = wh[0];
                int h = wh[1];
                if (h == 0) break;

                bool[,] gridL, gridR;
                gridL = new bool[h, w];
                gridR = new bool[h, w];
                int[] lStart, rStart, lGoal, rGoal;
                lStart = new int[2] { 0, 0 };
                rStart = new int[2] { 0, 0 };
                lGoal = new int[2] { 0, 0 };
                rGoal = new int[2] { 0, 0 };
                for (int i = 0; i < h; i++)
                {
                    string s = Read();
                    for (int j = 0; j < w; j++)
                    {
                        gridL[i, j] = true;
                        switch (s[j])
                        {
                            case '#':
                                gridL[i, j] = false;
                                break;
                            case 'L':
                                lStart = new int[2] { i, j };
                                break;
                            case '%':
                                lGoal = new int[2] { i, j };
                                break;
                        }
                        gridR[i, j] = true;
                        switch (s[s.Length - 1 - j])
                        {
                            case '#':
                                gridR[i, j] = false;
                                break;
                            case 'R':
                                rStart = new int[2] { i, j };
                                break;
                            case '%':
                                rGoal = new int[2] { i, j };
                                break;
                        }
                    }
                }

                bool[,,,] cans = new bool[h, w, h, w];
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(new int[4] { lStart[0], lStart[1],
                    rStart[0], rStart[1] });
                bool done = false;
                while (queue.Count > 0)
                {
                    int[] val = queue.Dequeue();
                    int lY = val[0];
                    int lX = val[1];
                    int rY = val[2];
                    int rX = val[3];
                    if(lY==lGoal[0]&&lX==lGoal[1]
                        && rY == rGoal[0] && rX == rGoal[1])
                    {
                        WriteLine("Yes");
                        done = true;
                        break;
                    }
                    if ((lY == lGoal[0] && lX == lGoal[1])
                        || (rY == rGoal[0] && rX == rGoal[1])) continue;
                    if (cans[lY, lX, rY, rX]) continue;

                    cans[lY, lX, rY, rX] = true;
                    for(int i = 0; i < 4; i++)
                    {
                        int llY = lY + dy[i];
                        int llX = lX + dx[i];
                        int rrY = rY + dy[i];
                        int rrX = rX + dx[i];
                        if (llY < 0 || llY >= h || !gridL[llY, lX]) llY = lY;
                        if (llX < 0 || llX >= w || !gridL[lY, llX]) llX= lX;
                        if (rrY < 0 || rrY >= h || !gridR[rrY, rX]) rrY = rY;
                        if (rrX < 0 || rrX >= w || !gridR[rY, rrX]) rrX = rX;

                        if (!cans[llY, llX, rrY, rrX])
                        {
                            queue.Enqueue(new int[4] { llY,llX,rrY,rrX });
                        }
                    }
                }
                if (!done) WriteLine("No");
            }
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
