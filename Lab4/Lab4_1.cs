using System.Text;
using System;
using System.IO;

namespace Lab4_1
{
    class Product
    {
        private string mounth;
        private int productPlan;
        private int productDo;
        public Product(string str)
        {
            str = str.Trim();
            string[] split = str.Split(new char[] { ' ' });
            mounth = split[0];
            productPlan = int.Parse(split[1]);
            productDo = int.Parse(split[2]);
            if (productPlan < 0) throw new FormatException();
            if (productDo < 0) throw new FormatException();
        }
        public string Mounth { get { return mounth; } }
        public int ProductPlan { get { return productPlan; } }
        public int ProductDo { get { return productDo; } }

        public void Print()
        {
            Console.WriteLine("| {0} \t|\t {1} \t\t\t|\t {2} \t\t\t|", mounth, productPlan, productDo);
            Console.WriteLine("|---------------|-------------------------------|-------------------------------|");
        }
    }

    class Program
    {
        private const string File = "input.txt";
        public static void Main(String[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            int i = 0;

            Product[] product = new Product[12];
            try
            {
                using (FileStream fs = new FileStream(File, FileMode.Open))
                {
                    using (StreamReader sw = new StreamReader(fs))
                        while ((str = sw.ReadLine()) != null)
                        {
                            product[i] = new Product(str);
                            ++i;
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

            Console.WriteLine("\nТаблиця місяців з недовиконаним планом випуску продукції:\n");
            Console.WriteLine("|---------------|-------------------------------|-------------------------------|");
            Console.WriteLine("| Місяць \t| План випуску продукції \t| Фактичний випуск продукції \t|");
            Console.WriteLine("|---------------|-------------------------------|-------------------------------|");
            for (i = 0; i < product.Length; i++)
            {
                if (product[i].ProductPlan > product[i].ProductDo)
                {
                    product[i].Print();
                }
            }
            Console.ReadKey();
        }
    }
}