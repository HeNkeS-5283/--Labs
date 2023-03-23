namespace Lab2_2_A
{
    public class Lab2_2_A
    {
        static void Main(string[] args)
        {
            double x = 0.5f, y = 0;
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("|\t\t\t|\t\t\t|");
            Console.WriteLine("|\t   x\t\t|\t  y=f(x)\t|");
            Console.WriteLine("|_______________________|_______________________|");

            while (x <= 4.5f)
            {
                y = Math.Log10(x);

                Console.WriteLine("|\t  " + Math.Round(x, 1) + "\t\t|\t  " + Math.Round(y, 2) + "\t\t|");
                Console.WriteLine("|_______________________|_______________________|");

                x += 0.4f;
            }
        }
    }
}