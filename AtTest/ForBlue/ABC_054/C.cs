using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_054
{
    class C
    {
        static int n;
        static Stack<int> visitPos;
        static Node[] nodes;
        static long cnt;

        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            nodes = new Node[n];
            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node();
            }
            for (int i = 0; i < m; i++)
            {
                string[] inText = Console.ReadLine().Split(' ');
                int a = int.Parse(inText[0]) - 1;
                int b = int.Parse(inText[1]) - 1;
                nodes[a].to.Add(b);
                nodes[b].to.Add(a);
            }

            cnt = 0;
            visitPos = new Stack<int>();
            visitPos.Push(0);
            DFS();

            Console.WriteLine(cnt);
        }

        static void DFS()
        {
            if (visitPos.Count == n)//全部行った
            {
                cnt++;
                return;
            }

            //行ける場所探索
            int index = visitPos.Peek();
            for (int i = 0; i < nodes[index].to.Count; i++)
            {
                if (!visitPos.Contains(nodes[index].to[i]))
                {
                    visitPos.Push(nodes[index].to[i]);
                    DFS();
                    visitPos.Pop();
                }
            }
        }
    }

    class Node
    {
        public List<int> to;

        public Node()
        {
            to = new List<int>();
        }
    }
}
