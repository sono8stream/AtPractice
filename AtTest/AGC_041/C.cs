using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_041
{
    class C
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
            if (n == 2)
            {
                WriteLine(-1);
                return;
            }

            if (n == 3)
            {
                char[][] pat3 = new char[3][]
                {
                new char[3] {'a','a','.'},
                new char[3]{'.','.','a'},
                new char[3]{'.','.','a'}
                };

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Write(pat3[i][j]);
                    }
                    WriteLine();
                }
            }
            else
            {
                char[][] pat4 = new char[4][]
                {
                new char[4]{'a','a','b','c'},
                new char[4]{'d','d','b','c'},
                new char[4]{'e','f','g','g'},
                new char[4]{'e','f','h','h'},
                };
                char[][] pat5 = new char[5][]
                {
                new char[5]{'a','a','b','b','c'},
                new char[5]{'d','e','e','.','c'},
                new char[5]{'d','.','.','e','d'},
                new char[5]{'c','.','.','e','d'},
                new char[5]{'c','b','b','a','a'},
                };
                char[][] pat6 = new char[6][]
                {
                new char[6]{'a','a','b','c','.','.'},
                new char[6]{'d','d','b','c','.','.'},
                new char[6]{'.','.','a','a','b','c'},
                new char[6]{'.','.','d','d','b','c'},
                new char[6]{'b','c','.','.','a','a'},
                new char[6]{'b','c','.','.','d','d'},
                };
                char[][] pat7 = new char[7][]
                {
                new char[7]{'a','a','b','b','c','c','.'},
                new char[7]{'d','d','.','d','d','.','a'},
                new char[7]{'.','.','d','.','.','d','a'},
                new char[7]{'.','.','d','.','.','d','b'},
                new char[7]{'d','d','.','d','d','.','b'},
                new char[7]{'.','.','d','.','.','d','c'},
                new char[7]{'.','.','d','.','.','d','c'},
                };

                int now = 0;
                for (int i = 0; i < n / 4 - 1; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            if (k >= now && k < now + 4)
                            {
                                Write(pat4[j][k - now]);
                            }
                            else
                            {
                                Write('.');
                            }
                        }
                        WriteLine();
                    }
                    now += 4;
                }

                if (n % 4 == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < n; j++)
                        { 
                            if (j >= now && j < now + 4)
                            {
                                Write(pat4[i][j - now]);
                            }
                            else
                            {
                                Write('.');
                            }
                        }
                        WriteLine();
                    }
                }
                else if (n % 4 == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (j >= now && j < now + 5)
                            {
                                Write(pat5[i][j - now]);
                            }
                            else
                            {
                                Write('.');
                            }
                        }
                        WriteLine();
                    }
                }
                else if (n % 4 == 2)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (j >= now && j < now + 6)
                            {
                                Write(pat6[i][j - now]);
                            }
                            else
                            {
                                Write('.');
                            }
                        }
                        WriteLine();
                    }
                }
                else if (n % 4 == 3)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (j >= now && j < now + 7)
                            {
                                Write(pat7[i][j - now]);
                            }
                            else
                            {
                                Write('.');
                            }
                        }
                        WriteLine();
                    }
                }
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
