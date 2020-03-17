using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class Tenka1_2014_QualA_B
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
            string s = Read();
            int now = 0;
            int damageCnt = 0;
            int bag = 5;
            long damage = 0;
            Queue<int[]> chargeQue = new Queue<int[]>();
            Queue<int[]> damageQue = new Queue<int[]>();
            Queue<int[]> returnQue = new Queue<int[]>();

            for(int i = 0; i < s.Length; i++)
            {
                now = i * 10;

                while (damageQue.Count > 0 && damageQue.Peek()[0] <= now)
                {
                    damage += damageQue.Peek()[1];
                    damageCnt++;
                    damageQue.Peek()[0] += 50;
                    returnQue.Enqueue(damageQue.Dequeue());
                }
                while (returnQue.Count > 0 && returnQue.Peek()[0] <= now)
                {
                    bag += returnQue.Dequeue()[2];
                }

                if (chargeQue.Count > 0 && chargeQue.Peek()[0] <= now)
                {
                    chargeQue.Peek()[0] += 10;
                    damageQue.Enqueue(chargeQue.Dequeue());
                }

                if (chargeQue.Count == 0)
                {
                    switch (s[i])
                    {
                        case 'N':
                            if (bag >= 1)
                            {
                                chargeQue.Enqueue(
                                    new int[3] { now + 10, 10 + (damageCnt / 10), 1 });
                                bag -= 1;
                            }
                            break;
                        case 'C':
                            if (bag >= 3)
                            {
                                chargeQue.Enqueue(
                                    new int[3] { now + 25, (10 + (damageCnt / 10)) * 5, 3 });
                                bag -= 3;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            while (chargeQue.Count > 0)
            {
                damage += chargeQue.Dequeue()[1];
            }
            while (damageQue.Count > 0)
            {
                damage += damageQue.Dequeue()[1];
            }
            WriteLine(damage);
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
