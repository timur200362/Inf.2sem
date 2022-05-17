using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace AISD107.HuffmanCodding
{
    public class Runner
    {
        public void Run()
        {
            HuffmanTree huffmanTree = new HuffmanTree();
            string input;
            string path1 = "C:/Users/Admin/source/repos/Inf107(2)/AISD107/node1.txt";
            string path2 = "C:/Users/Admin/source/repos/Inf107(2)/AISD107/node2.txt";
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
