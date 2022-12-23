using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    internal class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int val)
        {
            Value = val;
        }
    }
}
