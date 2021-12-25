using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_223
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
            long[] xyabc = ReadLongs();
            long x = xyabc[0];
            long y = xyabc[1];
            long a = xyabc[2];
            long b = xyabc[3];
            long c = xyabc[4];
            long[] abc = new long[3] { a, b, c };

            bool isOk = CheckForRow(x, y, abc) || CheckForColumn(x, y, abc)
                || CheckForOneRow(x, y, abc) || CheckForOneColumn(x, y, abc);
            WriteLine(isOk ? "Yes" : "No");
        }

        static bool CheckForRow(long x, long y, params long[] abc)
        {
            // 順に詰めていく
            long current = 0;
            for (int i = 0; i < abc.Length; i++)
            {
                long height = GetAnotherLength(x, abc[i]);
                current += height;
            }

            return current <= y;
        }

        static bool CheckForColumn(long x, long y, params long[] abc)
        {
            // 順に詰めていく
            long current = 0;
            for (int i = 0; i < abc.Length; i++)
            {
                long width = GetAnotherLength(y, abc[i]);
                current += width;
            }

            return current <= x;
        }

        static bool CheckForOneRow(long x, long y, long[] abc)
        {
            // Rowになるものを選択
            for (int i = 0; i < abc.Length; i++)
            {
                long rowHeight = GetAnotherLength(x, abc[i]);

                long remainHeight = y - rowHeight;

                if (remainHeight <= 0)
                {
                    continue;
                }

                bool canCreate = CheckForColumn(x, remainHeight,
                    abc[(i + 1) % abc.Length], abc[(i + 2) % abc.Length]);
                if (canCreate)
                {
                    return true;
                }
            }

            return false;
        }

        static bool CheckForOneColumn(long x, long y, long[] abc)
        {
            // Columnになるものを選択
            for (int i = 0; i < abc.Length; i++)
            {
                long columnWidth = GetAnotherLength(y, abc[i]);

                long remainWidth = x - columnWidth;

                if (remainWidth <= 0)
                {
                    continue;
                }

                bool canCreate = CheckForRow(remainWidth, y,
                    abc[(i + 1) % abc.Length], abc[(i + 2) % abc.Length]);
                if (canCreate)
                {
                    return true;
                }
            }

            return false;
        }

        static long GetAnotherLength(long constraintLength, long square)
        {
            long flooredLength = square / constraintLength;
            long neededLength = square % constraintLength > 0 ? flooredLength + 1 : flooredLength;

            return neededLength;//neededLength == constraintLength ? neededLength + 1 : neededLength;
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
