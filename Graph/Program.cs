using System;
using Graphs;

namespace Graph
{
    class Program
    {

        static void Main(string[] args)
        {
            GraphMaker gm = new GraphMaker();
            Algorithm algorithm = new Graphs.Algorithm();
            string path = "C:/Users/sk464/OneDrive/Рабочий стол/учеба/ГРАФЫ/Graf/bin/Debug/netcoreapp3.1/1.txt";
            gm.ReadFromFile(path);
            gm.PrintGraph();
            gm.PrintCost();
            algorithm.Djikstra(int src);



        }
    }
}
