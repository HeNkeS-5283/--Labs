namespace Lab2_1
{
    public class Lab2_1
    {
        static void Main(string[] args)
        {
            Console.Write("\nВведiть номер маршруту трамваю який вас цiкавить (1-9): ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("\nЗупинки маршруту №" + a);
            switch (a) {
                case 1: Console.WriteLine("Початкова зупинка: Держунiверситет.\nКiнцева зупинка: Училище №15.");break;
                case 2: Console.WriteLine("Початкова зупинка: Держунiверситет.\nКiнцева зупинка: Завод \"Гравiтон\"."); break;
                case 3: Console.WriteLine("Початкова зупинка: Дрiжзавод.\nКiнцева зупинка: Училище №15."); break;
                case 4: Console.WriteLine("Початкова зупинка: Музей народної архiтектури та побуту.\nКiнцева зупинка: Держунiверситет."); break;
                case 5: Console.WriteLine("Початкова зупинка: Калинiвський ринок.\nКiнцева зупинка: вул. Пiвденно-Кiльцева."); break;
                case 6: Console.WriteLine("Початкова зупинка: пл. Соборна.\nКiнцева зупинка: Училище №15."); break;
                case 7: Console.WriteLine("Початкова зупинка: Училище №15.\nКiнцева зупинка: вул. Степана Бандери."); break;
                case 8: Console.WriteLine("Початкова зупинка: Держунiверситет.\nКiнцева зупинка: вул. Пiвденно-Кiльцева."); break;
                case 9: Console.WriteLine("Початкова зупинка: вул. Степана Бандери.\nКiнцева зупинка: вул. Пiвденно-Кiльцева."); break;
                default: Console.WriteLine("Введений не iснуючий маршрут!");break;
            } 
        }
    }
}