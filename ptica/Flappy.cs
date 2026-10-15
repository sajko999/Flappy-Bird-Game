using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ptica
{
    class Flappy
    {
        public int Sirina { get; set; } 
        public int Visina { get; set; }
        Prozor prozor;
        Ptica ptica;
        Zid zid1;
        Zid zid2;
        Zid zid3;
        int score = 0;
        public Flappy(int sirina, int visina)
        {
            Visina = visina;
            Sirina = sirina;
            
        }
        void Setup()
        {
            prozor = new Prozor(Sirina, Visina);
            ptica = new Ptica(Visina, Visina / 2);
            zid1 = new Zid(35, Sirina, Visina);
            zid2 = new Zid(60, Sirina, Visina);
            zid3 = new Zid(85, Sirina, Visina);
            score = 0;
            prozor.Ispisi();
            Console.SetCursorPosition((Sirina / 2) - 4, Visina + 2);
            Console.Write("Score:");
            ptica.Ispis();
            zid1.KretanjeZida();
            zid2.KretanjeZida();
            zid3.KretanjeZida();
        }
        public void Pokreni()
        {
            while (true)
            {
                Console.Clear();
                Setup();
                
                Console.ReadKey(true);
                while (ptica.Y < Visina && ptica.Y > 1)
                {
                    if (((ptica.X >= zid1.X - 2 && ptica.X <= zid1.X + 2) && (ptica.Y <= zid1.Y-1 || ptica.Y >= zid1.Y+ 2))
                        || ((ptica.X >= zid2.X - 2 && ptica.X <= zid2.X + 2) && (ptica.Y <= zid2.Y - 1 || ptica.Y >= zid2.Y + 2))
                        || ((ptica.X >= zid3.X - 2 && ptica.X <= zid3.X + 2) && (ptica.Y <= zid3.Y - 1 || ptica.Y >= zid3.Y + 2)))
                    {
                        Console.Beep();
                        break;
                    }
                    if(zid1.X==ptica.X || zid2.X == ptica.X || zid3.X == ptica.X)
                    {
                        score++;
                    }
                    ptica.Logika();
                    zid1.KretanjeZida();
                    zid2.KretanjeZida();
                    zid3.KretanjeZida();
                    Console.SetCursorPosition((Sirina / 2) +3, Visina + 2);
                    Console.Write(score);
                    Thread.Sleep(300);
                    
                }
            }
        }
    }
    class Zid
    {
        public int X { get; set; }
        public int Y { get; set; }
        Random rand;
        int prozorSirina;
        int prozorVisina;

        public Zid(int x, int prozorSirina, int prozorVisina)
        {
            this.prozorSirina = prozorSirina;
            this.prozorVisina = prozorVisina;
            rand = new Random();
            X = x;
            Y = rand.Next(3, prozorVisina - 2);
            Thread.Sleep(10);
        }
        public void KretanjeZida()
        {
            Ispisi(" ");
            X--;
            Ispisi();
            if (X - 2 <= 0)
            {
                X = 75;
                Y = rand.Next(3,prozorVisina-2);
            }
        }
        void Ispisi()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (X - 2 >= 1 && X + 2 < prozorSirina - 1)
            {
                for(int i = 1; i < Y - 2; i++)
                {
                    Console.SetCursorPosition(X-2,i);
                    Console.Write("│");
                    Console.SetCursorPosition(X+2,i);
                    Console.Write("│");
                }
                for (int i = prozorVisina; i > Y + 2; i--)
                {
                    Console.SetCursorPosition(X - 2, i);
                    Console.Write("│");
                    Console.SetCursorPosition(X + 2, i);
                    Console.Write("│");
                }
                for (int i = X-1; i < X + 2; i++)
                {
                    Console.SetCursorPosition(i, Y+2);
                    Console.Write("─");
                    Console.SetCursorPosition(i, Y-2);
                    Console.Write("─");
                }
                Console.SetCursorPosition(X+2, Y - 2);
                Console.Write("┘");
                Console.SetCursorPosition(X-2, Y - 2);
                Console.Write("└");
                Console.SetCursorPosition(X+2, Y + 2);
                Console.Write("┐");
                Console.SetCursorPosition(X-2, Y + 2);
                Console.Write("┌");
            }
            
            Console.ForegroundColor = ConsoleColor.White;
        }
        void Ispisi(string str)
        {
            if (X - 2 >= 1 && X + 2 < prozorSirina - 1)
            {
                for (int i = 1; i < Y - 2; i++)
                {
                    Console.SetCursorPosition(X - 2, i);
                    Console.Write(str);
                    Console.SetCursorPosition(X + 2, i);
                    Console.Write(str);
                }
                for (int i = prozorVisina; i > Y + 2; i--)
                {
                    Console.SetCursorPosition(X - 2, i);
                    Console.Write(str);
                    Console.SetCursorPosition(X + 2, i);
                    Console.Write(str);
                }
                for (int i = X - 1; i < X + 2; i++)
                {
                    Console.SetCursorPosition(i, Y + 2);
                    Console.Write(str);
                    Console.SetCursorPosition(i, Y - 2);
                    Console.Write(str);
                }
                Console.SetCursorPosition(X + 2, Y - 2);
                Console.Write(str);
                Console.SetCursorPosition(X - 2, Y - 2);
                Console.Write(str);
                Console.SetCursorPosition(X + 2, Y + 2);
                Console.Write(str);
                Console.SetCursorPosition(X - 2, Y + 2);
                Console.Write(str);
            }
        }
    }
    class Ptica
    {
       public int X { get; set; }
       public int Y { get; set; }
            
        ConsoleKeyInfo keyinfo;
        ConsoleKey consolekey;

        public Ptica(int x,int y)
        {
            X = x;
            Y = y;
            keyinfo = new ConsoleKeyInfo();
            consolekey = new ConsoleKey();
        }
        void Input()
        {
            if (Console.KeyAvailable)
            {
                keyinfo = Console.ReadKey(true);
                consolekey = keyinfo.Key;
            }
        }
        public void Logika()
        {
            Input();
            if (consolekey == ConsoleKey.Spacebar)
            {
                Gore();
            }
            else
            {
                Dole();
            }
            consolekey = ConsoleKey.A;
        }
        void Gore()
        {
            Ispis(" ");
            Y--;
            Ispis();
        }
        void Dole()
        {
            Ispis(" ");
            Y++;
            Ispis();
        }
        public void Ispis()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(X,Y-1);
            Console.Write("▄");
            Console.SetCursorPosition(X-1,Y-1);
            Console.Write("▄");
            Console.SetCursorPosition(X-1,Y);
            Console.Write("▀");
            Console.SetCursorPosition(X,Y);
            Console.Write("▀");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Ispis(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(X, Y - 1);
            Console.Write(str);
            Console.SetCursorPosition(X - 1, Y - 1);
            Console.Write(str);
            Console.SetCursorPosition(X - 1, Y);
            Console.Write(str);
            Console.SetCursorPosition(X, Y);
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public class Prozor
    {
        public int Visina { get; set; }
        public int Sirina { get; set; }
        public Prozor()
        {
            Visina = 20;
            Sirina = 80;
        }
        public Prozor(int sirina, int visina)
        {
            Sirina = sirina;
            Visina = visina;
        }
        public void Ispisi()
        {
            for (int i = 1; i <= Sirina; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("─");
            }
            for (int i = 1; i <= Sirina; i++)
            {
                Console.SetCursorPosition(i, Visina + 1);
                Console.Write("─");
            }
            for (int i = 1; i <= Visina; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("│");
            }
            for (int i = 1; i <= Visina; i++)
            {
                Console.SetCursorPosition(Sirina+1, i);
                Console.Write("│");
            }
            Console.SetCursorPosition(0, 0);
            Console.Write("┌");
            Console.SetCursorPosition(Sirina + 1, 0);
            Console.Write("┐");
            Console.SetCursorPosition(0, Visina + 1);
            Console.Write("└");
            Console.SetCursorPosition(Sirina + 1, Visina + 1);
            Console.Write("┘");
        }
    }
}
