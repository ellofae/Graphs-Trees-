using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laba2_BinaryTree
{
    public class NTree
    {
        public Node root = new Node();
        private List<Node> nodes = new List<Node>();
        public static int maxChildrenCount = 0;
        public static Node createElement(int value)
        {
            Node elem = new Node();
            elem.Value = value;
            elem.parent = null;

            for (int i = 0; i < Globals.sonsAmount; i++)
            {
                elem.child.Add(new Node());
            }
            return elem;
        }

        public static void insert(Node parent, Node elem, int pos)
        {
            pos--;
            if (parent.child[pos] == null)
            {
                parent.child[pos] = elem;
                parent.child[pos].parent = parent;
                Globals.nodes.Add(elem);
            }
        }

        public static Node goNext(Node current, int pos)
        {
            pos--;
            if (current.child[pos] != null)
            {
                return current.child[pos];
            }
            else
            {
                return current;
            }
        }

        public static Node goPrev(Node current)
        {
            if (current.parent != null)
            {
                return current.parent;
            }
            else
            {
                return current;
            }
        }

        public static void generate_file(int size, int n, string filePath)
        {
            Random r = new Random();
            string[] commands = new string[4] { "c", "gs", "gp", "c" };

            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                int root = r.Next(0, 10);
                if (root == 0) root = 1;
                writer.WriteLine(root);

                for (int i = 0; i < size-1; i++)
                {
                    int randomN = r.Next(0, n - 1);
                    int command = r.Next(0, 4);
                    int value = r.Next(0, 100);


                    if (command == 0 || command == 2)
                    {
                        writer.WriteLine(commands[command] + " " + value);
                    }
                    else if (command == 1)
                    {
                        writer.WriteLine(commands[command] + " " + randomN);
                    }
                    else
                        writer.WriteLine(commands[command] + " " + randomN);
                }
                writer.Flush();
                writer.Close();
            }
        }

        //FAFSFAFSAFAFA

        public static void addChildren(Node parent, Node children)
        {
            parent.child.Add(children);
            children.parent = parent;
            //NTree.nodes.add(children);
            ++parent.childrensCount;
            NTree.maxChildrenCount = Math.Max(parent.childrensCount, maxChildrenCount);
        }

        public static void parseFile(NTree tree, int n, string file_name)
        {
            string filePath = $@"C:\Users\Luxx6\Desktop\Лабораторные работы\Графы и тензоры\Laba2_BinaryTree\Laba2_BinaryTree\{file_name}";
            List<string> lines = File.ReadAllLines(filePath).ToList();

            tree.root = new Node(int.Parse(File.ReadAllLines(filePath).ToList().First()));
            tree.nodes.Add(tree.root);
            Node current = tree.root;

            foreach (var line in lines)
            {
                string[] temp = line.Split(" ");
                if (temp[0] == "c")
                {
                    if (current.childrensCount < n)
                    {
                        NTree.addChildren(current, new Node(int.Parse(temp[1])));
                    }
                }
                if (temp[0] == "gs")
                {
                    try
                    {
                        if (current.childrensCount == 1 && int.Parse(temp[1]) == 0)
                        {
                            current = current.child[0];
                        }
                        if (current.childrensCount > 1 && current.childrensCount > int.Parse(temp[1]))
                        {
                            current = current.child[int.Parse(temp[1])];
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("error");
                    }
                }
                if (temp[0] == "gp")
                {
                    if (current.parent != null)
                    {
                        current = NTree.goPrev(current);
                    }
                }

            }
            // FAFSFASFASFASF

        }
        //
        public static (List<List<int>>, int) longestPath(Node root)
        {
            List<List<int>> temp = new List<List<int>>();
            List<int> arr = new List<int>();

            int maxCount = 0;
            int count = 0;
            longestPathUtil(root, arr, temp, count, ref maxCount);
            Console.WriteLine($"Longest length of a path is: {maxCount}");
            return (temp, maxCount);
        }

        public static void longestPathUtil(Node root, List<int> arr, List<List<int>> temp, int count, ref int maxCount)
        {
            if (arr.Count == 0)
            {
                arr.Add(root.Value);
                count++;
            }
            else
            {
                if (NTree.IsOddNumber(root))
                {
                    arr.Add(root.Value);
                    count++;
                }
                else
                {
                    List<int> new_arr = new List<int>(arr);
                    temp.Add(new_arr);
                    arr.Clear();
                    maxCount = Math.Max(maxCount, count);
                    count = 0;
                    return;
                }
            }

            if (root.child.Count != 0)
            {
                for (int i = 0; i < root.child.Count; i++)
                {
                    List<int> new_arr = new List<int>(arr);
                    longestPathUtil(root.child[i], new_arr, temp, count, ref maxCount);
                }
            }
            else
            {
                List<int> new_arr = new List<int>(arr);
                temp.Add(new_arr);
                maxCount = Math.Max(maxCount, count);
                count = 0;
            }
        }

        static bool IsOddNumber(Node root)
        {
            if (root != null)
            {
                if (root.Value % 2 == 0)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

    }
}
