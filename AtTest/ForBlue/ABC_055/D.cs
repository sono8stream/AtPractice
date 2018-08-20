using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ForBlue.ABC_055
{
    class AtTemplate
    {
        static int n;
        static string pattern;

        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            pattern = Console.ReadLine();

            var result = new char[n];

            result[0] = 'S';
            result[1] = 'S';
            if (OK(ref result))
            {
                Console.WriteLine(result);
                return;
            }
            result[0] = 'S';
            result[1] = 'W';
            if (OK(ref result))
            {
                Console.WriteLine(result);
                return;
            }
            result[0] = 'W';
            result[1] = 'S';
            if (OK(ref result))
            {
                Console.WriteLine(result);
                return;
            }
            result[0] = 'W';
            result[1] = 'W';
            if (OK(ref result))
            {
                Console.WriteLine(result);
                return;
            }

            Console.WriteLine(-1);
        }

        static bool OK(ref char[] result)
        {
            var firstResult = result[0];
            for (int i = 1; i < n; i++)
            {
                int nextNo = (i + 1) % n;
                if (pattern[i] == 'o')
                {
                    if (result[i - 1] == 'S')
                    {
                        result[nextNo] = result[i] == 'S' ? 'S' : 'W';
                    }
                    else
                    {
                        result[nextNo] = result[i] == 'S' ? 'W' : 'S';
                    }
                }
                else
                {
                    if (result[i - 1] == 'S')
                    {
                        result[nextNo] = result[i] == 'S' ? 'W' : 'S';
                    }
                    else
                    {
                        result[nextNo] = result[i] == 'S' ? 'S' : 'W';
                    }
                }
            }

            if (result[0] == firstResult)
            {
                if (pattern[0] == 'o')
                {
                    if (result[0] == 'S')
                    {
                        return result[1] == result[n - 1];
                    }
                    else
                    {
                        return result[1] != result[n - 1];
                    }
                }
                else
                {
                    if (result[0] == 'S')
                    {
                        return result[1] != result[n - 1];
                    }
                    else
                    {
                        return result[1] == result[n - 1];
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}
