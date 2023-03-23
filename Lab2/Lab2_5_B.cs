namespace Lab2_5_B
{
    class Lab2_5_B
    {
        static public int Sum_m_max(int[,] x, int n, int m)
        {
            int sum = 0, max;
            for (int j = 0; j < m; j++)
            {
                max = x[j, 0];
                for (int i = 0; i < n; i++)
                {
                    if (max < x[j, i]) max = x[j, i];
                }
                sum += max;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int n, m;
            string buf;
            Console.Write("Введiть кiлькiсть стовпчикiв масиву: n = ");
            buf = Console.ReadLine();
            if (!int.TryParse(buf, out n))
            {
                Console.WriteLine("Введенi не коректнi данi.");
                Environment.Exit(0);
            }

            Console.Write("Введiть кiлькiсть рядкiв масиву: m = ");
            buf = Console.ReadLine();
            if (!int.TryParse(buf, out m))
            {
                Console.WriteLine("Введенi не коректнi данi.");
                Environment.Exit(0);
            }

            int[,] A = new int[m, n];
            Random random = new Random();
            int min = -100, max = 100;
            for (int j = 0; j < m; j++)
                for (int i = 0; i < n; i++)
                {
                    A[j, i] = random.Next(min, max);  
                }
            Console.Clear();
            Console.Write($"Згенерований масив {n}x{m}\n A = ");
            for (int j = 0; j < m; j++)
            {
                Console.Write("\t{");
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"\t{A[j, i]}, ");
                }
                Console.Write("\t}\n");
            }

            int sum = Sum_m_max(A, n, m);
            Console.WriteLine("\nCума найбiльших елементiв рядкiв масиву: " + sum);
        }
    }
}