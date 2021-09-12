using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Console_C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Spielerparameter
            string[] player1 = new string[2];
            string[] player2 = new string[2];

            Console.WriteLine("What's your name, Player One?");
            player1[0] = Console.ReadLine();
            Console.WriteLine("Symbol Player One: ");
            player1[1] = Console.ReadLine();
            Console.WriteLine("What's your name, Player Two?");
            player2[0] = Console.ReadLine();
            Console.WriteLine("Symbol Player Two: ");
            player2[1] = Console.ReadLine();

            //Spiel
            string[] board = new string[9] {" ", " ", " ", " ", " ", " ", " ", " ", " "};
            int field;
            bool finish = false;

            //bis Abbruchparameter erfüllt wird
            while (finish == false)
            {
                bool onlyNumbersPlayer1 = false;
                bool onlyNumbersPlayer2 = false;

                //Eingabe Spieler 1 nur int und 1-9
                while (onlyNumbersPlayer1 == false)
                {
                    Console.WriteLine("Where do you want to place your symbol, {0}? (1 - 9)", player1[0]);
                    try
                    {   
                        //bool welcher anzeigt, ob das entsprechende Feld schon belegt ist
                        bool freeField = true;
                        //Eingabe einlesen
                        field = Convert.ToInt32(Console.ReadLine());
                        //String für Übergabe an Funktion
                        string strField = Convert.ToString(field);
                        //Prüfung, ob Feld bereits belegt ist
                        freeField = CheckLines(board, strField);
                        //wenn Eingabe == 1 - 9
                        if (field >= 1 && field <= 10)
                        {
                            //wenn das Feld noch nicht belegt ist
                            if (freeField == true)
                            {
                                board[field - 1] = player1[1];
                                onlyNumbersPlayer1 = true;
                                Console.WriteLine(board[0] + " | " + board[1] + " | " + board[2]);
                                Console.WriteLine(board[3] + " | " + board[4] + " | " + board[5]);
                                Console.WriteLine(board[6] + " | " + board[7] + " | " + board[8]);
                            }
                            else
                            {
                                Console.WriteLine("Please choose a free field!");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please use only numbers in range 1-9!");
                            continue;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please use only numbers!");
                    }
                }

                //Eingabe Spieler 2 nur int und 1-9
                while (onlyNumbersPlayer2 == false)
                {
                    Console.WriteLine("Where do you want to place your symbol, {0}? (1 - 9)", player2[0]);
                    try
                    {
                        //bool welcher anzeigt, ob das entsprechende Feld schon belegt ist
                        bool freeField = true;
                        //Eingabe einlesen
                        field = Convert.ToInt32(Console.ReadLine());
                        //String für Übergabe an Funktion
                        string strField = Convert.ToString(field);
                        //Prüfung, ob Feld bereits belegt ist
                        freeField = CheckLines(board, strField);
                        //wenn Eingabe == 1 - 9
                        if ((field >= 1 && field <= 10) && freeField == true)
                        {
                            //wenn das Feld noch nicht belegt ist
                            if (freeField == true)
                            {
                                board[field - 1] = player2[1];
                                onlyNumbersPlayer2 = true;
                                Console.WriteLine(board[0] + " | " + board[1] + " | " + board[2]);
                                Console.WriteLine(board[3] + " | " + board[4] + " | " + board[5]);
                                Console.WriteLine(board[6] + " | " + board[7] + " | " + board[8]);
                            }
                            else
                            {
                                Console.WriteLine("Please choose a free field!");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please use only numbers in range 1-9!");
                            continue;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please use only numbers!");
                    }
                }
                Console.ReadKey();
            }
        }
        //Prüfung, ob das gewählte Feld noch frei ist
        public static bool CheckLines(string[] board, string field)
        {
            bool freeField = true;
            int intField = Convert.ToInt32(field);
            if(board[intField - 1] != " ")
            {
                freeField = false;
            }
            return freeField;
        }

    }
}
