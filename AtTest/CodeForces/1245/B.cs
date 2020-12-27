using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1245
{
    class B
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
            int t = ReadInt();
            string pat = "RPS";
            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                int[] abcs = ReadInts();
                string s = Read();
                int[] bobAbcs = new int[3];
                for(int j = 0; j < n; j++)
                {
                    switch (s[j])
                    {
                        case 'R':
                            bobAbcs[0]++;
                            break;
                        case 'P':
                            bobAbcs[1]++;
                            break;
                        case 'S':
                            bobAbcs[2]++;
                            break;
                    }
                }

                int wins = 0;
                int[] uses = new int[3];
                for(int j = 0; j < 3; j++)
                {
                    uses[j]= Min(abcs[j], bobAbcs[(j + 2) % 3]);
                    wins += uses[j];
                }

                int thres = n / 2;
                if (n % 2 == 1)
                {
                    thres++;
                }
                if (wins >= thres)
                {
                    WriteLine("YES");
                    int[] useCnts = new int[3];
                    int[] nonUses = new int[3];
                    char[] res = new char[n];
                    for(int j = 0; j < n; j++)
                    {
                        bool used = false;
                        switch (s[j])
                        {
                            case 'R':
                                if (useCnts[1] < uses[1])
                                {
                                    used = true;
                                    res[j] = pat[1];
                                    useCnts[1]++;
                                }
                                break;
                            case 'P':
                                if (useCnts[2] < uses[2])
                                {
                                    used = true;
                                    res[j] = pat[2];
                                    useCnts[2]++;
                                }
                                break;
                            case 'S':
                                if (useCnts[0] < uses[0])
                                {
                                    used = true;
                                    res[j] = pat[0];
                                    useCnts[0]++;
                                }
                                break;
                        }
                        if (!used)
                        {
                            for(int k = 0; k < 3; k++)
                            {
                                if (nonUses[k] < abcs[k]-uses[k])
                                {
                                    res[j] = pat[k];
                                    nonUses[k]++;
                                    break;
                                }
                            }
                        }
                    }
                    WriteLine(res);
                }
                else
                {
                    WriteLine("NO");
                }
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
