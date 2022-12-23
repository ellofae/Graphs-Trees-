using System;
using System.Diagnostics;
using System.IO;

namespace Laba1_BinaryTree
{
    internal class Program
    {
        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            BinaryTree.generate_file(300000, "values.txt");
            string fileName = "values.txt";
            string[] temp_str = File.ReadLines($@"C:\Users\Luxx6\Desktop\Лабораторные работы\Графы и тензоры\Laba1_BinaryTree\Laba1_BinaryTree\{fileName}").First().Split(" ");
            int number = int.Parse(temp_str[0]);
            
            BinaryTree tree = new BinaryTree();
            tree.root = BinaryTree.createElement(number);
            BinaryTree.parseFile(tree.root, fileName);

            List <List<int>> temp = BinaryTree.longestPathIncrease(tree.root);
            List<List<int>> temp2 = BinaryTree.longestPathDecrease(tree.root);
            stopwatch.Stop();
            Console.WriteLine($"\nTime: {stopwatch.ElapsedMilliseconds} Ms"); // затраченное время в миллисекундах

            BinaryTree.PrintingLongestPaths(temp, temp2);
            //BinaryTree.print(tree.root, 0);            

           
        }
    }
}
