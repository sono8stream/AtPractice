using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.AGC_029
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
            int[] hwn = ReadInts();
            var obsDict = new List<int>[hwn[0]];
            for (int i = 0; i < hwn[2]; i++)
            {
                int[] xy = ReadInts();

                if (obsDict[xy[1] - 1] == null)
                {
                    obsDict[xy[1] - 1] = new List<int>();
                }
                obsDict[xy[1] - 1].Add(xy[0]);
            }

            int res = hwn[1];
            int min = 0;
            for (int i = 0; i < hwn[0]; i++)
            {
                min++;
                if (obsDict[i] == null)
                {
                    continue;
                }

                obsDict[i].Sort();
                for (int j = 0; j < obsDict[i].Count; j++)
                {
                    if (min > obsDict[i][j]) continue;
                    else if (min == obsDict[i][j]) min++;
                    else if (min < obsDict[i][j])
                    {
                        res = Math.Min(res, obsDict[i][j] - 1);
                        break;
                    }
                }
            }
            /*
            for(int i = 0; i < hwn[0]; i++)
            {
                int ind = 0;
                for(int j = 0; j < hwn[1]; j++)
                {
                    if (obsDict[i]!=null
                        &&ind<obsDict[i].Count
                        &&obsDict[i][ind] == j + 1)
                    {
                        Console.Write("× ");
                        ind++;
                    }
                    else
                    {
                        Console.Write("○ ");
                    }
                }
                Console.WriteLine();
            }
            */
            Console.WriteLine(res);
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
