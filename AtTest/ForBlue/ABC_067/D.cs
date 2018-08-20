using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ForBlue.ABC_067
{
    class D
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var nodes = new Node[n];
            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node();

            }
            for (int i = 0; i < n - 1; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int a = int.Parse(input[0]) - 1;
                int b = int.Parse(input[1]) - 1;
                nodes[a].edgeTo.Add(b);
                nodes[b].edgeTo.Add(a);
            }

            nodes[0].blackDistance = 0;
            nodes[n - 1].whiteDistance = 0;
            //幅優先探索
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[2] { 0, 1 });//index,distance
            while (queue.Count > 0)
            {
                int index = queue.Peek()[0];
                int distance = queue.Dequeue()[1];
                for (int i = 0; i < nodes[index].edgeTo.Count; i++)
                {
                    if (nodes[nodes[index].edgeTo[i]].blackDistance > -1) continue;
                    nodes[nodes[index].edgeTo[i]].blackDistance = distance;
                    queue.Enqueue(new int[2] { nodes[index].edgeTo[i], distance + 1 });
                }
            }
            queue.Enqueue(new int[2] { n - 1, 1 });
            while (queue.Count > 0)
            {
                int index = queue.Peek()[0];
                int distance = queue.Dequeue()[1];
                for (int i = 0; i < nodes[index].edgeTo.Count; i++)
                {
                    if (nodes[nodes[index].edgeTo[i]].whiteDistance > -1) continue;
                    nodes[nodes[index].edgeTo[i]].whiteDistance = distance;
                    queue.Enqueue(new int[2] { nodes[index].edgeTo[i], distance + 1 });
                }
            }

            int blackCnt = 0, whiteCnt = 0;
            for(int i = 0; i < n; i++)
            {
                if (nodes[i].blackDistance <= nodes[i].whiteDistance)
                {
                    blackCnt++;
                }
                else
                {
                    whiteCnt++;
                }
            }
            string s = blackCnt > whiteCnt ? "Fennec" : "Snuke";
            Console.WriteLine(s);
        }
    }

    class Node
    {
        public int blackDistance, whiteDistance;
        public List<int> edgeTo;
        public Node()
        {
            edgeTo = new List<int>();
            blackDistance = -1;
            whiteDistance = -1;
        }
    }
}
