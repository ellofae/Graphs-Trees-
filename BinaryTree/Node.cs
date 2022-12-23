using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_BinaryTree
{
    public class Node
    {
        public int Value;
        public Node left;
        public Node right;
        public Node previous;
        public Node(int val)
        {
            Value = val;
            left = null;
            right = null;
            previous = null;
        }

    }
}
