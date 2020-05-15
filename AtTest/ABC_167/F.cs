using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_167
{
    class F
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
            string[] ss = new string[n];
            for(int i = 0; i < n; i++)
            {
                ss[i] = Read();
            }

            int[][] remAdds = new int[n][];
            for(int i = 0; i < n; i++)
            {
                int left = 0;
                int right = 0;
                for(int j = 0; j < ss[i].Length; j++)
                {
                    if (ss[i][j] == ')')
                    {
                        if (right > 0)
                        {
                            right--;
                        }
                        else
                        {
                            left++;
                        }
                    }
                    else
                    {
                        right++;
                    }
                }

                remAdds[i] = new int[2] { left,right };
            }

            int tmp = 0;
            for (int i = 0; i < n; i++)
            {
                if (remAdds[i][0] == 0 && remAdds[i][1] > 0)
                {
                    tmp += remAdds[i][1];
                }
            }

            Array.Sort(remAdds, (a, b) => a[0] - b[0]);
            for (int i = 0; i < n; i++)
            {
                if (remAdds[i][0] > 0 && remAdds[i][1] > 0
                    && remAdds[i][0] <= remAdds[i][1])
                {
                    if (tmp < remAdds[i][0])
                    {
                        WriteLine("No");
                        return;
                    }

                    tmp -= remAdds[i][0];
                    tmp += remAdds[i][1];
                }
            }

            Array.Sort(remAdds, (a, b) =>
            {

                if (a[0] == b[0])
                {
                    return b[1] - a[1];
                }
                else
                {
                    return b[0] - a[0];
                }
            });
            for (int i = 0; i < n; i++)
            {
                if (remAdds[i][0] > 0 && remAdds[i][1] > 0
                    && remAdds[i][0] > remAdds[i][1])
                {
                    if (tmp < remAdds[i][0])
                    {
                        WriteLine("No");
                        return;
                    }

                    tmp -= remAdds[i][0];
                    tmp += remAdds[i][1];
                }
            }


            for (int i = 0; i < n; i++)
            {
                if (remAdds[i][1] == 0)
                {
                    tmp -= remAdds[i][0];
                }
            }

            if (tmp == 0)
            {
                WriteLine("Yes");
            }
            else
            {
                WriteLine("No");
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
