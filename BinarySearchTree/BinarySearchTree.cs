using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    internal class BinarySearchTree
    {
        public Node Root;

        public void Insert(int Value)
        {
            if (Root == null)
            {
                Root = new Node(Value);
            }
            else
            {
                InsertHelper(Value, Root);
            }
        }

        public void Insert(int[] Values)
        {
            if (Values.Length == 0)
                return;

            int index = 0;

            if (Root == null)
            {
                Root = new Node(Values[0]);
                index++;
            }

            for (int i = index; i < Values.Length; i++)
                InsertHelper(Values[i], Root);
        }

        private Node InsertHelper(int Value, Node node)
        {
            if (node == null)
            {
                node = new Node(Value);
                return node;
            }
            if (Value.CompareTo(node.Value) == -1)
            {
                node.Left = InsertHelper(Value, node.Left);
            }
            else
            {
                node.Right = InsertHelper(Value, node.Right);
            }

            return node;
        }

        public static Node Tree_Search(Node root, int k)
        {
            if (root == null || k == root.Value)
                return root;
            if (k < root.Value)
                return Tree_Search(root.Left, k);
            else
                return Tree_Search(root.Right, k);
        }
        public static void Inorder_Tree_Walk(Node root)
        {
            if(root != null)
            {
                Inorder_Tree_Walk(root.Left);
                Console.Write(root.Value + " ");
                Inorder_Tree_Walk(root.Right);
            }
        }

        static int maxPathLenUtil(Node root, int prev_val, int prev_len)
        {
            if (root == null)
                return prev_len;
      
            int cur_val = root.Value;

            if (cur_val >= prev_val)
            {
                return Math.Max(maxPathLenUtil(root.Left, cur_val, prev_len + 1),
                        maxPathLenUtil(root.Right, cur_val, prev_len + 1));
            }

            int newPathLen = Math.Max(maxPathLenUtil(root.Left, cur_val, 1),
                                maxPathLenUtil(root.Right, cur_val, 1));
 
            return Math.Max(prev_len, newPathLen);
        }

        public static int maxConsecutivePathLength(Node root)
        {
            if (root == null)
                return 0;

            return maxPathLenUtil(root, root.Value, 0);
        }

        public bool isLeaf(Node node)
        {
            return (node.Left == null && node.Right == null);
        }

        public static List<int> longestPath(Node root)
        { 
            if (root == null)
            {
                List<int> output = new List<int>();
                return output;
            }

            List<int> right = longestPath(root.Right);

            List<int> left = longestPath(root.Left);

            if(left.Count == 0)
            {
                right.Add(root.Value);
                //if (right.Count < left.Count) // INCORRECT  (get last value and compare with the future one idk)
                //{
                //    left.Add(root.Value);
                //}
                //else
                //{
                //    right.Add(root.Value);
                //}
            } else
            {
                left.Add(-1);
                right.Add(root.Value);
                //right.Add(-1);
            }



            //if (right.Count < left.Count) // INCORRECT  (get last value and compare with the future one idk)
            //{
            //    left.Add(root.Value);
            //}
            //else
            //{
            //    right.Add(root.Value);
            //}

            //Console.WriteLine($"left count: {left.Count}, right count: {right.Count}, root.Value: {root.Value}");
            ////return (left.Count > right.Count ? left : right);

            //Console.WriteLine("\nLongest path LEFT:");
            //foreach (var i in left)
            //    Console.Write(i + " ");

            //Console.WriteLine("\nLongest path RIGHT:");
            //foreach (var i in right)
            //    Console.Write(i + " ");
            //Console.WriteLine();

            List<int> result = new List<int>();
            result.AddRange(left); // sweeeped
            result.AddRange(right);
            return result;
            //if (left.Count > right.Count)
            //{
            //    result.AddRange(right);
            //    result.AddRange(left);
            //    return result;
            //}
            //else if (left.Count < right.Count)
            //{
            //    result.AddRange(left);
            //    result.AddRange(right);
            //    return result;
            //}
            //else
            //    return right;

            ////return result;
            //return (left.Count > right.Count ? left : right);
        }

        public static void PrintingPath(List<int> longestBinaryPath, int len)
        {
            Console.WriteLine("Longest paths of binary search tree:");
            longestBinaryPath.Add(-1);

            List<int> temp = new List<int>();
            int count = 0;
            foreach (var item in longestBinaryPath)
            {
                if(item != -1)
                {
                    temp.Add(item);
                    count++;
                }
                else
                {  
                    if (count == len)
                    {
                        foreach (var i in temp)
                            Console.Write(i + " ");
                        Console.WriteLine();
                        temp.Clear();
                        count = 0;
                    }
                    else
                    {
                        temp.Clear();
                        count = 0;
                    }
                }
            }
        }   
    }
}
