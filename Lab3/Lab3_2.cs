using System.Text;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Drawing;
using System.Threading.Channels;

namespace Lab3_2
{
    class Lab3_2
    {
        private const string File = "MyFile.txt";
        public static void Main(String[] args)
        {
            string str, str_copy = "";
            int num = -1;
            using (FileStream fs = new FileStream(File, FileMode.Open))
            {
                using (StreamReader sw = new StreamReader(fs))
                    str = sw.ReadToEnd();

                string[] split = str.Split(new Char[] { ' ' });

                Console.WriteLine("Рядок з файлу з вiдмiченими непарними мiсцями:\n");

                for (int i = 0; i < split.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(split[i] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(split[i] + " ");
                    }
                }

                Console.WriteLine("\n\nРядок з файлу з продубльованими в ньому парними числа, якi знаходяться на непарних мiсцях:\n");

                for (int i = 0; i < split.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (Int32.TryParse(split[i], out num))
                        {
                            if (num % 2 == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(split[i] + " " + split[i] + " ");
                                Console.ResetColor();
                                str_copy += split[i] + " " + split[i] + " ";
                            }
                            else
                            {
                                Console.Write(split[i] + " ");
                                str_copy += split[i] + " ";
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nВ файлi знайшовся символ який не є цiлим числом.");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.Write(split[i] + " ");
                        str_copy += split[i] + " ";
                    }
                }
                Console.Write("\n");     
                str_copy = str_copy.Trim();
            }
            using (StreamWriter writer = new StreamWriter(File, false))
            {
                writer.Write(str_copy);
            }
        }
    }
}