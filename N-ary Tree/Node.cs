using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_BinaryTree
{
    public class Node
    {
        public int Value;
        public Node parent;
        public List<Node> child = new List<Node>();
        public int childrensCount;

        public Node() 
        { }

        public Node(int key)
        {
            this.Value = key;
        }
    }
}
