using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace Graphs
{
    public class GraphMaker
    {
        public int[,] graph;
        public int[,] cost;


        public int vertexCount;

        public GraphMaker(string path)
        {
            ReadFromFile(path);
        }

        public GraphMaker()
        {
        }

        public void ReadFromFile(string path)
        {
            if (File.ReadLines(path).Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong file format!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            vertexCount = Convert.ToInt32(File.ReadLines(path).First());

            graph = new int[vertexCount, vertexCount];
            cost = new int[vertexCount, vertexCount];

            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++) //с 1 потому что 1 строка - кол-во вершин
            {
                string[] separatedLine = lines[i].Split(' ');

                int x = Convert.ToInt32(separatedLine[0]);
                int y = Convert.ToInt32(separatedLine[1]);
                int sampleCost = Convert.ToInt32(separatedLine[2]);

                graph[x, y] = 1;
                cost[x, y] = sampleCost;
            }
        }

        public void PrintGraph()
        {
            if (graph == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can't print empty graph!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.ForegroundColor = graph[i, j] == 1 ? Console.ForegroundColor = ConsoleColor.Green : Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PrintCost()
        {
            if (cost == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can't print empty cost graph!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            for (int i = 0; i < cost.GetLength(0); i++)
            {
                for (int j = 0; j < cost.GetLength(1); j++)
                {
                    Console.ForegroundColor = cost[i, j] > 0 ? Console.ForegroundColor = ConsoleColor.Blue : Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(cost[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        //заполняет матрицу смежности
        void fillAdjacencyMatrix(int numberV, List<Edge> E, int[,] matrix)
        {
            for (int i = 0; i < numberV; i++)
                for (int j = 0; j < numberV; j++)
                    matrix[i, j] = 0;
            for (int i = 0; i < E.Count; i++)
            {
                matrix[E[i].v1, E[i].v2] = 1;
                matrix[E[i].v2, E[i].v1] = 1;
            }
        }

        //заполняет матрицу инцидентности
        void fillIncidenceMatrix(int numberV, List<Edge> E, int[,] matrix)
        {
            for (int i = 0; i < numberV; i++)
                for (int j = 0; j < E.Count; j++)
                    matrix[i, j] = 0;
            for (int i = 0; i < E.Count; i++)
            {
                matrix[E[i].v1, i] = 1;
                matrix[E[i].v2, i] = 1;
            }
        }

        public static implicit operator int(GraphMaker v)
        {
            throw new NotImplementedException();
        }
    }
}

