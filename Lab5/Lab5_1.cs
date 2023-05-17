using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab5_1
{
    public class Conference : MidlPaticipant
    {
        private string name;
        private string place;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Place
        {
            get { return place; }
            set { place = value; }
        }
        

        public override int particip(int[] arr)
        {
            int x = 0, y, n;
            n = arr.Length;

            for (int j = 0; j < n; j++)
            {
                x += arr[j];
            }
            y = x / n;
            return y;
        }
        static public string conv_i(string a)
        {
            char[] word = new char[33];
            word = a.ToCharArray();

            for (int i = 0; i < a.Length; i++)
                if ((int)word[i] == 63) word[i] = 'i';

            string str_out = new string(word);
            return str_out;
        }

        static public int longname(string[] arr)
        {
            string str;
            int x = 0, n;
            n = arr.Length;

            str = arr[0];
            for (int j = 0; j < n; j++)
            {
                if (str.Length < arr[j].Length)
                {
                    str = arr[j];
                    x = j;
                }
            }
            return x;
        }

        static public int longparticipant(int[] arr)
        { 
            int x = 0, n, max;
            n = arr.Length;

            max = arr[0];
            for (int j = 0; j < n; j++)
            {
                if (max < arr[j])
                {
                    max = arr[j];
                    x = j;
                }
            }
            return x;
        }

        private const string Files = "input.txt";
        public static void Main(String[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "", str_all_inf, act = " ", act1, str_copy;
            char act_do = ' ';
            int n, i, x, y, max;

            Meeting[] meet = new Meeting[30];

            while (act != "")
            {
                try
                {
                    x = 0; i = 0; act1 = " "; str_all_inf = ""; y = 0; max = 0; str_copy = "";

                    using (FileStream fs = new FileStream(Files, FileMode.Open))
                    {
                        using (StreamReader sw = new StreamReader(fs, Encoding.Default))
                            while ((str = sw.ReadLine()) != null)
                            {
                                meet[i] = new Meeting(str);
                                ++i;
                            }
                        n = i;
                    }
                    Console.Clear();
                    Console.WriteLine("Вдале підлючення до бази данних, яку дію ви хочете виконати:");
                    Console.WriteLine("a - додати інформацію в базу данних;\nr - редагувати записи;\nd - видалити запис;\ns - вивести записи на екран;\nm - виведення середньої кількості учасників на засіданні;\np - вивести засідання з найбільшою кількістю учасників;\nl - вивести засідання з найбільшою назвою;\nEnter - для виходу;");
                    for (int j = 0; j < n; j++)
                    {
                        str_all_inf += meet[j].Name + "; " + meet[j].Place + "; " + meet[j].Date + "; " + meet[j].Theme + "; " + meet[j].Participant + ";\n";
                    }
                    str_all_inf = conv_i(str_all_inf); 
                    act = Console.ReadLine();

                    if (char.TryParse(act, out act_do))
                    {
                        if (act != "") act_do = char.Parse(act);

                        switch (act_do)
                        {
                            case 'a':
                                {
                                    while (act1 != "")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Вибрана дія додавання інформації!");
                                        Console.WriteLine("Інформація додається за таким зразком:");
                                        Console.WriteLine("Назва конференції; Місце проведення; Дата та час; Тема; Кількість учасників;");
                                        Console.WriteLine("Введення викладачів в освітній процес; Конференц зал; 28.08.2023 13:30:00; \"Введення в освітній процес\"; 54;\n");
                                        str = Console.ReadLine();

                                        for (int j = 0; j < str.Length; j++) { if (';' == str[j]) x++; }
                                        if (x == 5 && str != "" && str != " ")
                                        {
                                            meet[n] = new Meeting(str);
                                            using (FileStream fs = new FileStream(Files, FileMode.Create))
                                            {
                                                using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                                                {
                                                    n++;
                                                    for (int j = 0; j < n; j++)
                                                    {
                                                        str_copy = meet[j].Name + "; " + meet[j].Place + "; " + meet[j].Date + "; " + meet[j].Theme + "; " + meet[j].Participant + ";";
                                                        str_copy = conv_i(str_copy);
                                                        writer.WriteLine(str_copy);
                                                    }
                                                }
                                            }
                                            Console.WriteLine("Дані записані правильно, запис збереженний. В меню натисніть любу клавішу.");
                                            Console.ReadKey();
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Введено недостатьно данних назад в меню - Enter. Повторити любий символ.");
                                            act1 = Console.ReadLine();
                                        }
                                        Console.Clear();
                                    }
                                    break;
                                }
                            case 'r':
                                {
                                    while (act1 != "")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Вибрана дія редагування записів!");
                                        for (int j = 0; j < n; j++)
                                        {
                                            Console.Write(j + 1 + " - " + meet[j].Name + "; " + meet[j].Place + "; " + meet[j].Date + "; " + meet[j].Theme + "; " + meet[j].Participant + ";\n");
                                        }
                                        Console.WriteLine("Виберіть рядок для редагування запису (1-" + n + "):");
                                        str = Console.ReadLine();
                                        if (int.TryParse(str, out x) && x > 0 && x < n + 1)
                                        {
                                            x--;
                                            Console.Clear();
                                            Console.WriteLine("Вибраний рядок:");
                                            Console.Write(meet[x].Name + "; " + meet[x].Place + "; " + meet[x].Date + "; " + meet[x].Theme + "; " + meet[x].Participant + ";\n");
                                            Console.WriteLine("Виберіть інформацію для редагування (1-5) або 0 для перезапису усього рядка:");
                                            str = Console.ReadLine();
                                            if (int.TryParse(str, out i) && i >= 0 && i < 6)
                                            {
                                                switch (i)
                                                {
                                                    case 1:
                                                        {
                                                            Console.WriteLine("Введіть нову інформацію:");
                                                            str = Console.ReadLine();
                                                            meet[x].Name = str;
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.WriteLine("Введіть нову інформацію:");
                                                            str = Console.ReadLine();
                                                            meet[x].Place = str;
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.WriteLine("Введіть нову інформацію:");
                                                            str = Console.ReadLine();
                                                            string[] sp = str.Split(new char[] { ' ' });
                                                            
                                                            if (sp.Length == 2)
                                                            {
                                                                string[] dat = sp[0].Split(new char[] { '.' });
                                                                string[] time = sp[1].Split(new char[] { ':' });
                                                                if (dat[2].Length != 4 && dat[1].Length != 2 && dat[0].Length != 2) throw new FormatException();
                                                                if (time[0].Length != 2 && time[1].Length != 2 && time[2].Length != 2) throw new FormatException();

                                                                meet[x].Date = new DateTime(int.Parse(dat[2]), int.Parse(dat[1]), int.Parse(dat[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                                                            }
                                                            if (sp.Length == 1)
                                                            {
                                                                string[] dat = sp[0].Split(new char[] { '.' });
                                                                if (dat[2].Length != 4) throw new FormatException();
                                                                meet[x].Date = new DateTime(int.Parse(dat[2]), int.Parse(dat[1]), int.Parse(dat[0]));
                                                            }
                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            Console.WriteLine("Введіть нову інформацію:");
                                                            str = Console.ReadLine();
                                                            meet[x].Theme = str;
                                                            break;
                                                        }
                                                    case 5:
                                                        {
                                                            Console.WriteLine("Введіть нову інформацію:");
                                                            str = Console.ReadLine();
                                                            meet[x].Participant = Convert.ToInt32(str);
                                                            break;
                                                        }
                                                    case 0:
                                                        {
                                                            Console.WriteLine("Введіть нову інформацію:");
                                                            str = Console.ReadLine();
                                                            for (int j = 0; j < str.Length; j++) { if (';' == str[j]) y++; }
                                                            if (y == 5 && str != "" && str != " ")
                                                            {
                                                                meet[x] = new Meeting(str);
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Введено недостатьно данних назад в меню - Enter. Повторити любий символ.");
                                                                act1 = Console.ReadLine();
                                                                continue;
                                                            }
                                                            break;
                                                        }
                                                }

                                                using (FileStream fs = new FileStream(Files, FileMode.Create))
                                                {
                                                    using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                                                    {
                                                        for (int j = 0; j < n; j++)
                                                        {
                                                            str_copy = meet[j].Name + "; " + meet[j].Place + "; " + meet[j].Date + "; " + meet[j].Theme + "; " + meet[j].Participant + ";";
                                                            str_copy = conv_i(str_copy);
                                                            writer.WriteLine(str_copy);
                                                        }
                                                    }
                                                }
                                                Console.WriteLine("Дані записані правильно, запис збереженний. В меню натисніть любу клавішу.");
                                                Console.ReadKey();
                                                break;
                                            }
                                            else { Console.WriteLine("Введені неправильні символи назад в меню - Enter. Повторити любий символ."); act1 = Console.ReadLine(); }
                                        }
                                        else { Console.WriteLine("Введені неправильні символи назад в меню - Enter. Повторити любий символ."); act1 = Console.ReadLine(); }
                                    }
                                    break;
                                }
                            case 'd':
                                {
                                    while (act1 != "")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Вибрана дія видалення записів!");
                                        for (int j = 0; j < n; j++)
                                        {
                                            Console.Write(j + 1 + " - " + meet[j].Name + "; " + meet[j].Place + "; " + meet[j].Date + "; " + meet[j].Theme + "; " + meet[j].Participant + ";\n");
                                        }
                                        Console.WriteLine("Виберіть рядок для видалення запису (1-" + n + "):");
                                        str = Console.ReadLine();
                                        if (int.TryParse(str, out x) && x > 0 && x < n + 1)
                                        {
                                            x--;
                                            using (FileStream fs = new FileStream(Files, FileMode.Create))
                                            {
                                                using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                                                {
                                                    for (int j = 0; j < n; j++)
                                                    {
                                                        if (j != x)
                                                        {
                                                            str_copy = meet[j].Name + "; " + meet[j].Place + "; " + meet[j].Date + "; " + meet[j].Theme + "; " + meet[j].Participant + ";";
                                                            str_copy = conv_i(str_copy);
                                                            writer.WriteLine(str_copy);
                                                        }
                                                    }
                                                }
                                            }
                                            Console.WriteLine("Запис видалений. В меню натисніть любу клавішу.");
                                            Console.ReadKey();
                                            break;
                                        }
                                        else { Console.WriteLine("Вибраний не існуючий рядок назад в меню - Enter. Повторити любий символ."); act1 = Console.ReadLine(); }
                                    }
                                    break;
                                }
                            case 's':
                                {
                                    Console.Clear();
                                    Console.WriteLine("Вибрана дія виводу записів!");
                                    Console.WriteLine(str_all_inf);
                                    Console.WriteLine("Назад в меню натисніть любий символ.");
                                    Console.ReadKey();
                                    break;
                                }
                            case 'm':
                                {
                                    int[] arri = new int[n];
                                    for (int j = 0; j < n; j++)
                                    {
                                        arri[j] = meet[j].Participant;
                                    }
                                    y = meet[0].particip(arri);

                                    Console.Clear();
                                    Console.WriteLine("Середня кількість учаників на засіданнях: " + y);
                                    Console.WriteLine("Назад в меню натисніть любий символ.");
                                    Console.ReadKey();
                                    break;
                                }
                            case 'p':
                                {
                                    int[] arri = new int[n];
                                    for (int j = 0; j < n; j++)
                                    {
                                        arri[j] = meet[j].Participant;
                                    }
                                    x = longparticipant(arri);

                                    Console.Clear();
                                    Console.WriteLine("Засідання з найбільшою кількістю учасників:");
                                    Console.WriteLine(meet[x].Name + "; " + meet[x].Place + "; " + meet[x].Date + "; " + meet[x].Theme + "; " + meet[x].Participant + ";");
                                    Console.WriteLine("Назад в меню натисніть любий символ.");
                                    Console.ReadKey();
                                    break;
                                }
                            case 'l':
                                {
                                    string[] arrs = new string[n];
                                    for (int j = 0; j < n; j++)
                                    {
                                        arrs[j] = meet[j].Name;
                                    }
                                    x = longname(arrs);

                                    Console.Clear();
                                    Console.WriteLine("Засідання з найбільшою назвою:");
                                    Console.WriteLine(meet[x].Name + "; " + meet[x].Place + "; " + meet[x].Date + "; " + meet[x].Theme + "; " + meet[x].Participant + ";");
                                    Console.WriteLine("Назад в меню натисніть любий символ.");
                                    Console.ReadKey();
                                    break;
                                }
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введні не коректні значення, перевірте файл на правильність данних!");
                    Console.ReadKey();
                    return;
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Перевірте правильність імені і шляху до файлу!");
                    Console.ReadKey();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка: " + ex.Message);
                    Console.ReadKey();
                    return;
                }
            }
        }
    }
        class Meeting : Conference
        {
            private DateTime date;
            private string theme;
            private int participant;

            public Meeting(string str)
            {
                str = str.Trim();
                string[] split = str.Split(new char[] { ';' });

                Name = split[0].Trim();
                Place = split[1].Trim();
                theme = split[3].Trim();
                participant = int.Parse(split[4].Trim());


                string[] sp = split[2].Split(new char[] { ' ' });
                
                if (sp.Length == 3) {
                    string[] dat = sp[1].Split(new char[] { '.' });
                    string[] time = sp[2].Split(new char[] { ':' });
                    if (dat[2].Length != 4 && dat[1].Length != 2 && dat[0].Length != 2) throw new FormatException();
                    if (time[0].Length != 2 && time[1].Length != 2 && time[2].Length != 2) throw new FormatException();

                    date = new DateTime(int.Parse(dat[2]), int.Parse(dat[1]), int.Parse(dat[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                }
                if (sp.Length == 2)
                {
                    string[] dat = sp[1].Split(new char[] { '.' });
                    if (dat[2].Length != 4) throw new FormatException();
                    date = new DateTime(int.Parse(dat[2]), int.Parse(dat[1]), int.Parse(dat[0]));
                }
            }

            public DateTime Date
            {
                get { return date; }
                set { date = value; }
            }
            public string Theme
            {
                get { return theme; }
                set { theme = value; }
            }
            public int Participant
            {
                get { return participant; }
                set { participant = value; }
            }
        }

        public abstract class MidlPaticipant
        {
            public abstract int particip(int[] arr);
        }

}
