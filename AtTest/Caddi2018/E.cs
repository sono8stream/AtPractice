using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Caddi2018
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            if (n == 1)
            {
                Console.WriteLine(0);
                return;
            }

            var slopeLengthList = new List<int[]>();//start,length,up,plusCnt,minusCnt
            if (array[0] <= array[1])
            {
                slopeLengthList.Add(new int[5] { 0, 2, 1, 0, 0 });
            }
            else
            {
                slopeLengthList.Add(new int[5] { 0, 2, 0, 0, 0 });
            }
            int index = 0;
            for(int i = 2; i < n; i++)
            {
                if (array[i-1] <= array[i])
                {
                    if (slopeLengthList[index][2] == 1)
                    {
                        slopeLengthList[index][1]++;
                    }
                    else
                    {
                        slopeLengthList.Add(new int[5] { i - 1, 2, 1, 0, 0 });
                        index++;
                    }
                }
                else
                {
                    if (slopeLengthList[index][2] == 0)
                    {
                        slopeLengthList[index][1]++;
                    }
                    else
                    {
                        slopeLengthList.Add(new int[5] { i - 1, 2, 0, 0, 0 });
                        index++;
                    }
                };
            }

            for(int i = 0; i < slopeLengthList.Count; i++)
            {
                Console.WriteLine(slopeLengthList[i][0] + " "
                    + slopeLengthList[i][1]);
            }

            for(int i = 0; i < slopeLengthList.Count; i++)
            {
                if (slopeLengthList[i][2] == 0)//down
                {
                    slopeLengthList[i][5] = slopeLengthList[i][2] - 1;
                    
                    int cnt = 0;
                    for (int j = slopeLengthList[i][0] + 1;
                        j < slopeLengthList[i][1]; j++)
                    {
                        long temp = array[j] * 4;
                        int tempCnt = 2;
                        while (temp < array[j - 1])
                        {
                            tempCnt += 2;
                            temp *= 4;
                        }
                        cnt += tempCnt * 2;
                    }
                    slopeLengthList[i][4] = cnt;
                }
                else
                {
                    int cnt = 1;
                    for (int j = slopeLengthList[i][0] + slopeLengthList[i][1]-2;
                        j >= slopeLengthList[i][0]; j++)
                    {
                        long temp = array[j];
                        int tempCnt = 1;
                        while (temp < array[j + 1])
                        {
                            cnt += 2;
                            temp *= 4;
                        }
                    }
                    slopeLengthList[i][4] = cnt;
                }
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
