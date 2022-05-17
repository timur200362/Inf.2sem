using System;
using System.IO;
using AISD107.HuffmanCodding;
using System.Collections;
using System.Diagnostics;

namespace AISD107
{
    class Program
    {
        static void Main(string[] args)
        {
            Runner runner = new Runner();
            runner.Run();
            //var path = @"C:\Users\Admin\source\repos\Inf107(2)\AISD107\Data.txt";
            //var alphabet = "!+=123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //Filework.GenerateFile(path, alphabet);
            //var file = Filework.ReadFile(path);
            //var fileWrite = new StreamWriter(@"C:\Users\Admin\source\repos\Inf107(2)\AISD107\results.txt", true);
            //HuffmanTree huffmanTree = new HuffmanTree();
            //string input;
            //string path1 = "C:/Users/Admin/source/repos/Inf107(2)/AISD107/node3.txt";
            ////string path2 = @"C:\Users\Admin\source\repos\Inf107(2)\AISD107\results.txt";
            //using (StreamReader fileIn = new StreamReader(path))
            //{
            //    input = fileIn.ReadToEnd();
            //}

            //Stopwatch timer = new Stopwatch();
            //timer.Start();

            //huffmanTree.Build(input);
            //BitArray encoded = huffmanTree.Encode(input);

            //string decoded = huffmanTree.Decode(encoded);
            //Console.WriteLine("Decoded: " + decoded);

            //Console.Write("Encoded: ");
            //using (StreamWriter file1 = new StreamWriter(path1))
            //{
            //    foreach (bool bit in encoded)
            //    {
            //        file1.Write((bit ? 1 : 0) + "");
            //        Console.Write((bit ? 1 : 0) + "");
            //    }
            //    //Console.WriteLine();
            //}
            ////foreach (bool bit in encoded)
            ////{
            ////    fileWrite.WriteLine((bit ? 1 : 0) + "");
            ////    //Console.Write((bit ? 1 : 0) + "");
            ////}
            //timer.Stop();
            //Console.WriteLine();
            //int symbolCount = File.ReadAllText(path1).Length;
            //fileWrite.WriteLine($"{symbolCount},{timer.Elapsed.TotalSeconds},{file.Length}");
            //Console.WriteLine(symbolCount);
            //var path2 = @"C:\Users\Admin\source\repos\AISD107\results.txt";
            //HuffmanTree huffmanTree = new HuffmanTree();
            //string input;
            //using (StreamReader fileIn = new StreamReader(path))
            //{
            //    input = fileIn.ReadToEnd();
            //}

            //huffmanTree.Build(input);
            //BitArray encoded = huffmanTree.Encode(input);

            //string decoded = huffmanTree.Decode(encoded);
            //Console.WriteLine("Decoded: " + decoded);

            //Console.Write("Encoded: ");
            //foreach (bool bit in encoded)
            //{
            //    fileWrite.Write((bit ? 1 : 0) + "");
            //    Console.Write((bit ? 1 : 0) + "");
            //}
            //    Console.WriteLine();
            //int symbolCount = File.ReadAllText(path).Length;
            //Console.WriteLine(symbolCount);

            //Stopwatch timer = new Stopwatch();
            //timer.Start();

            //timer.Stop();
            //fileWrite.WriteLine($"{symbolCount},{timer.Elapsed.TotalSeconds},{file.Length}");
        }
    }

}
