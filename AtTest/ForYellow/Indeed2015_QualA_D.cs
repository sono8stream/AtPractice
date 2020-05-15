using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class Indeed2015_QualA_D
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
            int[] hw = ReadInts();
            int h = hw[0];
            int w = hw[1];
            string first = "";
            string last = "";
            bool even = false;
            for (int i = 0; i < h; i++)
            {
                byte[] row = ReadBytes();
                for (int j = 0; j < w; j++)
                {
                    first += (char)row[j];
                    last += (char)((i * w + j + 1) % (h * w));
                    if (row[j] == 0)
                    {
                        even = (h - i - 1 + w - j - 1) % 2 == 0;
                    }
                }
            }

            Dictionary<string, int> forward = new Dictionary<string, int>();
            Dictionary<string, int> back = new Dictionary<string, int>();
            forward[first] = 0;
            back[last] = 0;
            int[] dx = new int[4] { 1, 0, -1, 0 };
            int[] dy = new int[4] { 0, 1, 0, -1 };

            for (int i = 0; i < 11; i++)
            {
                Dictionary<string, int> forwardNext = new Dictionary<string, int>();
                foreach (string key in forward.Keys)
                {
                    int cnt = forward[key];
                    if (cnt != i)
                    {
                        continue;
                    }

                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            if ((byte)key[y * w + x] != 0)
                            {
                                continue;
                            }

                            for (int j = 0; j < 4; j++)
                            {
                                int toX = x + dx[j];
                                int toY = y + dy[j];
                                if (toX < 0 || toX >= w || toY < 0 || toY >= h)
                                {
                                    continue;
                                }

                                string next = Swap(key, w, h, x, y, toX, toY);
                                if (!forward.ContainsKey(next)
                                    && !forwardNext.ContainsKey(next))
                                {
                                    forwardNext[next] = i + 1;
                                }
                            }
                        }
                    }
                }
                foreach (string key in forwardNext.Keys)
                {
                    forward[key] = forwardNext[key];
                }
            }

            for (int i = 0; i < 11; i++)
            {
                Dictionary<string, int> backNext = new Dictionary<string, int>();
                foreach (string key in back.Keys)
                {
                    int cnt = back[key];
                    if (cnt != i)
                    {
                        continue;
                    }

                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            if ((byte)key[y * w + x] != 0)
                            {
                                continue;
                            }

                            for (int j = 0; j < 4; j++)
                            {
                                int toX = x + dx[j];
                                int toY = y + dy[j];
                                if (toX < 0 || toX >= w || toY < 0 || toY >= h)
                                {
                                    continue;
                                }

                                string next = Swap(key, w, h, x, y, toX, toY);
                                if (!back.ContainsKey(next)
                                    && !backNext.ContainsKey(next))
                                {
                                    backNext[next] = i + 1;
                                }
                            }
                        }
                    }
                }
                foreach (string key in backNext.Keys)
                {
                    back[key] = backNext[key];
                }
            }


            int res = even ? 24 : 23;
            foreach (string key in forward.Keys)
            {
                if (back.ContainsKey(key))
                {
                    res = Min(res, forward[key] + back[key]);
                }
            }
            WriteLine(res);
        }

        static string Swap(string state, int w, int h, int x, int y, int toX, int toY)
        {
            string res = "";
            for (int i = 0; i < h * w; i++)
            {
                if (i == y * w + x)
                {
                    res += state[toY * w + toX];
                }
                else if (i == toY * w + toX)
                {
                    res += state[y * w + x];
                }
                else
                {
                    res += state[i];
                }
            }
            return res;
        }

        private static void Swap<T>(ref T a, ref T b) { T tmp = a; a = b; b = tmp; }
        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static byte ReadByte() { return byte.Parse(Read()); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static byte[] ReadBytes() { return Array.ConvertAll(Read().Split(), byte.Parse); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
