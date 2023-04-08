using System.Text.RegularExpressions;

namespace Lab3_1
{
    class Lab3_1
    {
        static public string conv_i(string a)
        {
            char[] word = new char[33];
            word = a.ToCharArray();

            for (int i = 0; i < a.Length; i++)
                if ((int)word[i] == 63) word[i] = 'i';

            string str_out = new string(word);
            return str_out;
        }
        static void Main(String[] args)
        {
            string str1, str2 = "", end;
            char[] word = new char[33];
            bool engls = false;
            Regex pattern = new Regex("^[a-zA-Z]*$", RegexOptions.Compiled); //перевірка чи рядок має англійські символи

            do {
                Console.WriteLine("Задайте рядок:");
                str1 = Console.ReadLine();
                string[] split = str1.Split(new Char[] { ' ', ',', '.' }); //відокремлення слів
                for (int i = 0; i < split.Length; i++)
                {
                    word = split[i].ToCharArray();
                    for (int j = 0; j < split[i].Length; j++)
                    {
                        if (pattern.IsMatch(word[j].ToString())) //виклик перевірки
                        {
                            engls = false;
                            break;
                        }
                        else engls = true;
                    }
                    if (engls)
                    {
                        split[i] = conv_i(split[i]);
                        str2 += split[i] + " ";
                    }
                    Array.Clear(word);
                }
                Console.WriteLine("\nРядок з видалиними словами, якi мiстять хоча б одну латинську лiтеру:\n" + str2);
                str2 = Regex.Replace(str2, @"[\d]", string.Empty); //Заміна в рядку по патерну на пустий рядок
                Console.WriteLine("\nРядок з видалиними числа з тексту:\n" + str2);
                if(str2.Length != 0) 
                { 
                str2 = str2.Replace(str2, string.Empty);
                }
                Console.WriteLine("\nЗакiнчити роботу програми введiть exit, повторити натиснiть enter.");
                end = Console.ReadLine();
            } while (end != "exit");
        } 
    }
}