using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    public class Vertex
    {
        public enum Color
        {
            White,
            Gray,
            Black,
        };
        private int number;
        private Color color;
        public int Number
        {
            get => number;
        }
        public Color VertexColor
        {
            get => color;
            set => color = value;
        }
        public Vertex(int number)
        {
            this.number = number;
            color = 0;
        }
    }
}

