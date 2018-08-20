using System;
using System.Collections.Generic;

namespace AtTest.ABC_105
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            if (n == 0)
            {
                Console.WriteLine(0);
            }

            //指数が小さいほうからスタートするのがポイント
            var haveIndexList = new List<bool>();
            long checkIndex = 1;
            while (n != 0)
            {
                if (Math.Abs(n) % Math.Pow(2,checkIndex) != 0)
                {
                    haveIndexList.Add(true);
                    long val = (long)Math.Pow(2, checkIndex - 1);
                    if ((checkIndex - 1) % 2 == 1) val *= -1;
                    n -= val;
                }
                else
                {
                    haveIndexList.Add(false);
                }
                checkIndex++;
            }

            string result = "";
            for (int i = haveIndexList.Count - 1; i >= 0; i--)
            {
                result += haveIndexList[i] ? '1' : '0';
            }
            Console.WriteLine(result);
        }
    }
}
