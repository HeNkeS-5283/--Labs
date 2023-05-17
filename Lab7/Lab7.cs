using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Product : IComparable, IComparer
    {
        private int inventory_namber;
        private string name;
        private int weight;
        private int price;
        private int num;
        private string quality;
        private int quality_num;

        public Product() { }
        public Product(string str)
        {
            str = str.Trim();
            string[] split = str.Split(new char[] { ';' });
            inventory_namber = int.Parse(split[0]);
            name = split[1].Trim();
            weight = int.Parse(split[2]);
            price = int.Parse(split[3]);
            num = int.Parse(split[4]);
            quality = split[5].Trim();

            if (quality == "high") { quality_num = 3; }
            else if (quality == "middle") { quality_num = 2; }
            else if (quality == "low") { quality_num = 1; }
            else { Console.WriteLine(quality); throw new FormatException(); }

            if (inventory_namber < 0) throw new FormatException();
            if (weight < 0) throw new FormatException();
            if (price < 0) throw new FormatException();
            if (num < 0) throw new FormatException();
           
        }
        public int Inventory_namber { get { return inventory_namber; } }
        public string Name { get { return name; } }
        public int Weight { get { return weight; } }
        public int Price { get { return price; } }
        public int Num { get { return num; } }
        public string Quality { get { return quality; } }
        public int Quality_Num { get { return quality_num; } }

        public int CompareTo(object obj)
        {
            if (weight == (int)obj) { Console.WriteLine("Вага товарів одинакова."); return 0; }
            if (weight > (int)obj) { Console.WriteLine("Вага вибраного товару більша."); return 1; }
            if (weight < (int)obj) { Console.WriteLine("Вага вибраного товару менша."); return 2; }
            else return -1;
        }

        public int Compare(object x, object y)
        {
            if (price == (int)x && quality_num == (int)y) { Console.WriteLine("Ціна і якість одинакові."); return 0; }
            else if (price > (int)x && quality_num == (int)y) { Console.WriteLine("Ціна вибраного товару більша, а якість одинакова."); return 1; }
            else if (price < (int)x && quality_num == (int)y) { Console.WriteLine("Ціна вибраного товару менша, а якість одинакова."); return 2; }
            else if (price == (int)x && quality_num > (int)y) { Console.WriteLine("Ціна одинакова, а якість вибраного товару ліпша від порівнювального товару."); return 3; }
            else if (price == (int)x && quality_num < (int)y) { Console.WriteLine("Ціна одинакова, а якість вибраного товару гірша від порівнювального товару."); return 4; }
            else if (price > (int)x && quality_num > (int)y) { Console.WriteLine("Ціна вибраного товару більша, а якість вибраного товару ліпша від порівнювального товару."); return 5; }
            else if (price < (int)x && quality_num < (int)y) { Console.WriteLine("Ціна вибраного товару менша, а якість вибраного товару гірша від порівнювального товару."); return 6; }
            else if (price > (int)x && quality_num < (int)y) { Console.WriteLine("Ціна вибраного товару більша, а якість вибраного товару гірша від порівнювального товару."); return 7; }
            else if (price < (int)x && quality_num > (int)y) { Console.WriteLine("Ціна вибраного товару менша, а якість вибраного товару ліпша від порівнювального товару."); return 8; }
            else return -1;
        }
    }

    class Prod : IEnumerable<Product>
    {
        private readonly List<Product> products;
        private readonly Comparison<Product> comparison;

        public Prod(IEnumerable<Product> products, Comparison<Product> comparison)
        {
            this.products = new List<Product>(products);
            this.comparison = comparison;
        }
        public IEnumerator<Product> GetEnumerator()
        {
            products.Sort(comparison);
            return products.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
        {

            private const string File = "input.txt";
            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string str = "", str_all_inf = "", act = " ", act1 = " ", str_copy;
                char act_do = ' ';
                int i = 0, n;

                var products = new List<Product>();
                Product[] product = new Product[20];

                while (act != "")
                {
                    i = 0; act1 = " ";
                    try
                    {
                        using (FileStream fs = new FileStream(File, FileMode.Open))
                        {
                            using (StreamReader sw = new StreamReader(fs))
                            while ((str = sw.ReadLine()) != null)
                            {
                                products.Add(new Product(str));
                                product[i] = new Product(str);
                                ++i;
                            }
                        n = i;
                        }

                        Console.Clear();
                        Console.WriteLine("Вдале підлючення до бази данних, яку дію ви хочете виконати:");
                        Console.WriteLine("a - порівняння виробів за вагою;\nb - порівняння виробів за ціною і за якістю;\nc - виведення на консоль списку виробів, впорядкованих за ціною;\nEnter - для виходу;");

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
                                            int x, y, z = 0;
                                            Console.Clear();
                                            Console.WriteLine("Вибрана дія порівняння виробів за вагою!");
                                            for (int j = 0; j < n; j++)
                                            {
                                                Console.Write(j + 1 + " - " + product[j].Inventory_namber + "; " + product[j].Name + "; " + product[j].Weight + "kg ; " + product[j].Price + " $; " + product[j].Num + "; " + product[j].Quality + ";\n");
                                            }
                                            Console.WriteLine("Виберіть виріб який будете порівнювати (1-" + n + "):");
                                            str = Console.ReadLine();
                                            if (int.TryParse(str, out x) && x > 0 && x < n + 1)
                                            {
                                                x--;
                                                Console.WriteLine("Виберіть виріб з яким будете порівнювати (1-" + n + "):");
                                                str = Console.ReadLine();
                                                if (int.TryParse(str, out y) && y > 0 && y < n + 1)
                                                {
                                                    y--;
                                                    product[x].CompareTo(product[y].Weight);
                                                }
                                                else { z = -1; Console.WriteLine("Вибраний не існуючий рядок назад в меню - Enter. Повторити любий символ."); act1 = Console.ReadLine();}
                                            }
                                            else { z = -1; Console.WriteLine("Вибраний не існуючий рядок назад в меню - Enter. Повторити любий символ."); act1 = Console.ReadLine(); }
                                            if (z == 0)
                                            {
                                                Console.WriteLine("\nПовторити порівнення введіть любий символ. Назад в меню - Enter.");
                                                act1 = Console.ReadLine();
                                            }
                                        }
                                        break;
                                    }
                                case 'b':
                                    {
                                        while (act1 != "")
                                        {
                                            int x, y, z = 0;
                                            Console.Clear();
                                            Console.WriteLine("Вибрана дія порівняння виробів за ціною і за якістю!");
                                            for (int j = 0; j < n; j++)
                                            {
                                                Console.Write(j + 1 + " - " + product[j].Inventory_namber + "; " + product[j].Name + "; " + product[j].Weight + " kg; " + product[j].Price + " $; " + product[j].Num + "; " + product[j].Quality + ";\n");
                                            }
                                            Console.WriteLine("Виберіть виріб який будете порівнювати (1-" + n + "):");
                                            str = Console.ReadLine();
                                            if (int.TryParse(str, out x) && x > 0 && x < n + 1)
                                            {
                                                x--;
                                                Console.WriteLine("Виберіть виріб з яким будете порівнювати (1-" + n + "):");
                                                str = Console.ReadLine();
                                                if (int.TryParse(str, out y) && y > 0 && y < n + 1)
                                                {
                                                    y--;
                                                    product[x].Compare(product[y].Price, product[y].Quality_Num);
                                                }
                                                else { z = -1; Console.WriteLine("Вибраний не існуючий рядок назад в меню - Enter. Повторити любий символ."); act1 = Console.ReadLine(); }
                                            }
                                            else { z = -1; Console.WriteLine("Вибраний не існуючий рядок назад в меню - Enter. Повторити любий символ."); act1 = Console.ReadLine(); }
                                            if (z == 0)
                                            {
                                                Console.WriteLine("\nПовторити порівнення введіть любий символ. Назад в меню - Enter.");
                                                act1 = Console.ReadLine();
                                            }
                                        }
                                        break;
                                    }
                                case 'c':
                                {
                                    int x;
                                    Comparison<Product> comparison;
                                    Prod collection = null;
                                    Console.Clear();
                                    Console.WriteLine("Вибрана дія виведення на консоль списку виробів, впорядкованих за ціною!");
                                    Console.WriteLine("Виберіть спосіб сортування:\n1 - сортування за спаданням\n2 - сортування за зростанням");
                                    str = Console.ReadLine();

                                    if (int.TryParse(str, out x) && x > 0 && x < 3)
                                    {
                                        if (x == 1)
                                        {
                                            comparison = (p1, p2) => p2.Price.CompareTo(p1.Price);
                                            
                                            collection = new Prod(products, comparison);

                                            foreach (Product product1 in collection)
                                            {
                                                Console.WriteLine(product1.Inventory_namber + "; " + product1.Name + "; " + product1.Weight + " kg; " + product1.Price + " $; " + product1.Num + "; " + product1.Quality + ";\n");
                                            }
                                        }
                                        else if (x == 2)
                                        {
                                            comparison = (p1, p2) => p1.Price.CompareTo(p2.Price);
                                            
                                            collection = new Prod(products, comparison);

                                            foreach (Product product1 in collection)
                                            {
                                                Console.WriteLine(product1.Inventory_namber + "; " + product1.Name + "; " + product1.Weight + " kg; " + product1.Price + " $; " + product1.Num + "; " + product1.Quality + ";\n");
                                            }
                                        }
                                    }
                                    else { Console.WriteLine("Вибраний неіснуючий тип сортування."); }
                                    
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
}