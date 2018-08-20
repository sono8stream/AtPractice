using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Library.RangeScheduling
{
    class KUPC_A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            var strs = new string[t];
            for (int i = 0; i < t; i++)
            {
                strs[i] = Console.ReadLine();
            }

            for(int i = 0; i < t; i++)
            {
                int cnt = 0;
                for (int j = 0; j <= strs[i].Length - 5; j++)
                {
                    if (strs[i][j] == 't')
                    {
                        if (strs[i].Substring(j + 1, 4).Equals("okyo"))
                        {
                            cnt++;
                            j += 5;
                        }
                    }
                    else if (strs[i][j] == 'k')
                    {
                        if (strs[i].Substring(j + 1, 4).Equals("yoto"))
                        {
                            cnt++;
                            j += 5;
                        }
                    }
                }

                Console.WriteLine(cnt);
            }
        }
    }
}
