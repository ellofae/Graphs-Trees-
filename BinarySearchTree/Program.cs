using System;
using System.Diagnostics;
using System.IO;

namespace Laba1
{
    internal class Program
    {
        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var Tree = new BinarySearchTree();

            var rand = new Random();
            //int[] Values = new int[20];
            //int[] Values = new int[100000];
            //int[] Values = new int[20];
            //for (int i = 0; i < Values.Length; i++)
                //Values[i] = rand.Next(1, 100);

            // DEBUG
            //Console.WriteLine("DEBUG: ");
            //foreach (var i in Values)
            //    Console.Write(i + " ");

            string filePath = @"C:\Users\Luxx6\Desktop\Лабораторные работы\Графы и тензоры\Laba1\Laba1\values.txt";
            string[] line = File.ReadAllLines(filePath);
            string[] elements = line[0].Split(" ");
            int[] Values = new int[elements.Length];
            for (int i = 0; i < elements.Length; i++)
                Values[i] = int.Parse(elements[i]);

            Tree.Insert(Values);

            int maxLength = BinarySearchTree.maxConsecutivePathLength(Tree.Root);
            BinarySearchTree.PrintingPath(BinarySearchTree.longestPath(Tree.Root), maxLength);
            Console.WriteLine($"\nLongest path length: {maxLength}");

            Console.WriteLine("\nInorder tree walk:");
            BinarySearchTree.Inorder_Tree_Walk(Tree.Root);


            stopwatch.Stop();
            Console.WriteLine($"\nTime: {stopwatch.ElapsedMilliseconds} Ms"); // затраченное время в миллисекундах
            var memory = 0.0;
            using (Process proc = Process.GetCurrentProcess())
            {
                memory = proc.PrivateMemorySize64 / (1024 * 1024);
            }
            Console.WriteLine($"Memory used: {memory} Mb");

        }
    }
    
}
