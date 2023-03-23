namespace Lab2_3_A
{
    public class Lab2_3_A
    {
        static public int Find_Max(int[] a)
        {
            return a.Max();
        }
        static public int Find_Sum(int n, int[] a) 
        {
            int sum = 0, end = n - 1;
            for (int i = n - 1; i >= 0; i--)
            {
                if (a[i] == 0)
                {
                    end = i;
                    break;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (a[i] == 0)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        sum += Math.Abs(a[j]);
                       if (j == end) break;
                    }
                    break;
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int n;
            string buf;
            Console.Write("Введiть розмiрнiсть масиву n: ");
            buf = Console.ReadLine();
            if (!int.TryParse(buf, out n))
            {
                Console.WriteLine("Введенi не коректнi данi.");
                Environment.Exit(0);
            }

            int[] a = new int[n];

            Console.Write("\nВвести цiлi числа для масиву:\n");
            for (int i = 0; i < n; i++)
            {
                Console.Write("a[{0}] = ", i);
                buf = Console.ReadLine();
                if (!int.TryParse(buf, out a[i]))
                {
                    Console.WriteLine("Введенi не коректнi данi.");
                    Environment.Exit(0);
                }
            }
            Console.Clear();

            Console.WriteLine("\nЗаданий масив: ");
            Console.Write("a = { ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + ", ");
            }
            Console.WriteLine("}");

            int max = Find_Max(a);
            int s = Find_Sum(n, a);
            Console.WriteLine("\nМаксимальний елемент масива: " + max);
            Console.WriteLine("Сума модулiв елементiв масиву, розташованих мiж першим й останнiм нульовими елементами: " + s);
        }
    }
}