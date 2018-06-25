using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.AllSearch
{
    class ABC_002_D
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            bool[,] relation = new bool[n, n];
            for (int i = 0; i < m; i++)
            {
                string[] inRelation = Console.ReadLine().Split(' ');
                int man = int.Parse(inRelation[0])-1;
                int rel = int.Parse(inRelation[1])-1;
                relation[man, rel] = true;
            }

            for(int i = 0; i < n; i++)
            {
                string s = "";
                for(int j = 0; j < n; j++)
                {
                    if (relation[i, j]) s += "○";
                    else s += "□";
                }
                Console.WriteLine(s);
            }

            int maxRel = 1;
            for (int i = 0; i < n; i++)
            {
                List<int> relIndex = new List<int>();
                for (int j = i + 1; j < n; j++)
                {
                    if (relation[i, j]) relIndex.Add(j);
                }

                if (relIndex.Count == 0) continue;
                int relCnt = RelCount(relation, relIndex, relIndex.Count + 1);
                if (maxRel < relCnt)
                {
                    maxRel = relCnt;
                }
            }


            Console.WriteLine(maxRel);
        }

        //再帰関数
        static int RelCount(bool[,] rels, List<int> relIndexes,int cnt)
        {
            int row = relIndexes[0];
            List<int> newRelIndexes = new List<int>();
            for (int i = 1; i < relIndexes.Count; i++)
            {
                if (rels[row, relIndexes[i]]) newRelIndexes.Add(relIndexes[i]);
                else cnt--;
            }
            if (newRelIndexes.Count == 0)
            {
                return cnt;
            }
            else
            {
                return RelCount(rels, newRelIndexes, cnt);
            }
        }
    }
}
