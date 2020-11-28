using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1398
{
    class E
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
            int n = ReadInt();
            var upFireQue = new PriorityQueue<bool>();
            var downFireQue = new PriorityQueue<bool>();
            var upLightQue = new PriorityQueue<bool>();
            var downLightQue = new PriorityQueue<bool>();
            int lightCnt = 0;
            int uppedFire = 0;
            int uppedLight = 0;
            var conds = new Dictionary<long, bool>();// 強化済みかどうか
            long now = 0;
            for (int i = 0; i < n; i++)
            {

                int[] vals = ReadInts();
                int type = vals[0];
                int val = vals[1];
                if (type == 0)
                {
                    if (val > 0)
                    {
                        now += val;
                        conds.Add(val, false);
                        downFireQue.Enqueue(-val, true);
                    }
                    else
                    {
                        val *= -1;
                        now -= val;
                        if (conds[val])
                        {
                            now -= val;
                            uppedFire--;
                        }
                        conds.Remove(val);
                    }
                }
                else
                {
                    if (val > 0)
                    {
                        now += val;
                        conds.Add(val, false);
                        downLightQue.Enqueue(-val, true);
                        lightCnt++;
                    }
                    else
                    {
                        val *= -1;
                        now -= val;
                        if (conds[val])
                        {
                            now -= val;
                            uppedLight--;
                        }
                        lightCnt--;
                        conds.Remove(val);
                    }
                }

                while (uppedLight > 0 && uppedLight >= lightCnt)
                {
                    long top = upLightQue.Dequeue().Key;
                    if (conds.ContainsKey(top))
                    {
                        now -= top;
                        conds[top] = false;
                        uppedLight--;
                        downLightQue.Enqueue(-top, true);
                    }
                }
                while (uppedFire + uppedLight > lightCnt)
                {
                    long top = upFireQue.Dequeue().Key;
                    if (conds.ContainsKey(top))
                    {
                        now -= top;
                        conds[top] = false;
                        uppedFire--;
                        downFireQue.Enqueue(-top, true);
                    }
                }

                while (uppedFire + uppedLight < lightCnt)
                {
                    while (downFireQue.Count > 0 && !conds.ContainsKey(-downFireQue.Top().Key))
                    {
                        downFireQue.Dequeue();
                    }
                    while (downLightQue.Count > 0 && !conds.ContainsKey(-downLightQue.Top().Key))
                    {
                        downLightQue.Dequeue();
                    }

                    if (downFireQue.Count > 0 && downLightQue.Count > 0)
                    {
                        if (downFireQue.Top().Key < downLightQue.Top().Key
                            && uppedLight + 1 < lightCnt)
                        {
                            long top = -downLightQue.Dequeue().Key;
                            now += top;
                            conds[top] = true;
                            uppedLight++;
                            upLightQue.Enqueue(top, true);
                        }
                        else
                        {
                            long top = -downFireQue.Dequeue().Key;
                            now += top;
                            conds[top] = true;
                            uppedFire++;
                            upFireQue.Enqueue(top, true);
                        }
                    }
                    else if (downFireQue.Count > 0)
                    {
                        long top = -downFireQue.Dequeue().Key;
                        now += top;
                        conds[top] = true;
                        uppedFire++;
                        upFireQue.Enqueue(top, true);
                    }
                    else if (downLightQue.Count > 0)
                    {
                        if (uppedLight + 1 < lightCnt)
                        {
                            long top = -downLightQue.Dequeue().Key;
                            now += top;
                            conds[top] = true;
                            uppedLight++;
                            upLightQue.Enqueue(top, true);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                WriteLine(now);
            }
        }

        class PriorityQueue<T>
        {
            private readonly List<KeyValuePair<long, T>> list;

            public int Count { get; private set; }

            public PriorityQueue()
            {
                list = new List<KeyValuePair<long, T>>();
                Count = 0;
            }

            private void Add(KeyValuePair<long, T> pair)
            {
                if (Count == list.Count)
                {
                    list.Add(pair);
                }
                else
                {
                    list[Count] = pair;
                }
                Count++;
            }

            private void Swap(int a, int b)
            {
                KeyValuePair<long, T> tmp = list[a];
                list[a] = list[b];
                list[b] = tmp;
            }

            public void Enqueue(long key, T value)
            {
                Add(new KeyValuePair<long, T>(key, value));
                int c = Count - 1;
                while (c > 0)
                {
                    int p = (c - 1) / 2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    c = p;
                }
            }

            public KeyValuePair<long, T> Top()
            {
                return list[0];
            }

            public KeyValuePair<long, T> Dequeue()
            {
                KeyValuePair<long, T> pair = list[0];
                Count--;
                if (Count == 0) return pair;

                list[0] = list[Count];
                int p = 0;
                while (true)
                {
                    int c1 = p * 2 + 1;
                    int c2 = p * 2 + 2;
                    if (c1 >= Count) break;

                    int c = (c2 >= Count || list[c1].Key < list[c2].Key)
                        ? c1 : c2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    p = c;
                }
                return pair;
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
