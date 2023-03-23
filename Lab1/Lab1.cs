namespace Lab1
{

    public class Lab1
    {
        static public int Example_V(int a, int b, int c)
        {
            int V = a * b * c;
            return V;
        }
        static public int Example_S(int a, int b, int c)
        {
            int P = (a + b) * 2;
            int S1 = c * P;
            int S2 = a * b;
            int S = S1 + 2 * S2;
            return S;
        }
        static void Main(string[] args)
        {
            int a, b, c, V, S;
            Console.WriteLine("Введiть довжину ребр прямокутного паралелепiпеда a, b, c:");
            Console.Write("a = ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b = ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.Write("c = ");
            c = Convert.ToInt32(Console.ReadLine());

            S = Example_S(a, b, c);
            V = Example_V(a, b, c);

            Console.WriteLine("\nОб'єм паралелепiпеда: V = " + V);
            Console.WriteLine("Площа поверхнi паралелепiпеда: S = " + S);
        }
    }
}