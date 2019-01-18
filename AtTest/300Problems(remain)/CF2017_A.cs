using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._300Problems_remain_
{
    class CF2017_A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            int allPat = 1 << 4;
            string baseS = "KIHBR";
            for(int i = 0; i < allPat; i++)
            {
                string checkS = baseS;
                for(int j = 0; j < 4; j++)
                {
                    if ((i >> j) % 2 == 1)
                    {
                        switch (j)
                        {
                            case 0:
                                checkS = "A" + checkS;
                                break;
                            case 1:
                                checkS = checkS.Replace("H", "HA");
                                break;
                            case 2:
                                checkS = checkS.Replace("B", "BA");
                                break;
                            case 3:
                                checkS = checkS.Replace("R", "RA");
                                break;
                        }
                    }
                }
                //Console.WriteLine(checkS);
                if (s.Equals(checkS))
                {
                    Console.WriteLine("YES");
                    return;
                }
            }
            Console.WriteLine("NO");
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
