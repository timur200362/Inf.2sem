using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace AISD107.HuffmanCodding
{
    internal class Filework
    {

        public static string[] ReadFile(string path) =>
            new StreamReader(path).ReadToEnd()
                .Split('\n')
                .Where(line => !String.IsNullOrWhiteSpace(line))
                .ToArray();


        public static List<string> ReadFileList(string path) =>
            new StreamReader(path)
                .ReadToEnd()
                .Split('\n')
                .Where(line => !String.IsNullOrWhiteSpace(line))
                .ToList();


        public static void GenerateFile(string path, string alphabet)
        {
            if (string.IsNullOrWhiteSpace(alphabet))
            {
                "Alphabet is null or empty, files doesnt generated".Print(ConsoleColor.Red);
                return;
            }

            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                "Directory not found".Print(ConsoleColor.Red);
                return;
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();

            var length = new Random().Next(50, 100);
            var array = new string[length];

            for (int i = 0; i < length; i++)
            {
                var random = new Random();
                StringBuilder generated_string = new();
                int len = new Random().Next(1, 10001);

                for (int r_index = 0; r_index < len; r_index++)
                    generated_string.Append(
                        alphabet[random.Next(0, alphabet.Length - 1)]);
                array[i] = generated_string.ToString();
            }

            File.WriteAllLines(path, array);

            timer.Stop();

            $"{length} lines was added to file {path} \n{timer.Elapsed.TotalSeconds} seconds spent".Print(ConsoleColor.Green);
        }
    }

    internal static class Extensions
    {
        public static void Print(this object obj, ConsoleColor color = ConsoleColor.White)
        {
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(obj.ToString());
            Console.ForegroundColor = prevColor;
        }
    }
}
