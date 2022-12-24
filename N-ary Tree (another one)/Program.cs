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
            string filePath = $@"C:\Users\Luxx6\Desktop\Лабораторные работы\Графы и тензоры\Помощь_Лаба2\ConsoleApp1\ConsoleApp1\{fileName}";

            Console.WriteLine("Type in max nodes for a tree: ");
            int n = int.Parse(Console.ReadLine());
            NTree tree = new NTree();
            NTree.generate_file(60, 5, filePath);
            NTree.parseFile(tree, n, fileName);



            List<List<int>> temp = NTree.longestPathIncrease(tree.root);
            List<List<int>> temp2 = NTree.longestPathDecrease(tree.root);


            stopwatch.Stop();
            Console.WriteLine($"\nTime: {stopwatch.ElapsedMilliseconds} Ms"); // затраченное время в миллисекундах

            NTree.PrintingLongestPaths(temp, temp2);

            Console.WriteLine($"\nTime: {stopwatch.ElapsedMilliseconds} Ms"); // затраченное время в миллисекундах 
        }
    }
}
