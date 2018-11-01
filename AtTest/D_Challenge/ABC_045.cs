using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_045
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] hwn = ReadLongs();
            int n = (int)hwn[2];
            var abs = new long[n][];
            var posDict = new Dictionary<long, Dictionary<long, bool>>();
            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadLongs();
                if (!posDict.ContainsKey(abs[i][0]))
                {
                    posDict.Add(abs[i][0], new Dictionary<long, bool>());
                }
                posDict[abs[i][0]].Add(abs[i][1], true);
            }
            long all = (hwn[0] - 2) * (hwn[1] - 2);
            long[] cnts = new long[10];
            cnts[0] = all;
            var visitDict = new Dictionary<long, Dictionary<long, bool>>();
            for(int i = 0; i < n; i++)
            {
                long x = abs[i][1] - 2;
                long y = abs[i][0] - 2;
                for(long xd = 0; xd < 3; xd++)
                {
                    for(long yd = 0; yd < 3; yd++)
                    {
                        if (x + xd < 1 || y + yd < 1
                            || x + xd + 2 > hwn[1]
                            || y + yd + 2 > hwn[0]) continue;
                        if (visitDict.ContainsKey(y + yd)
                            && visitDict[y+yd].ContainsKey(x + xd)) continue;

                        if (!visitDict.ContainsKey(y + yd))
                        {
                            visitDict.Add(y + yd,
                                new Dictionary<long, bool>());
                        }
                        visitDict[y + yd].Add(x + xd, true);

                        int cnt = 0;
                        for(long px = 0; px < 3; px++)
                        {
                            for(long py = 0; py < 3; py++)
                            {
                                if(posDict.ContainsKey(y+yd+py)
                                    && posDict[y + yd + py].ContainsKey(
                                        x + xd + px))
                                {
                                    cnt++;
                                }
                            }
                        }
                        cnts[cnt]++;
                        cnts[0]--;
                    }
                }
            }
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(cnts[i]);
            }
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
