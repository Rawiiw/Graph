using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    partial class Edge
    {
        public int v1, v2;

        public Edge(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}
