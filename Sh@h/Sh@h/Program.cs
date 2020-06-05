using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sh_h
{
    class Program
    {
        static void Main(string[] args)
        {



            int[,] pole2 = new int[8, 8];
            char[,] pole = new char[8, 8]
              { { 'L', 'H', 'E', 'K', 'F', 'E', 'H', 'L' },
                { 'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { 'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p' },
                { 'L', 'H', 'E', 'K', 'F', 'E', 'H', 'L'} };
            pole2 = Paint.Pole(pole, pole2);
            Console.SetCursorPosition(15, 0);
            Console.WriteLine("Enter-выбор фигуры");
            Console.SetCursorPosition(15, 1);
            Console.WriteLine("пробел-поставить фигуру в выбранное место");
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                Logik.Figure_choice(keyInfo, pole, pole2);
            }

        }
    }
}

