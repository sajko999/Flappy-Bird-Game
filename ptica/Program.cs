using System;

namespace ptica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Flappy flappy = new Flappy(75,20);
            flappy.Pokreni();
            Console.ReadKey();

        }
    }
}
