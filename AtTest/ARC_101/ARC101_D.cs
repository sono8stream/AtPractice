using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class ARC101_D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var array = new int[n];
            var subArray = new int[n];
            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(input[i]);
                subArray[i] = array[i];
            }
            Array.Sort(subArray);
            var cnt = new long[n];
            int max = (int)Math.Ceiling(n * 0.5);
            cnt[0] = n;
            cnt[n - 1] = n;
            long allPat = n * 2;
            for (int i = 1; i < n/2; i++)
            {
                cnt[i] = cnt[i - 1] + n - i * 2;
                cnt[n - i - 1] = cnt[i - 1] + n - i * 2;
                allPat += cnt[i] * 2;
            }
            if (n>2&&n % 2 == 1)
            {
                cnt[n / 2] = cnt[n / 2 - 1] + 1;
                allPat += cnt[n / 2];
            }
            Console.WriteLine(allPat);
            var valCntDict = new Dictionary<int, long>();
            for(int i = 0; i < n; i++)
            {
                if (valCntDict.ContainsKey(array[i]))
                {
                    valCntDict[array[i]] += cnt[i];
                }
                else
                {
                    valCntDict.Add(array[i], cnt[i]);
                }
            }
            long index = 0;
            long tarIndex = allPat / 2 + 1;
            for (int i = 0; i < n; i++)
            {
                index += valCntDict[subArray[i]];
                Console.WriteLine(subArray[i].ToString()
                    + ": " + valCntDict[subArray[i]]);
                if (index >= tarIndex)
                {
                    Console.WriteLine(subArray[i]);
                    return;
                }
            }
        }
    }
}
