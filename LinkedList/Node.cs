using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class Node
    {
        public string Data { get; }
        public Node Next { get; set; }

        public Node(string data)
        {
            Data = data;
        }
    }
}
