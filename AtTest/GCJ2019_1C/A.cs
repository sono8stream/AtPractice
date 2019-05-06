using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ2019_1C
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            Action[] res = new Action[t];

            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
            for (int i = 0; i < t; i++)
            {
                Write("Case #" + (i + 1) + ": ");
                res[i]();
            }
        }

        static Action Solve()
        {
            int a = ReadInt();
            char[][]programs=new char[a][];
            bool[] losed = new bool[a];
            for(int i = 0; i < a; i++)
            {
                programs[i] = Read().ToCharArray();
            }

            List<char> res = new List<char>();
            for(int i = 0; i < 500; i++)
            {
                int rCnt = 0;
                int pCnt = 0;
                int sCnt = 0;
                int loseCnt = 0;
                for(int j = 0; j < a; j++)
                {
                    if (losed[j])
                    {
                        loseCnt++;
                        continue;
                    }

                    int index = i % programs[j].Length;
                    switch (programs[j][index])
                    {
                        case 'R':
                            rCnt++;
                            break;
                        case 'P':
                            pCnt++;
                            break;
                        case 'S':
                            sCnt++;
                            break;
                    }
                }

                if (loseCnt == a) break;
                if (rCnt > 0 && pCnt > 0 && sCnt > 0)
                {
                    return () => WriteLine("IMPOSSIBLE");
                }
                else
                {
                    char remChar = 'a';
                    if (pCnt == a - loseCnt)
                    {
                        res.Add('S');
                        remChar = 'P';
                    }
                    else if (sCnt == a - loseCnt)
                    {
                        res.Add('R');
                        remChar = 'S';
                    }
                    else if (rCnt == a - loseCnt)
                    {
                        res.Add('P');
                        remChar = 'R';
                    }
                    else if (rCnt == 0)
                    {
                        res.Add('S');
                        remChar = 'P';
                    }
                    else if(pCnt == 0)
                    {
                        res.Add('R');
                        remChar = 'S';
                    }
                    else if(sCnt == 0)
                    {
                        res.Add('P');
                        remChar = 'R';
                    }
                    var next = new Dictionary<char[], bool>();
                    for (int j = 0; j < a; j++)
                    {
                        if (losed[j]) continue;

                        int index = i % programs[j].Length;
                        if (programs[j][index] == remChar) losed[j] = true;
                    }
                }
            }
            int loseCntLast = 0;
            for (int i = 0; i < a; i++) if (losed[i]) loseCntLast++;

            if (loseCntLast == a)
            {
                return () => WriteLine(res.ToArray());
            }
            else
            {
                return () => WriteLine("IMPOSSIBLE");
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
