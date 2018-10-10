using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_095
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] input = ReadInts();
            int price = 0;
            int cheaperIndex = input[0] < input[1] ? 0 : 1;
            int higherIndex = cheaperIndex == 0 ? 1 : 0;
            int lessIndex = input[3] < input[4] ? 3 : 4;
            int moreIndex = lessIndex == 3 ? 4 : 3;

            if (input[0] + input[1] < input[2] * 2)
            {//それぞれ購入
                price += input[0] * input[3];
                price += input[1] * input[4];
            }
            else if (input[higherIndex] < input[2] * 2)
            {
                price += input[2] * input[lessIndex] * 2;
                price += input[moreIndex - 3]
                    * (input[moreIndex] - input[lessIndex]);
            }
            else if (input[cheaperIndex]<input[2] * 2)//安い方とABのみ購入
            {
                price += input[2] * input[higherIndex + 3] * 2;
                if (higherIndex + 3 == lessIndex)
                {
                    price += input[cheaperIndex]
                        * (input[moreIndex] - input[lessIndex]);
                }
            }
            else
            {
                price += input[2] * input[moreIndex] * 2;
            }
            Console.WriteLine(price);
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
