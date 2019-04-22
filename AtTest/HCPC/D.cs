using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            string s = Read();
            int m = ReadInt();
            char[][] lrs = new char[m][];
            for (int i = 0; i < m; i++) lrs[i] = ReadChars();
            int q = ReadInt();
            int[][] qs = new int[q][];
            for (int i = 0; i < q; i++)
            {
                int[] qq = ReadInts();
                qs[i] = new int[4] { qq[0], qq[1], i,0 };
            }

            List<int> cnts = new List<int>();
            cnts.Add(s[0] == 'B' ? -1 : 1);
            for(int i = 1; i < n; i++)
            {
                if (s[i] != s[i - 1]) cnts.Add(0);
                cnts[cnts.Count - 1] += s[i] == 'B' ? -1 : 1;
            }
            Array.Sort(qs, (a, b) => a[0] - b[0]);
            int qI = 0;
            for(int i = 0; i < m; i++)
            {
                if (lrs[i][0] == 'L')
                {
                    if (lrs[i][1] == 'B')
                    {
                        if (cnts[0] > 0 && cnts.Count > 1)
                        {
                            cnts[1] -= cnts[0] + 1;
                            cnts.RemoveAt(0);
                        }
                        else if (cnts[0] > 0) cnts.Insert(0, -1);
                        else cnts[0]--;
                    }
                    else
                    {
                        if (cnts[0] < 0 && cnts.Count > 1)
                        {
                            cnts[1] += -cnts[0] + 1;
                            cnts.RemoveAt(0);
                        }
                        else if (cnts[0] < 0) cnts.Insert(0, 1);
                        else cnts[0]++;
                    }
                }
                else
                {
                    if (lrs[i][1] == 'B')
                    {
                        if (cnts[cnts.Count - 1] > 0 && cnts.Count > 1)
                        {
                            cnts[cnts.Count - 2] -= cnts[cnts.Count - 1] + 1;
                            cnts.RemoveAt(cnts.Count - 1);
                        }
                        else if (cnts[cnts.Count - 1] > 0) cnts.Add(-1);
                        else cnts[cnts.Count-1]--;
                    }
                    else
                    {
                        if (cnts[cnts.Count - 1] < 0 && cnts.Count > 1)
                        {
                            cnts[cnts.Count - 2] += -cnts[cnts.Count - 1] + 1;
                            cnts.RemoveAt(cnts.Count - 1);
                        }
                        else if (cnts[cnts.Count-1] < 0) cnts.Add(1);
                        else cnts[cnts.Count-1]++;
                    }
                }

                for (; qI < q; qI++)
                {
                    if (qs[qI][0] > i + 1) break;

                    int sum = 0;
                    for (int j = 0; j < cnts.Count; j++)
                    {
                        sum += Abs(cnts[j]);
                        if (qs[qI][1] <= sum)
                        {
                            qs[qI][3] = cnts[j] < 0 ? -1 : 1;
                            break;
                        }
                    }
                }
            }

            Array.Sort(qs, (a, b) => a[2] - b[2]);
            for(int i = 0; i < q; i++)
            {
                WriteLine(qs[i][3] < 0 ? 'B' : 'W');
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
