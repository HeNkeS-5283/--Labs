using System.Text;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Drawing;
using System.Threading.Channels;

namespace Lab3_3
{
    class Lab3_3
    {
        static public string conv_i(string a)
        {
            char[] word = new char[a.Length];
            word = a.ToCharArray();

            for (int i = 0; i < a.Length; i++)
            {
                if ((int)word[i] == 1110) word[i] = 'i';
                if ((int)word[i] == 1030) word[i] = 'I';
            }

            string str_out = new string(word);
            return str_out;
        }

        private const string File = "input.txt";
        public static void Main(String[] args)
        {
            string str, str2 = "";
            int poin, sum = 0;
            using (FileStream fs = new FileStream(File, FileMode.Open))
            {
                using (StreamReader sw = new StreamReader(fs))
                    str = sw.ReadToEnd();
                str = conv_i(str);
                Console.WriteLine("Рядок з файлу:\n" + str + "\n");
                string[] sentence = str.Split(new Char[] { '.', '!', '?' });
                for (int i = 0; i < sentence.Length; i++)
                {
                    sentence[i] = sentence[i].Trim();
                    if (sentence[i].Length != 0)
                    {
                        string[] words = sentence[i].Split(new Char[] { ' ' });
                        poin = words.Length;
                        if (poin % 2 != 0)
                        {
                            sum++;
                            str2 += sentence[i] + ". ";
                        }
                    }
                }
                Console.WriteLine("Кiлькiсть речень, що мiстять непарну кiлькiсть слiв: " + sum + "\n\nРечення що мiстять непарну кiлькiсть слiв:\n" + str2);
                Console.WriteLine("\nВони були записанi в файл \"output.txt\"");
            }
            using (FileStream fs = new FileStream("output.txt", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write("Кiлькiсть речень, що мiстять непарну кiлькість слiв: " + sum + "\n\nРечення що мiстять непарну кiлькiсть слiв:\n" + str2);
                }
            }
        }
    }
}