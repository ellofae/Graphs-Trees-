using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_BinaryTree
{
    public class BinaryTree
    {
        public Node root;

        public BinaryTree()
        {
            root = null;
        }
        public BinaryTree(int key)
        {
            root = new Node(key);
        }

        // Creation

        public static Node createElement(int val)
        {
            Node elem = new Node(val);
            return elem;
        }

        public static void insertLeft(Node root, Node elem)
        {
            if (root.left == null)
            {
                elem.previous = root;
                root.left = elem;
            }
        }

        public static void insertRight(Node root, Node elem)
        {
            if (root.right == null)
            {
                elem.previous = root;
                root.right = elem;
            }
        }

        public static Node goToLeft(Node root)
        {
            if (root.left != null)
            {
                return root.left;
            }
            else
            {
                return root;
            }
        }

        public static Node goToRight(Node root)
        {
            if (root.right != null)
            {
                return root.right;
            }
            else
            {
                return root;
            }
        }


        public static Node goToPrev(Node root)
        {
            if (root.previous != null)
            {
                return root.previous;
            }
            else
            {
                return root;
            }
        }

        public static void print(Node root, int level)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                print(root.right, ++level);
                for (int i = 0; i < level; i++)
                {
                    Console.Write("|");
                }
                Console.Write(root.Value);
                Console.Write("\n");
                --level;
            }
            print(root.left, ++level);
        }

        public static void parseFile(Node root, string file_name)
        {
            Node temp = root;
            string command = "";
            int number;

            string filePath = $@"C:\Users\Luxx6\Desktop\Лабораторные работы\Графы и тензоры\Laba1_BinaryTree\Laba1_BinaryTree\{file_name}";
            List<string> lines = File.ReadAllLines(filePath).ToList();

            
            foreach (var line in lines)
            {
                string[] entries = new string[2];
                entries = line.Split(' ');
                number = int.Parse(entries[0]);
                if(entries.Length == 1)
                    command = " ";
                else
                    command = entries[1];

                //Console.WriteLine($"{entries[0]}, {entries[1]}");

                if (command == "cl")
                {
                    BinaryTree.insertLeft(root, BinaryTree.createElement(number));
                }
                if (command == "cr")
                {
                    BinaryTree.insertRight(root, BinaryTree.createElement(number));
                }
                if (command == "gl")
                {
                    root = BinaryTree.goToLeft(root);
                }
                if (command == "gp")
                {
                    root = BinaryTree.goToPrev(root);
                }
                if (command == "gr")
                {
                    root = BinaryTree.goToRight(root);
                }
            }
        }

        // Generatic a file
        public static void generate_file(int size, string filename)
        {
            string filePath = $@"C:\Users\Luxx6\Desktop\Лабораторные работы\Графы и тензоры\Laba1_BinaryTree\Laba1_BinaryTree\{filename}";

            string[] str = { "cl", "cr", "gl", "gr", "gp" };
            string s = "";

            int lowerRange = 1;
            int upperRange = 100;
            int number;
            Random r = new Random();


            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine(r.Next(lowerRange, upperRange));

                for (int i = 0; i < size; i++)
                {
                    number = r.Next(lowerRange, upperRange);
                    int temp = r.Next(0, 5);

                    writer.WriteLine(number + " " + str[temp]);
                }
                writer.Flush();
                writer.Close();
            }
        }


        // Increase

        public static List<List<int>> longestPathIncrease(Node root)
        {
            List<List<int>> temp = new List<List<int>>();
            List<int> arr = new List<int>();
            longestPathUtil(root, arr, temp);

            return temp;
        }

        static void longestPathUtil(Node root, List<int> arr, List<List<int>> temp)
        {
            if (arr.Count == 0)
                arr.Add(root.Value);
            else
            {
                if (arr.Last() <= root.Value)
                    arr.Add(root.Value);
                else
                {
                    List<int> new_arr = new List<int>(arr);
                    temp.Add(new_arr);
                    arr.Clear();
                    arr.Add(root.Value);
                }
            }

            if (root.left != null)
            {
                List<int> new_arr = new List<int>(arr);
                longestPathUtil(root.left, new_arr, temp);
            }

            if (root.right != null)
            {
                List<int> new_arr = new List<int>(arr);
                longestPathUtil(root.right, new_arr, temp);
            }

            if (root.left == null && root.right == null)
            {
                List<int> new_arr = new List<int>(arr);
                temp.Add(new_arr);
            }
        }


        // Decrease

        public static List<List<int>> longestPathDecrease(Node root)
        {
            List<List<int>> temp = new List<List<int>>();
            List<int> arr = new List<int>();
            longestPathUtilDec(root, arr, temp);

            return temp;
        }

        static void longestPathUtilDec(Node root, List<int> arr, List<List<int>> temp)
        {
            if (arr.Count == 0)
                arr.Add(root.Value);
            else
            {
                if (arr.Last() >= root.Value)
                    arr.Add(root.Value);
                else
                {
                    List<int> new_arr = new List<int>(arr);
                    temp.Add(new_arr);
                    arr.Clear();
                    arr.Add(root.Value);
                }
            }

            if (root.left != null)
            {
                List<int> new_arr = new List<int>(arr);
                longestPathUtilDec(root.left, new_arr, temp);
            }

            if (root.right != null)
            {
                List<int> new_arr = new List<int>(arr);
                longestPathUtilDec(root.right, new_arr, temp);
            }

            if (root.left == null && root.right == null)
            {
                List<int> new_arr = new List<int>(arr);
                temp.Add(new_arr);
            }
        }

        // Printing a reslut:

        public static void PrintingLongestPaths(List<List<int>> temp, List<List<int>> temp2)
        {
            List<List<int>> longestPaths = new();
            for (int i = 0; i < temp2.Count; i++) // i for temp2
            {
                int k = temp2[i][0];
                for (int j = 0; j < temp.Count; j++) // j for temp
                {
                    if (!temp[j].Contains(k))
                        continue;
                    else
                    {
                        bool condition = false;
                        List<int> temper = new List<int>();
                        int counter = 0;

                        for (int item2 = temp2[i].Count - 1; item2 >= 0; item2--)
                        {
                            temper.Add(temp2[i][item2]);
                            //Console.Write(temp2[i][item2] + " ");
                        }
                        for (int item1 = 0; item1 < temp[j].Count; item1++)
                        {
                            if (condition)
                            {
                                temper.Add(temp[j][item1]);
                                //Console.Write(temp[j][item1] + " ");
                            }
                            if (temp[j][item1] == k)
                                condition = true;
                        }
                        longestPaths.Add(temper);

                    }
                }
            }

            int maxLength = MaxLength(longestPaths);
            Console.WriteLine($"Maximum path length: {maxLength}");

            for (int i = 0; i < longestPaths.Count; i++)
            {
                if (longestPaths[i].Count == maxLength)
                {
                    for (int j = 0; j < longestPaths[i].Count; j++)
                        Console.Write(longestPaths[i][j] + " ");
                    Console.WriteLine();
                }
            }

        }

        private static int MaxLength(List<List<int>> longestPaths)
        {
            int count = 0;
            int maxCount = 0;

            for (int i = 0; i < longestPaths.Count; i++)
            {
                for (int j = 0; j < longestPaths[i].Count; j++)
                    count++;

                maxCount = Math.Max(count, maxCount);
                count = 0;
            }

            return maxCount;
        }
    }
}
