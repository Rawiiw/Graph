using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class Algorithm
    {
        int vertexCount = new GraphMaker();
        int[,] graph;
        int[,] cost;

        public void Djikstra(int src)
        {

            Console.WriteLine("\ndistance from {0}", src);
            int[] dist = new int[vertexCount];
            bool[] sptSet = new bool[vertexCount];
            int[] parent = new int[vertexCount];
            graph = new int[vertexCount, vertexCount];
            cost = new int[vertexCount, vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                dist[i] = cost[src, i];
                sptSet[i] = false;
            }
            dist[src] = 0;

            while (!sptSet[src])
            {
                sptSet[src] = true;
                int minDist = int.MaxValue;
                for (int i = 0; i < vertexCount; i++)
                {
                    if (!sptSet[i] && dist[i] < minDist)
                    {
                        src = i;
                        minDist = dist[i];
                    }
                }
                for (int v = 0; v < vertexCount; v++)
                {
                    if (!sptSet[v] && graph[src, v] > 0)
                    {
                        if (dist[v] > dist[src] + cost[src, v])
                        {
                            dist[v] = dist[src] + cost[src, v];
                            parent[v] = src;
                        }
                    }
                }
            }
        }
    }

}

