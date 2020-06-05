using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sh_h
{
    public static class Logik
    {
        //public static char[,] damage_pole = new char[8, 8]
        //    { { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        //        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        //        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        //        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        //        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        //        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        //        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        //        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '} };
        public static bool Shah = false;
        public static bool Mat = false;
        public static int x = 5, y = 5;
        public static int[] RX = new int[16] { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7 };
        public static int[] RY = new int[16] { 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7 };
        public static int[] BX = new int[16] { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7 };
        public static int[] BY = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 };
        public static int X = -1, Y = -1;
        public static int user = 1;
        public static int nomer = 0;
        public static char figyra = ' ';
        public static void Figure_choice(ConsoleKeyInfo keyInfo, char[,] pole, int[,] pole2)
        {
            if (user == 0)
            {
                Console.SetCursorPosition(15, 2);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Ходит  второй  игрок");
                if (Shah == true)
                {
                    Console.SetCursorPosition(15, 3);
                    Console.WriteLine("Шах королю");
                }
            }
            if (user == 1)
            {
                Console.SetCursorPosition(15, 2);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Ходит первый игрок");
                if (Shah==true)
                {
                    Console.SetCursorPosition(15, 3);
                    Console.WriteLine("Шах королю");
                }
            }

            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (x + 1 <= 9)
                {
                    x++;
                    Console.SetCursorPosition(x, y);
                }
            }
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (y - 1 >= 2)
                {
                    y--;
                    Console.SetCursorPosition(x, y);
                }
            }
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (x - 1 >= 2)
                {
                    x--;
                    Console.SetCursorPosition(x, y);
                }
            }
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (y + 1 <= 9)
                {
                    y++;
                    Console.SetCursorPosition(x, y);
                }
            }
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                if (figyra == ' ')
                {
                    X = x - 2;
                    Y = y - 2;
                    if (user == 1)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            if (X == RX[i] && RY[i] == Y)
                            {
                                Console.SetCursorPosition(x, y);
                                figyra = pole[Y, X];
                                if (pole2[y - 2, x - 2] == 0)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.Write(' ');
                                }
                                if (pole2[y - 2, x - 2] == 1)
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Write(' ');
                                }
                                Console.SetCursorPosition(15, 5);
                                Console.WriteLine("выбрана фигура:" + figyra);
                                nomer = i;

                            }
                        }
                    }
                    if (user == 0)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            if (X == BX[i] && BY[i] == Y)
                            {
                                Console.SetCursorPosition(x, y);
                                figyra = pole[Y, X];
                                if (pole2[y - 2, x - 2] == 0)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.Write(' ');
                                }
                                if (pole2[y - 2, x - 2] == 1)
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Write(' ');
                                }
                                Console.SetCursorPosition(15, 5);
                                Console.WriteLine("выбрана фигура:" + figyra);
                                nomer = i;

                            }
                        }
                    }
                }
                else
                {
                    bool proverka;
                    if (X != -1 && Y != -1)
                    {
                        if (X != x - 2 || Y != y - 2)
                        {
                            proverka = Figura(pole, X, Y, user);
                            Console.SetCursorPosition(x, y);
                            if (user == 1)
                            {
                                for (int i = 0; i < 16; i++)
                                {
                                    if (pole[y - 2, x - 2] == pole[RY[i], RX[i]])
                                    {
                                        proverka = false;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < 16; i++)
                                {
                                    if (pole[y - 2, x - 2] == pole[BY[i], BX[i]])
                                    {
                                        proverka = false;
                                    }
                                }
                            }
                            if (proverka != false)
                            {
                                
                                if (user == 1)
                                {
                                    if (pole2[y - 2, x - 2] == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.BackgroundColor = ConsoleColor.White;
                                        Console.Write(pole[Y, X]);
                                        pole[y - 2, x - 2] = pole[Y, X];
                                        pole[Y, X] = ' ';
                                        X = -1; Y = -1;
                                        RX[nomer] = x - 2;
                                        RY[nomer] = y - 2;
                                        nomer = 0;
                                    }
                                    if (pole2[y - 2, x - 2] == 1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Write(pole[Y, X]);
                                        pole[y - 2, x - 2] = pole[Y, X];
                                        pole[Y, X] = ' ';
                                        X = -1; Y = -1;
                                        RX[nomer] = x - 2;
                                        RY[nomer] = y - 2;
                                        nomer = 0;
                                    }
                                    user = 0;
                                }
                                else
                                {
                                    if (pole2[y - 2, x - 2] == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.BackgroundColor = ConsoleColor.White;
                                        Console.Write(pole[Y, X]);
                                        pole[y - 2, x - 2] = pole[Y, X];
                                        pole[Y, X] = ' ';
                                        X = -1; Y = -1;
                                        BX[nomer] = x - 2;
                                        BY[nomer] = y - 2;
                                        nomer = 0;
                                    }
                                    if (pole2[y - 2, x - 2] == 1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Write(pole[Y, X]);
                                        pole[y - 2, x - 2] = pole[Y, X];
                                        pole[Y, X] = ' ';
                                        X = -1; Y = -1;
                                        BX[nomer] = x - 2;
                                        BY[nomer] = y - 2;
                                        nomer = 0;
                                    }
                                    
                                    if (user == 1)
                                    {
                                        for (int i = 0; i < 16; i++)
                                        {
                                            for (int j = 0; j < 16; j++)
                                            {
                                                if (RX[i] == BX[j] && RY[i] == BY[j])
                                                {
                                                    BX[j] = -1;
                                                    BY[j] = -1;
                                                }
                                            }
                                        }
                                    }
                                    if (user == 0)
                                    {
                                        for (int i = 0; i < 16; i++)
                                        {
                                            for (int j = 0; j < 16; j++)
                                            {
                                                if (BX[i] == RX[j] && BY[i] == RY[j])
                                                {
                                                    RX[j] = -1;
                                                    RY[j] = -1;
                                                }
                                            }
                                        }
                                    }



                                    user = 1;

                                }
                            }

                        }
                        else
                        {
                            Console.SetCursorPosition(x, y);
                            if (user == 1)
                            {
                                if (pole2[y - 2, x - 2] == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.BackgroundColor = ConsoleColor.White;
                                    pole[Y, X] = figyra;
                                    Console.Write(pole[Y, X]);



                                }
                                if (pole2[y - 2, x - 2] == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    pole[Y, X] = figyra;
                                    Console.Write(pole[Y, X]);

                                }

                            }
                            else
                            {
                                if (pole2[y - 2, x - 2] == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.BackgroundColor = ConsoleColor.White;
                                    pole[Y, X] = figyra;
                                    Console.Write(pole[Y, X]);


                                }
                                if (pole2[y - 2, x - 2] == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    pole[Y, X] = figyra;
                                    Console.Write(pole[Y, X]);

                                }

                            }
                        }
                        figyra = ' ';
                    }
                    else
                    {
                        Console.SetCursorPosition(12, 4);
                        Console.WriteLine("вы не выбрали фигуру");
                    }
                }
            }
        }

        public static bool Figura(char[,] pole, int X, int Y, int user)
        {
            Console.SetCursorPosition(x, y);
            switch (pole[Y, X])
            {
                case 'p':
                    
                    if (Math.Abs(Y - y + 2) == 1 && Math.Abs(X - x + 2) == 0 && (pole[y - 2, x - 2] == ' '|| pole[y - 2, x - 2] == '*'))
                    {
                        return true;
                    }
                    
                    if (Math.Abs(Y - y + 2) == 1 && Math.Abs(X - x + 2) == 1 && pole[y - 2, x - 2] != ' ')
                    {
                        if (user == 1)
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                if (x - 2 == BX[i] && y - 2 == BY[i])
                                {
                                    if(pole[y-2, x-2]=='K')
                                    {
                                        Shah=true;
                                    }
                                    return true;
                                }

                            }
                            return false;
                        }
                        else
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                if (x - 2 == RX[i] && y - 2 == RY[i])
                                {
                                    if (pole[y-2, x - 2] == 'K')
                                    {
                                        Shah = true;
                                    }
                                    return true;
                                }

                            }
                            return false;
                        }
                    }
                                      
                    if (Math.Abs(Y - y + 2) > 2 || Math.Abs(X - x + 2) != 0 || pole[y - 2, x - 2] != ' ')
                    {
                        Console.SetCursorPosition(12, 4);
                        Console.WriteLine("вы не можете сделать такой ход");
                        return false;
                    }
                    else
                    {
                        if (Math.Abs(Y - y + 2) == 2 && X <= 7 && Y == 1 || Y == 6 && Math.Abs(X - x + 2) == 0 && (pole[y - 2, x - 2] == ' '|| pole[y - 2, x - 2] == '*'))
                        {

                            return true;
                        }
                    }
                   ; break;

                case 'L':
                    if ((y - 2 - Y) == 0)
                    {
                        return true;
                    }
                    else
                    {
                        if ((x - 2 - X) != 0 && ((y - 2 - Y) != 0))
                        {
                            Console.SetCursorPosition(12, 4);
                            Console.WriteLine("вы не можете сделать такой ход");
                            return false;
                        }
                    }
                    if ((x - 2 - X) == 0)
                    {
                        while(Y==' ')
                        {

                        }
                        return true;
                    }
                    else
                    {
                        if ((y - 2 - Y) >= -7 || (y - 2 - Y) >= 7 && (x - 2 - X) != 0 || pole[y - 2, x - 2] != ' ')
                        {
                            Console.SetCursorPosition(12, 2);
                            Console.WriteLine("вы не можете сделать такой ход");
                            return false;
                        }
                    }
                        ; break;
                case 'K':
                    if ((x - 2 - X) <= 1 && (x - 2 - X) >= -1 && (y - 2 - Y) <= 1 && (y - 2 - Y) >= -1)
                    {
                        return true;
                    }
                    if ((x - 2 - X) > 1 || (x - 2 - X) < -1 || (y - 2 - Y) > 1 || (y - 2 - Y) < -1)
                    {
                        Console.SetCursorPosition(12, 2);
                        Console.WriteLine("вы не можете сделать такой ход");
                        return false;
                    }
                    ; break;
                case 'H':
                    if ((Math.Abs(y - 2 - Y) == 1 && Math.Abs(x - 2 - X) == 2) || (Math.Abs(y - 2 - Y) == 2 && Math.Abs(x - 2 - X) == 1))
                    {
                        return true;
                    }
                    else
                    {
                        Console.SetCursorPosition(12, 2);
                        Console.WriteLine("вы не можете сделать такой ход");
                        return false;
                    }
                case 'E':
                    if (Math.Abs(y - 2 - Y) == Math.Abs(x - 2 - X))
                    {

                        return true;
                    }
                    else
                    {
                        Console.SetCursorPosition(12, 4);
                        Console.WriteLine("вы не можете сделать такой ход");
                        return false;
                    }
                case 'F':
                    if (Math.Abs(y - 2 - Y) == Math.Abs(x - 2 - X))
                    {
                        Console.SetCursorPosition(12, 4);
                        Console.WriteLine("1");
                        return true;
                    }
                    else
                        if ((x - 2 - X) == 0) 
                    {
                        Console.SetCursorPosition(12, 4);
                        Console.WriteLine("2");

                        return true;
                    }
                    if (X < x)
                    {



                        return true;
                    }
                    else
                    if ((y - 2 - Y) == 0)
                    {

                        return true;
                    }
                    else
                    {
                        Console.SetCursorPosition(12, 2);
                        Console.WriteLine("вы не можете сделать такой ход");
                        return false;
                    }
            }
            return false;
        }
        //public static int Shah(char[,] pole)
        //{
        //    if (user == 1)//заполнение Rdamage
        //    {
        //        for (int i = 0; i < 16; i++)
        //        {
        //            int r = i;
        //            int r2 = r;
        //            int j = i;
        //            switch (damage_pole[RY[i], RX[i]])
        //            {
        //                case 'p':
        //                    try
        //                    {
        //                        if (damage_pole[RY[r] - 1, RX[r] - 1] == ' ' || damage_pole[RY[r] - 1, RX[r] - 1] == 'K')
        //                        {
        //                            damage_pole[RY[r] - 1, RX[r] - 1] = '*';

        //                        }
        //                    }
        //                    catch
        //                    {
        //                        try
        //                        {
        //                            if (damage_pole[RY[r] + 1, RX[r] - 1] == ' ' || damage_pole[RY[r] - 1, RX[r] + 1] == 'K')
        //                            {
        //                                damage_pole[RY[r] + 1, RX[r] - 1] = '*';
        //                            }
        //                        }
        //                        catch {  }
        //                    }
        //                    try
        //                    {
        //                        if (damage_pole[RY[r] + 1, RX[r] - 1] == ' ' || damage_pole[RY[r] - 1, RX[r] + 1] == 'K')
        //                        {
        //                            damage_pole[RY[r] + 1, RX[r] - 1] = '*';
        //                        }
        //                    }
        //                    catch { };
        //                    break;
        //                case 'L':

        //                    try
        //                    {
        //                        while (damage_pole[RY[j] - 1, RX[j]] == ' ' || damage_pole[RY[j] - 1, RX[j]] == 'K')
        //                        {
        //                            damage_pole[RY[j] - 1, RX[j]] = '*';
        //                            j++;
        //                        }
        //                    }
        //                    catch { }
        //                    try{while (damage_pole[RY[j] + 1, RX[j]] == ' ' || damage_pole[RY[j] - 1, RX[j]] == 'K')
        //                    {
        //                        damage_pole[RY[j] + 1, RX[j]] = '*';
        //                        j++;
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                            {
        //                                while (damage_pole[RY[j], RX[j] - 1] == ' ' || damage_pole[RY[j] - 1, RX[j]] == 'K')
        //                    {
        //                        damage_pole[RY[j], RX[j] - 1] = '*';
        //                        j++;
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                {
        //                                    while (damage_pole[RY[j], RX[j] + 1] == ' ' || damage_pole[RY[j] - 1, RX[j]] == 'K')
        //                    {
        //                        damage_pole[RY[j], RX[j] + 1] = '*';
        //                        j++;
        //                    }
        //                    }
        //                    catch { }; break;
        //                case 'H':
        //                    try
        //                    {
        //                        if (damage_pole[RX[r] + 1, RY[r] + 2] == ' ' || damage_pole[RX[r] + 1, RY[r] + 2] == 'K')
        //                        {
        //                            damage_pole[RX[r] + 1, RY[r] + 2] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                        try
        //                        {
        //                            if (damage_pole[RX[r] + 1, RY[r] - 2] == ' ' || damage_pole[RX[r] + 1, RY[r] - 2] == 'K')
        //                    {
        //                        damage_pole[RX[r] + 1, RY[r] - 2] = '*';
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                            {
        //                                if (damage_pole[RX[r] - 1, RY[r] + 2] == ' ' || damage_pole[RX[r] - 1, RY[r] + 2] == 'K')
        //                    {
        //                        damage_pole[RX[r] - 1, RY[r] + 2] = '*';
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                {
        //                                    if (damage_pole[RX[r] - 1, RY[r] - 2] == ' ' || damage_pole[RX[r] - 1, RY[r] - 2] == 'K')
        //                    {
        //                        damage_pole[RX[r] - 1, RY[r] - 2] = '*';
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                    {
        //                                        if (damage_pole[RX[r] + 2, RY[r] + 1] == ' ' || damage_pole[RX[r] + 2, RY[r] + 1] == 'K')
        //                    {
        //                        damage_pole[RX[r] + 2, RY[r] + 1] = '*';
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                        {
        //                                            if (damage_pole[RX[r] + 2, RY[r] - 1] == ' ' || damage_pole[RX[r] + 2, RY[r] - 1] == 'K')
        //                    {
        //                        damage_pole[RX[r] + 2, RY[r] - 1] = '*';
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                            {
        //                                                if (damage_pole[RX[r] - 2, RY[r] - 1] == ' ' || damage_pole[RX[r] - 2, RY[r] - 1] == 'K')
        //                    {
        //                        damage_pole[RX[r] - 2, RY[r] - 1] = '*';
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                                {
        //                                                    if (damage_pole[RX[r] - 2, RY[r] + 1] == ' ' || damage_pole[RX[r] - 2, RY[r] + 1] == 'K')
        //                    {
        //                        damage_pole[RX[r] - 2, RY[r] + 1] = '*';
        //                    }
        //                    }
        //                    catch { }; break;
        //                case 'K':
        //                    try
        //                    {
        //                        if (damage_pole[RX[r] - 1, RY[r] - 1] == ' ')
        //                        {
        //                            damage_pole[RX[r] - 1, RY[r] - 1] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[RX[r] - 1, RY[r]] == ' ')
        //                        {
        //                            damage_pole[RX[r] - 1, RY[r]] = '*';
        //                        } } catch { };
        //                    try
        //                            {
        //                                if (damage_pole[RX[r] - 1, RY[r] + 1] == ' ')
        //                    {
        //                        damage_pole[RX[r] - 1, RY[r] + 1] = '*';
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                {
        //                                    if (damage_pole[RX[r], RY[r] - 1] == ' ')
        //                    {
        //                        damage_pole[RX[r], RY[r] - 1] = '*';
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                    {
        //                                        if (damage_pole[RX[r], RY[r] + 1] == ' ')
        //                    {
        //                        damage_pole[RX[r], RY[r] + 1] = '*';
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                        {
        //                                            if (damage_pole[RX[r] + 1, RY[r] - 1] == ' ')
        //                    {
        //                        damage_pole[RX[r] + 1, RY[r] - 1] = '*';
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                            {
        //                                                if (damage_pole[RX[r] + 1, RY[r]] == ' ')
        //                    {
        //                        damage_pole[RX[r] + 1, RY[r]] = '*';
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                                {
        //                                                    if (damage_pole[RX[r] + 1, RY[r] + 1] == ' ')
        //                    {
        //                        damage_pole[RX[r] + 1, RY[r] + 1] = '*';
        //                    }
        //                    }
        //                    catch { }; break;
        //                case 'F':
        //                    try { while (damage_pole[RY[r] - 1, RX[r] - 1] == ' ' || damage_pole[RY[r] - 1, RX[r] - 1] == 'K')
        //                        {
        //                            damage_pole[RY[r] - 1, RX[r] - 1] = '*';
        //                            r -= 1;
        //                        } } catch { }
        //                        try
        //                        {
        //                            while (damage_pole[RY[r] - 1, RX[r] + 1] == ' ' || damage_pole[RY[r] - 1, RX[r] - 1] == 'K')
        //                    {
        //                        damage_pole[RY[r] - 1, RX[r2] + 1] = '*';
        //                        r -= 1;
        //                        r2++;
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                            {
        //                                while (damage_pole[RY[r] + 1, RX[r] + 1] == ' ' || damage_pole[RY[r] - 1, RX[r] - 1] == 'K')
        //                    {
        //                        damage_pole[RY[r] + 1, RX[r] + 1] = '*';
        //                        r++;
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                {
        //                                    while (damage_pole[RY[r] + 1, RX[r] - 1] == ' ' || damage_pole[RY[r] - 1, RX[r] - 1] == 'K')
        //                    {
        //                        damage_pole[RY[r] - 1, RX[r] - 1] = '*';
        //                        r2 -= 1;
        //                        r++;
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                    {
        //                                        while (damage_pole[RY[j] - 1, RX[j]] == ' ' || damage_pole[RY[j] - 1, RX[j]] == 'K')
        //                    {
        //                        damage_pole[RY[j] - 1, RX[j]] = '*';
        //                        j++;
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                        {
        //                                            while (damage_pole[RY[j] + 1, RX[j]] == ' ' || damage_pole[RY[j] - 1, RX[j]] == 'K')
        //                    {
        //                        damage_pole[RY[j] + 1, RX[j]] = '*';
        //                        j++;
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                            {
        //                                                while (damage_pole[RY[j], RX[j] - 1] == ' ' || damage_pole[RY[j] - 1, RX[j]] == 'K')
        //                    {
        //                        damage_pole[RY[j], RX[j] - 1] = '*';
        //                        j++;
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                                {
        //                                                    while (damage_pole[RY[j], RX[j] + 1] == ' ' || damage_pole[RY[j] - 1, RX[j]] == 'K')
        //                    {
        //                        damage_pole[RY[j], RX[j] + 1] = '*';
        //                        j++;
        //                    }
        //                    }
        //                    catch { }; break;
        //                case 'E':
        //                    try
        //                    {
        //                        while (damage_pole[RY[r] - 1, RX[r] - 1] == ' ' || damage_pole[RY[r] - 1, RX[r] - 1] == 'K')
        //                        {
        //                            damage_pole[RY[r] - 1, RX[r] - 1] = '*';
        //                            r -= 1;
        //                        }}
        //                    catch { }
        //                        try
        //                        {
        //                            while (damage_pole[RY[r] - 1, RX[r] + 1] == ' ' || damage_pole[RY[r] - 1, RX[r] - 1] == 'K')
        //                    {
        //                        damage_pole[RY[r] - 1, RX[r2] + 1] = '*';
        //                        r -= 1;
        //                        r2++;
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                            {
        //                                while (damage_pole[RY[r] + 1, RX[r] + 1] == ' ' || damage_pole[RY[r] - 1, RX[r] - 1] == 'K')
        //                    {
        //                        damage_pole[RY[r] + 1, RX[r] + 1] = '*';
        //                        r++;
        //                    }
        //                    }
        //                    catch { }
        //                    try
        //                                {
        //                                    while (damage_pole[RY[r] + 1, RX[r] - 1] == ' ' || damage_pole[RY[r] - 1, RX[r] - 1] == 'K')
        //                    {
        //                        damage_pole[RY[r] - 1, RX[r] - 1] = '*';
        //                        r2 -= 1;
        //                        r++;
        //                    }
        //                    }
        //                    catch { }; break;
        //            }
        //        }
        //        for (int sh = 0; sh < 16; sh++)
        //        {
        //            if (damage_pole[RY[sh], RX[sh]] == 'K')
        //            {
        //                return 0;
        //            }
        //        }
        //        return 1;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < 16; i++)
        //        {
        //            int r = i;
        //            int r2 = r;
        //            int j = i;
        //            switch (damage_pole[BY[i], BX[i]])
        //            {
        //                case 'p':
        //                    try
        //                    {
        //                        if (damage_pole[BY[r] + 1, BX[r] + 1] == ' ' || damage_pole[BY[r] + 1, BX[r] + 1] == 'K')
        //                        {
        //                            damage_pole[BY[r] + 1, BX[r] + 1] = '*';

        //                        }
        //                    }
        //                    catch
        //                    {
        //                        try
        //                        {
        //                            if (damage_pole[RY[r] + 1, BX[r] - 1] == ' ' || damage_pole[BY[r] - 1, BX[r] + 1] == 'K')
        //                            {
        //                                damage_pole[RY[r] + 1, BX[r] - 1] = '*';
        //                            }
        //                        }
        //                        catch { }
        //                    }
        //                    try
        //                    {
        //                        if (damage_pole[BY[r] + 1, BX[r] - 1] == ' ' || damage_pole[BY[r] - 1, BX[r] + 1] == 'K')
        //                        {
        //                            damage_pole[BY[r] + 1, BX[r] - 1] = '*';
        //                        }
        //                    }
        //                    catch { };
        //                    break;
        //                case 'L':

        //                    try
        //                    {
        //                        while (damage_pole[BY[j] - 1, BX[j]] == ' ' || damage_pole[BY[j] - 1, BX[j]] == 'K')
        //                        {
        //                            damage_pole[BY[j] - 1, BX[j]] = '*';
        //                            j++;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[j] + 1, BX[j]] == ' ' || damage_pole[BY[j] - 1, BX[j]] == 'K')
        //                        {
        //                            damage_pole[BY[j] + 1, BX[j]] = '*';
        //                            j++;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[j], BX[j] - 1] == ' ' || damage_pole[BY[j] - 1, BX[j]] == 'K')
        //                        {
        //                            damage_pole[BY[j], BX[j] - 1] = '*';
        //                            j++;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[j], BX[j] + 1] == ' ' || damage_pole[BY[j] - 1, BX[j]] == 'K')
        //                        {
        //                            damage_pole[BY[j], BX[j] + 1] = '*';
        //                            j++;
        //                        }
        //                    }
        //                    catch { }; break;
        //                case 'H':
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] + 1, BY[r] + 2] == ' ' || damage_pole[BX[r] + 1, BY[r] + 2] == 'K')
        //                        {
        //                            damage_pole[BX[r] + 1, BY[r] + 2] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] + 1, BY[r] - 2] == ' ' || damage_pole[BX[r] + 1, BY[r] - 2] == 'K')
        //                        {
        //                            damage_pole[BX[r] + 1, BY[r] - 2] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] - 1, BY[r] + 2] == ' ' || damage_pole[BX[r] - 1, BY[r] + 2] == 'K')
        //                        {
        //                            damage_pole[BX[r] - 1, BY[r] + 2] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] - 1, BY[r] - 2] == ' ' || damage_pole[BX[r] - 1, BY[r] - 2] == 'K')
        //                        {
        //                            damage_pole[BX[r] - 1, BY[r] - 2] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] + 2, BY[r] + 1] == ' ' || damage_pole[BX[r] + 2, BY[r] + 1] == 'K')
        //                        {
        //                            damage_pole[BX[r] + 2, BY[r] + 1] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] + 2, BY[r] - 1] == ' ' || damage_pole[BX[r] + 2, BY[r] - 1] == 'K')
        //                        {
        //                            damage_pole[BX[r] + 2, BY[r] - 1] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] - 2, BY[r] - 1] == ' ' || damage_pole[BX[r] - 2,BY[r] - 1] == 'K')
        //                        {
        //                            damage_pole[BX[r] - 2, BY[r] - 1] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] - 2,BY[r] + 1] == ' ' || damage_pole[BX[r] - 2, BY[r] + 1] == 'K')
        //                        {
        //                            damage_pole[BX[r] - 2, BY[r] + 1] = '*';
        //                        }
        //                    }
        //                    catch { }; break;
        //                case 'K':
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] - 1, BY[r] - 1] == ' ')
        //                        {
        //                            damage_pole[BX[r] - 1, BY[r] - 1] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] - 1, BY[r]] == ' ')
        //                        {
        //                            damage_pole[BX[r] - 1, BY[r]] = '*';
        //                        }
        //                    }
        //                    catch { };
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] - 1, BY[r] + 1] == ' ')
        //                        {
        //                            damage_pole[BX[r] - 1, BY[r] + 1] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r], BY[r] - 1] == ' ')
        //                        {
        //                            damage_pole[BX[r], BY[r] - 1] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r], BY[r] + 1] == ' ')
        //                        {
        //                            damage_pole[BX[r], BY[r] + 1] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] + 1, BY[r] - 1] == ' ')
        //                        {
        //                            damage_pole[BX[r] + 1, BY[r] - 1] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] + 1, BY[r]] == ' ')
        //                        {
        //                            damage_pole[BX[r] + 1, BY[r]] = '*';
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        if (damage_pole[BX[r] + 1, BY[r] + 1] == ' ')
        //                        {
        //                            damage_pole[BX[r] + 1, BY[r] + 1] = '*';
        //                        }
        //                    }
        //                    catch { }; break;
        //                case 'F':
        //                    try
        //                    {
        //                        while (damage_pole[BY[r] - 1, BX[r] - 1] == ' ' || damage_pole[BY[r] - 1, BX[r] - 1] == 'K')
        //                        {
        //                            damage_pole[BY[r] - 1, BX[r] - 1] = '*';
        //                            r -= 1;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[r] - 1, BX[r] + 1] == ' ' || damage_pole[BY[r] - 1, BX[r] - 1] == 'K')
        //                        {
        //                            damage_pole[BY[r] - 1, BX[r2] + 1] = '*';
        //                            r -= 1;
        //                            r2++;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[r] + 1, BX[r] + 1] == ' ' || damage_pole[BY[r] - 1, BX[r] - 1] == 'K')
        //                        {
        //                            damage_pole[BY[r] + 1,BX[r] + 1] = '*';
        //                            r++;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[r] + 1, BX[r] - 1] == ' ' || damage_pole[BY[r] - 1, BX[r] - 1] == 'K')
        //                        {
        //                            damage_pole[BY[r] - 1, BX[r] - 1] = '*';
        //                            r2 -= 1;
        //                            r++;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[j] - 1, BX[j]] == ' ' || damage_pole[BY[j] - 1, BX[j]] == 'K')
        //                        {
        //                            damage_pole[BY[j] - 1, BX[j]] = '*';
        //                            j++;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[j] + 1,BX[j]] == ' ' || damage_pole[BY[j] - 1, BX[j]] == 'K')
        //                        {
        //                            damage_pole[BY[j] + 1, BX[j]] = '*';
        //                            j++;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[j], BX[j] - 1] == ' ' || damage_pole[BY[j] - 1, BX[j]] == 'K')
        //                        {
        //                            damage_pole[BY[j], BX[j] - 1] = '*';
        //                            j++;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[j], BX[j] + 1] == ' ' || damage_pole[BY[j] - 1, BX[j]] == 'K')
        //                        {
        //                            damage_pole[BY[j], BX[j] + 1] = '*';
        //                            j++;
        //                        }
        //                    }
        //                    catch { }; break;
        //                case 'E':
        //                    try
        //                    {
        //                        while (damage_pole[BY[r] - 1, BX[r] - 1] == ' ' || damage_pole[BY[r] - 1, BX[r] - 1] == 'K')
        //                        {
        //                            damage_pole[BY[r] - 1, BX[r] - 1] = '*';
        //                            r -= 1;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[r] - 1, BX[r] + 1] == ' ' || damage_pole[BY[r] - 1, BX[r] - 1] == 'K')
        //                        {
        //                            damage_pole[BY[r] - 1, BX[r2] + 1] = '*';
        //                            r -= 1;
        //                            r2++;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[r] + 1, BX[r] + 1] == ' ' || damage_pole[BY[r] - 1, BX[r] - 1] == 'K')
        //                        {
        //                            damage_pole[BY[r] + 1, BX[r] + 1] = '*';
        //                            r++;
        //                        }
        //                    }
        //                    catch { }
        //                    try
        //                    {
        //                        while (damage_pole[BY[r] + 1, BX[r] - 1] == ' ' || damage_pole[BY[r] - 1, BX[r] - 1] == 'K')
        //                        {
        //                            damage_pole[BY[r] - 1, BX[r] - 1] = '*';
        //                            r2 -= 1;
        //                            r++;
        //                        }
        //                    }
        //                    catch { }; break;

        //            }
                
        //        }
        //        }
        //        for (int sh = 0; sh < 16; sh++)
        //        {
        //            if (damage_pole[BY[sh], BX[sh]] == 'K')
        //            {
        //                return 2;
        //            }
        //        }
        //        return 3;
        //}
    }
    public static class Paint
    {
        public static int[,] Pole(char[,] pole, int[,] pole2) { 
            int k = 2;
            int l = -1;


            for (int i = 2; i < 10; i++)
            {
                for (int j = 2; j < 10; j++)
                {
                    k = k + l;
                    if (k == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(i, j);
                        if (j - 2 < 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(pole[j - 2, i - 2]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(pole[j - 2, i - 2]);
                        }
                        pole2[i - 2, j - 2] = 1;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(i, j);
                        if (j - 2 < 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(pole[j - 2, i - 2]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(pole[j - 2, i - 2]);
                        }
                        pole2[i - 2, j - 2] = 0;
                    }

                    l = l * (-1);
                }
                l = l * (-1);
                k = k - l;
            }
            return pole2;
        }

    }
}
