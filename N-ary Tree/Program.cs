using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Markup;

namespace Laba2_BinaryTree
{
    internal class Program
    {
        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.Write("Type in file name: ");
            string fileName = Console.ReadLine();
            string filePath = $@"C:\Users\Luxx6\Desktop\Лабораторные работы\Графы и тензоры\Laba2_BinaryTree\Laba2_BinaryTree\{fileName}";

            Console.WriteLine("Type in max nodes for a tree: ");
            int n = int.Parse(Console.ReadLine());
            NTree tree = new NTree();
            NTree.generate_file(1000000, 5, filePath);
            NTree.parseFile(tree, n, fileName);


            (List<List<int>> longestPaths, int maxLength) = NTree.longestPath(tree.root);
            Console.WriteLine("The longest paths: ");


            for (int i = 0; i < longestPaths.Count; i++)
            {
                if (longestPaths[i].Count == maxLength)
                {
                    for (int j = 0; j < longestPaths[i].Count; j++)
                        Console.Write(longestPaths[i][j] + " ");
                    Console.WriteLine();
                }
            }

            stopwatch.Stop();

            Console.WriteLine($"\nTime: {stopwatch.ElapsedMilliseconds} Ms"); // затраченное время в миллисекундах 
        }
    }
}
