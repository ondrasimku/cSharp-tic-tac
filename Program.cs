using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace piskvorky
{
    class Program
    {
        static char[] square = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char square_charakter;
        static string posledniVyherce;
        static int hrac1_vyhry = 0;
        static int hrac2_vyhry = 0;
        static int remizy_pocet = 0;
        static int pocetHer = 0;

        static void Main(string[] args)
        {
            board(1);
            int tah;

            while (true)
            {
                while (true)
                {
                    int stav = checkWin();
                    tah = Hrac(1, 'O');
                    if (tah == 1)
                    {
                        Console.WriteLine("Vyhrál hráč 1 !");
                        hrac1_vyhry++;
                        pocetHer++;
                        posledniVyherce = "Hráč1";
                        Thread.Sleep(2000);
                        board(0);
                        board(1);
                        break;
                    }
                    else if (tah == 0)
                    {
                        Console.WriteLine("Remíza !");
                        remizy_pocet++;
                        pocetHer++;
                        posledniVyherce = "Remíza";
                        Thread.Sleep(2000);
                        board(0);
                        board(1);
                        break;
                    }
                    else if (tah == -1)
                    {
                        board(1, hlaska: "Pole už je obsazené nebo jsi zadal sračku!");
                    }
                    else
                    {
                        break;
                    }
                }
                while (true)
                {

                    tah = Hrac(2, 'X');
                    if (tah == 1)
                    {
                        Console.WriteLine("Vyhrál hráč 2 !");
                        hrac2_vyhry++;
                        pocetHer++;
                        posledniVyherce = "Hráč2";
                        Thread.Sleep(2000);
                        board(0);
                        board(1);
                        break;
                    }
                    else if (tah == 0)
                    {
                        Console.WriteLine("Remíza !");
                        remizy_pocet++;
                        pocetHer++;
                        posledniVyherce = "Remíza";
                        Thread.Sleep(2000);
                        board(0);
                        board(1);
                        break;
                    }
                    else if (tah == -1)
                    {
                        board(1, hlaska: "Pole už je obsazené");
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }

        static int Hrac(int cislo, char charakter)
        {
            Console.WriteLine("\nHráč" + cislo + "  je na tahu! ");
            ConsoleKeyInfo input = Console.ReadKey();

            try
            {
                if (square[Convert.ToInt32(input.KeyChar) - 48] != 'O' && square[Convert.ToInt32(input.KeyChar) - 48] != 'X')
                {
                    square[Convert.ToInt32(input.KeyChar) - 48] = charakter;
                    board(1);
                    if (checkWin() == 1)
                    {
                        return 1;
                    }
                    else if (checkWin() == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return -2;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
               return -1;
            }
        }

        static void board(int action, string hlaska = "")
        {
            if (action == 1)
            {
                Console.Clear();
                Console.WriteLine("Hráč 1 (O)  -  Hráč 2 (X)\n");
                Console.WriteLine("     |     |     ");
                Console.WriteLine("  " + square[7] + "  |  " + square[8] + "  |  " + square[9] + "       Hráč_1 výhry: " + hrac1_vyhry);
                Console.WriteLine("_____|_____|_____" + "     Hráč_2 výhry: " + hrac2_vyhry);
                Console.WriteLine("     |     |     " + "     Remízy: " + remizy_pocet);
                Console.WriteLine("  " + square[4] + "  |  " + square[5] + "  |  " + square[6] + "       Počet her: " + pocetHer);
                Console.WriteLine("_____|_____|_____" + "     Poslední výherce: " + posledniVyherce);
                Console.WriteLine("     |     |     " );
                Console.WriteLine("  " + square[1] + "  |  " + square[2] + "  |  " + square[3] + "");
                Console.WriteLine("     |     |     ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n"+hlaska);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                for (int x = 0; x < 10; x++)
                {
                    switch (x)
                    {
                        case 0:
                            square_charakter = '0';
                            break;
                        case 1:
                            square_charakter = '1';
                            break;
                        case 2:
                            square_charakter = '2';
                            break;
                        case 3:
                            square_charakter = '3';
                            break;
                        case 4:
                            square_charakter = '4';
                            break;
                        case 5:
                            square_charakter = '5';
                            break;
                        case 6:
                            square_charakter = '6';
                            break;
                        case 7:
                            square_charakter = '7';
                            break;
                        case 8:
                            square_charakter = '8';
                            break;
                        case 9:
                            square_charakter = '9';
                            break;
                        default:
                            square_charakter = '0';
                            break;
                    }

                    square[x] = square_charakter;
                }
            }
        }

        static int checkWin()
        {
            if (square[1] == square[2] && square[2] == square[3])

                return 1;
            else if (square[4] == square[5] && square[5] == square[6])

                return 1;
            else if (square[7] == square[8] && square[8] == square[9])

                return 1;
            else if (square[1] == square[4] && square[4] == square[7])

                return 1;
            else if (square[2] == square[5] && square[5] == square[8])

                return 1;
            else if (square[3] == square[6] && square[6] == square[9])

                return 1;
            else if (square[1] == square[5] && square[5] == square[9])

                return 1;
            else if (square[3] == square[5] && square[5] == square[7])

                return 1;
            else if (square[1] != '1' && square[2] != '2' && square[3] != '3'
                            && square[4] != '4' && square[5] != '5' && square[6] != '6'
                          && square[7] != '7' && square[8] != '8' && square[9] != '9')

                return 0;
            else
                return -1;
        }
    }
}
