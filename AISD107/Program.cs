using System;
using System.IO;
using AISD107.HuffmanCodding;
using System.Collections;

namespace AISD107
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = @"C:\Users\Admin\source\repos\AISD107\Data.text";
            //var alphabet = "!+=123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //Filework.GenerateFile(path, alphabet);
            //var file=Filework.ReadFile(path);
            //var fileWrite = new StreamWriter(@"C:\Users\Admin\source\repos\AISD107\results.txt",true);
            ////var path2 = @"C:\Users\Admin\source\repos\AISD107\results.txt";
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
            HuffmanTree huffmanTree = new HuffmanTree();
            string input;
            string path1 = "C:/Users/Admin/source/repos/AISD107/node1.txt";
            string path2 = "C:/Users/Admin/source/repos/AISD107/node2.txt";
            using (StreamReader fileIn = new StreamReader(path1))
            {
                input = fileIn.ReadToEnd();
            }

            huffmanTree.Build(input);
            BitArray encoded = huffmanTree.Encode(input);

            string decoded = huffmanTree.Decode(encoded);
            Console.WriteLine("Decoded: " + decoded);

            Console.Write("Encoded: ");
            using (StreamWriter file = new StreamWriter(path2))
            {
                foreach (bool bit in encoded)
                {
                    file.Write((bit ? 1 : 0) + "");
                    Console.Write((bit ? 1 : 0) + "");
                }
                Console.WriteLine();

            }
            int symbolCount = File.ReadAllText(path2).Length;
            Console.WriteLine(symbolCount);
        }
    }
}
