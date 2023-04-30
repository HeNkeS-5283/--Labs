using System.Text;
using System.Text.RegularExpressions;
using System;
using System.IO;

namespace Lab4_1
{
    class Disc
    {
        private int num;
        private string name;
        private float size;
        private string type;
        private int date;

        public Disc(string str)
        {
            str = str.Trim();
            string[] split = str.Split(new char[] { ';' });

            num = Convert.ToInt32(split[0].Trim());
            name = split[1].Trim();

            if (float.TryParse(split[2], out size)) ;
            else throw new FormatException();

            type = split[3].Trim();
            date = int.Parse(split[4].Trim());

            if (num < 0) throw new FormatException();
            if ((date.ToString().Length) != 4) throw new FormatException();
        }
        public int Num
        {
            get { return num; }
            set { num = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public float Size
        {
            get { return size; }
            set { size = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Date
        {
            get { return date; }
            set { date = value; }
        }
    }

    class Program
    {
        private const string Files = "input.txt";
        public static void Main(String[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "", str_all_inf, act = " ", act1, str_copy, str_p;
            char act_do = ' ';
            int n, i, x, y, max, min;

            Disc[] product = new Disc[30];

            while (act != "")
            {
                try
                {
                    x = 0; i = 0; act1 = " "; str_all_inf = ""; y = 0; str_copy = ""; str_p = "";

                    using (FileStream fs = new FileStream(Files, FileMode.Open))
                    {
                        using (StreamReader sw = new StreamReader(fs, Encoding.Default))
                            while ((str = sw.ReadLine()) != null)
                            {
                                product[i] = new Disc(str);
                                ++i;
                            }
                        n = i;
                    }

                    Console.WriteLine("Вдале підлючення до бази данних, яку дію ви хочете виконати:");
                    Console.WriteLine("a - додати інформацію в базу данних;\nr - редагувати записи;\nd - видалити запис;\ns - вивести записи на екран;\nс - сортування за датою запису;\np - пошук диску за назвою альбому;\nEnter - для виходу;");
                    for (int j = 0; j < n; j++)
                    {
                        str_all_inf += product[j].Num + "; " + product[j].Name + "; " + product[j].Size + "; " + product[j].Type + "; " + product[j].Date + ";\n";
                    }
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
                                        Console.WriteLine("Інвентарний номер; Назва альбому; Об'єм диску; Тип; Дата запису;");
                                        Console.WriteLine("1; SCOOTER \"AND THE BEAT GOES ON\"; 2,6; CD; 1995;\n");
                                        str = Console.ReadLine();

                                        for (int j = 0; j < str.Length; j++) { if (';' == str[j]) x++; }
                                        if (x == 5 && str != "" && str != " ")
                                        {
                                            product[n] = new Disc(str);
                                            using (FileStream fs = new FileStream(Files, FileMode.Create))
                                            {
                                                using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                                                {
                                                    str_all_inf += product[n].Num + "; " + product[n].Name + "; " + product[n].Size + "; " + product[n].Type + "; " + product[n].Date + ";\n";
                                                    writer.Write(str_all_inf);
                                                }
                                                Console.WriteLine("Дані записані правильно, запис збереженний. В меню натисніть любу клавішу.");
                                                Console.ReadKey();
                                            }
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
                                            Console.Write(j + 1 + " - " + product[j].Num + "; " + product[j].Name + "; " + product[j].Size + "; " + product[j].Type + "; " + product[j].Date + ";\n");
                                        }
                                        Console.WriteLine("Виберіть рядок для редагування запису (1-" + n + "):");
                                        str = Console.ReadLine();
                                        if (int.TryParse(str, out x) && x > 0 && x < n + 1)
                                        {
                                            x--;
                                            Console.Clear();
                                            Console.WriteLine("Вибраний рядок:");
                                            Console.Write(product[x].Num + "; " + product[x].Name + "; " + product[x].Size + "; " + product[x].Type + "; " + product[x].Date + ";\n");
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
                                                            product[x].Num = Convert.ToInt32(str);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.WriteLine("Введіть нову інформацію:");
                                                            str = Console.ReadLine();
                                                            product[x].Name = str;
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.WriteLine("Введіть нову інформацію:");
                                                            str = Console.ReadLine();
                                                            product[x].Size = float.Parse(str);
                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            Console.WriteLine("Введіть нову інформацію:");
                                                            str = Console.ReadLine();
                                                            product[x].Type = str;
                                                            break;
                                                        }
                                                    case 5:
                                                        {
                                                            Console.WriteLine("Введіть нову інформацію:");
                                                            str = Console.ReadLine();
                                                            if ((str.Length) == 4) product[x].Date = Convert.ToInt32(str);
                                                            else throw new FormatException();

                                                            break;
                                                        }
                                                    case 0:
                                                        {
                                                            Console.WriteLine("Введіть нову інформацію:");
                                                            str = Console.ReadLine();
                                                            for (int j = 0; j < str.Length; j++) { if (';' == str[j]) y++; }
                                                            if (y == 5 && str != "" && str != " ")
                                                            {
                                                                product[x] = new Disc(str);
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
                                                str_all_inf = "";
                                                for (int j = 0; j < n; j++)
                                                {
                                                    str_all_inf += product[j].Num + "; " + product[j].Name + "; " + product[j].Size + "; " + product[j].Type + "; " + product[j].Date + ";\n";
                                                }
                                                using (FileStream fs = new FileStream(Files, FileMode.Create))
                                                {
                                                    using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                                                    {
                                                        writer.Write(str_all_inf);
                                                    }
                                                    Console.WriteLine("Дані записані правильно, запис збереженний. В меню натисніть любу клавішу.");
                                                    Console.ReadKey();
                                                }
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
                                            Console.Write(j + 1 + " - " + product[j].Num + "; " + product[j].Name + "; " + product[j].Size + "; " + product[j].Type + "; " + product[j].Date + ";\n");
                                        }
                                        Console.WriteLine("Виберіть рядок для редагування запису (1-" + n + "):");
                                        str = Console.ReadLine();
                                        if (int.TryParse(str, out x) && x > 0 && x < n + 1)
                                        {
                                            x--;
                                            str_all_inf = "";
                                            for (int j = 0; j < n; j++)
                                            {
                                                if (j != x) str_all_inf += product[j].Num + "; " + product[j].Name + "; " + product[j].Size + "; " + product[j].Type + "; " + product[j].Date + ";\n";
                                            }
                                            using (FileStream fs = new FileStream(Files, FileMode.Create))
                                            {
                                                using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                                                {
                                                    writer.Write(str_all_inf);
                                                }
                                                Console.WriteLine("Запис видалений. В меню натисніть любу клавішу.");
                                                Console.ReadKey();
                                            }
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
                            case 'c':
                                {
                                    Console.Clear();
                                    Console.WriteLine("Вибрана дія сортування за датою запису!");
                                    Console.WriteLine("Виберіть спосіб сортування:\n1 - сортування за спаданням\n2 - сортування за зростанням");
                                    str = Console.ReadLine();
                                    if (int.TryParse(str, out x) && x > 0 && x < 3)
                                    {
                                        switch (x)
                                        {
                                            case 1:
                                                {
                                                    Console.WriteLine("\nСортування за спаданням:");
                                                    int[] da = new int[n];
                                                    for (int k = 0; k < n; k++)
                                                    {
                                                        da[k] = product[k].Date;
                                                    }
                                                    Array.Sort(da);
                                                    Array.Reverse(da);
                                                    for (int k = 0; k < n; k++)
                                                    {
                                                        for (int j = 0; j < n; j++)
                                                        {
                                                            if (da[k] == product[j].Date)
                                                            {
                                                                Console.Write(product[j].Num + "; " + product[j].Name + "; " + product[j].Size + "; " + product[j].Type + "; " + product[j].Date + ";\n");
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    Console.WriteLine("\nСортування за зростанням:");
                                                    int[] da = new int[n];
                                                    for (int k = 0; k < n; k++)
                                                    {
                                                        da[k] = product[k].Date;
                                                    }
                                                    Array.Sort(da);
                                                    for (int k = 0; k < n; k++)
                                                    {
                                                        for (int j = 0; j < n; j++)
                                                        {
                                                            if (da[k] == product[j].Date)
                                                            {
                                                                Console.Write(product[j].Num + "; " + product[j].Name + "; " + product[j].Size + "; " + product[j].Type + "; " + product[j].Date + ";\n");
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                        }
                                    }
                                    Console.WriteLine("Назад в меню натисніть любий символ.");
                                    Console.ReadKey();
                                    break;
                                }
                            case 'p':
                                {
                                    while (act1 != "")
                                    {
                                        x = 0;
                                        Console.Clear();
                                        Console.WriteLine("Вибрана дія пошук диску за назвою альбому!");
                                        Console.WriteLine("Введіть ціле слово, частину слова, чи букву з назви:");
                                        str = Console.ReadLine();
                                        str = str.Trim();
                                        str = str.ToLower();
                                        if (str != "" && str != " ")
                                        {
                                            for (int j = 0; j < n; j++)
                                            {
                                                str_copy = product[j].Name;
                                                str_copy = str_copy.ToLower();
                                                if (Regex.IsMatch(str_copy, str))
                                                {
                                                    str_p += product[j].Num + "; " + product[j].Name + "; " + product[j].Size + "; " + product[j].Type + "; " + product[j].Date + ";\n";
                                                    x++;
                                                }
                                            }
                                            if (x != 0)
                                            {
                                                Console.WriteLine("Всі записи з схожою назвою:\n");
                                                Console.WriteLine(str_p);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Не знайдено запису з схожою назвою.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Не знайдено запису з схожою назвою.");
                                        }
                                        Console.WriteLine("\nПовторити пошук введіть любий символ. Назад в меню - Enter."); 
                                        act1 = Console.ReadLine(); 
                                    }
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
                Console.Clear();
            }
        }
    }
}