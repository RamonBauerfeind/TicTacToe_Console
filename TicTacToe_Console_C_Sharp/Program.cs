using System;

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
            player1[1] = player1[0].Substring(0, 1);
            Console.WriteLine("What's your name, Player Two?");
            player2[0] = Console.ReadLine();
            player2[1] = player2[0].Substring(0, 1);

            //Spiel
            string[,] board = new string[9, 9];
            int count = 0;
            bool finish = false;
            bool gameOver = false;

            //Erstellen des Spielfeldes
            for (int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    board[i,j] = " ";
                    count++;
                }
            }

            //bis Abbruchparameter erfüllt wird
            while (finish == false && gameOver == false)
            {
                bool onlyNumbersPlayer1 = false;
                bool onlyNumbersPlayer2 = false;

                //Eingabe Spieler 1 nur int und kein Sieger und noch freie Felder vorhanden
                while (onlyNumbersPlayer1 == false && finish == false && gameOver == false)
                {
                    Console.WriteLine("Where do you want to place your symbol, {0}? (1:1 - 9:9)", player1[0]);
                    try
                    {   
                        //bool welcher anzeigt, ob das entsprechende Feld schon belegt ist
                        bool freeField = true;
                        //Eingabe einlesen
                        string read = Console.ReadLine();
                        int read1 = Convert.ToInt32(read.Substring(0, 1));
                        int read2 = Convert.ToInt32(read.Substring(1, 1));
                        //String für Übergabe an Funktion
                        string strField1 = Convert.ToString(read1);
                        string strField2 = Convert.ToString(read2);
                        
                        //wenn Eingabe == 2 Ziffern
                        if(read.Length == 2)
                        {
                            //Prüfung, ob Feld bereits belegt ist
                            freeField = CheckLines(board, strField1, strField2);
                            
                            //wenn das Feld noch nicht belegt ist
                            if (freeField == true)
                            {
                                board[read1 - 1, read2 - 1] = player1[1];
                                onlyNumbersPlayer1 = true;
                                Console.WriteLine(board[0, 0] + " | " + board[0, 1] + " | " + board[0, 2] + " | " + board[0, 3] + " | " + board[0, 4] + " | " + board[0, 5] + " | " + board[0, 6] + " | " + board[0, 7] + " | " + board[0, 8]);
                                Console.WriteLine(board[1, 0] + " | " + board[1, 1] + " | " + board[1, 2] + " | " + board[1, 3] + " | " + board[1, 4] + " | " + board[1, 5] + " | " + board[1, 6] + " | " + board[1, 7] + " | " + board[1, 8]);
                                Console.WriteLine(board[2, 0] + " | " + board[2, 1] + " | " + board[2, 2] + " | " + board[2, 3] + " | " + board[2, 4] + " | " + board[2, 5] + " | " + board[2, 6] + " | " + board[2, 7] + " | " + board[2, 8]);
                                Console.WriteLine(board[3, 0] + " | " + board[3, 1] + " | " + board[3, 2] + " | " + board[3, 3] + " | " + board[3, 4] + " | " + board[3, 5] + " | " + board[3, 6] + " | " + board[3, 7] + " | " + board[3, 8]);
                                Console.WriteLine(board[4, 0] + " | " + board[4, 1] + " | " + board[4, 2] + " | " + board[4, 3] + " | " + board[4, 4] + " | " + board[4, 5] + " | " + board[4, 6] + " | " + board[4, 7] + " | " + board[4, 8]);
                                Console.WriteLine(board[5, 0] + " | " + board[5, 1] + " | " + board[5, 2] + " | " + board[5, 3] + " | " + board[5, 4] + " | " + board[5, 5] + " | " + board[5, 6] + " | " + board[5, 7] + " | " + board[5, 8]);
                                Console.WriteLine(board[6, 0] + " | " + board[6, 1] + " | " + board[6, 2] + " | " + board[6, 3] + " | " + board[6, 4] + " | " + board[6, 5] + " | " + board[6, 6] + " | " + board[6, 7] + " | " + board[6, 8]);
                                Console.WriteLine(board[7, 0] + " | " + board[7, 1] + " | " + board[7, 2] + " | " + board[7, 3] + " | " + board[7, 4] + " | " + board[7, 5] + " | " + board[7, 6] + " | " + board[7, 7] + " | " + board[7, 8]);
                                Console.WriteLine(board[8, 0] + " | " + board[8, 1] + " | " + board[8, 2] + " | " + board[8, 3] + " | " + board[8, 4] + " | " + board[8, 5] + " | " + board[8, 6] + " | " + board[8, 7] + " | " + board[8, 8]);
                                
                                //Prüfung, ob es einen Sieger gibt
                                finish = Finish(board);
                                if(finish == true)
                                {
                                    Console.WriteLine("Congratulations!!! You won, {0}!!!", player1[0]);
                                }
                                gameOver = GameOver(board);
                                
                                //alle Felder belegt?
                                if(gameOver == true)
                                {
                                    Console.WriteLine("Draw!!! Game Over!!!");
                                }
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

                //Eingabe Spieler 2 nur int und kein Sieger und noch freie Felder vorhanden
                while (onlyNumbersPlayer2 == false && finish == false && gameOver == false)
                {
                    Console.WriteLine("Where do you want to place your symbol, {0}? (1 - 9)", player2[0]);
                    try
                    {
                        //bool welcher anzeigt, ob das entsprechende Feld schon belegt ist
                        bool freeField = true;
                        //Eingabe einlesen
                        string read = Console.ReadLine();
                        int read1 = Convert.ToInt32(read.Substring(0, 1));
                        int read2 = Convert.ToInt32(read.Substring(1, 1));
                        //String für Übergabe an Funktion
                        string strField1 = Convert.ToString(read1);
                        string strField2 = Convert.ToString(read2);
                        
                        //wenn Eingabe == 2 Ziffern
                        if (read.Length == 2)
                        {
                            //Prüfung, ob Feld bereits belegt ist
                            freeField = CheckLines(board, strField1, strField2);
                            
                            //wenn das Feld noch nicht belegt ist
                            if (freeField == true)
                            {
                                board[read1 - 1, read2 - 1] = player2[1];
                                onlyNumbersPlayer2 = true;
                                Console.WriteLine(board[0, 0] + " | " + board[0, 1] + " | " + board[0, 2] + " | " + board[0, 3] + " | " + board[0, 4] + " | " + board[0, 5] + " | " + board[0, 6] + " | " + board[0, 7] + " | " + board[0, 8]);
                                Console.WriteLine(board[1, 0] + " | " + board[1, 1] + " | " + board[1, 2] + " | " + board[1, 3] + " | " + board[1, 4] + " | " + board[1, 5] + " | " + board[1, 6] + " | " + board[1, 7] + " | " + board[1, 8]);
                                Console.WriteLine(board[2, 0] + " | " + board[2, 1] + " | " + board[2, 2] + " | " + board[2, 3] + " | " + board[2, 4] + " | " + board[2, 5] + " | " + board[2, 6] + " | " + board[2, 7] + " | " + board[2, 8]);
                                Console.WriteLine(board[3, 0] + " | " + board[3, 1] + " | " + board[3, 2] + " | " + board[3, 3] + " | " + board[3, 4] + " | " + board[3, 5] + " | " + board[3, 6] + " | " + board[3, 7] + " | " + board[3, 8]);
                                Console.WriteLine(board[4, 0] + " | " + board[4, 1] + " | " + board[4, 2] + " | " + board[4, 3] + " | " + board[4, 4] + " | " + board[4, 5] + " | " + board[4, 6] + " | " + board[4, 7] + " | " + board[4, 8]);
                                Console.WriteLine(board[5, 0] + " | " + board[5, 1] + " | " + board[5, 2] + " | " + board[5, 3] + " | " + board[5, 4] + " | " + board[5, 5] + " | " + board[5, 6] + " | " + board[5, 7] + " | " + board[5, 8]);
                                Console.WriteLine(board[6, 0] + " | " + board[6, 1] + " | " + board[6, 2] + " | " + board[6, 3] + " | " + board[6, 4] + " | " + board[6, 5] + " | " + board[6, 6] + " | " + board[6, 7] + " | " + board[6, 8]);
                                Console.WriteLine(board[7, 0] + " | " + board[7, 1] + " | " + board[7, 2] + " | " + board[7, 3] + " | " + board[7, 4] + " | " + board[7, 5] + " | " + board[7, 6] + " | " + board[7, 7] + " | " + board[7, 8]);
                                Console.WriteLine(board[8, 0] + " | " + board[8, 1] + " | " + board[8, 2] + " | " + board[8, 3] + " | " + board[8, 4] + " | " + board[8, 5] + " | " + board[8, 6] + " | " + board[8, 7] + " | " + board[8, 8]);
                                
                                //Prüfung, ob es einen Sieger gibt
                                finish = Finish(board);
                                if (finish == true)
                                {
                                    Console.WriteLine("Congratulations!!! You won, {0}!!!", player2[0]);
                                }
                                
                                //alle Felder belegt?
                                gameOver = GameOver(board);
                                if (gameOver == true)
                                {
                                    Console.WriteLine("Draw!!! Game Over!!!");
                                }
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
            }
            Console.ReadKey();
        }

        //Prüfung, ob das gewählte Feld noch frei ist
        public static bool CheckLines(string[,] board, string field1, string field2)
        {
            bool freeField = true;
            int intField1 = Convert.ToInt32(field1);
            int intField2 = Convert.ToInt32(field2);
            if (board[intField1 - 1, intField2 - 1] != " ")
            {
                freeField = false;
            }
            return freeField;
        }

        //Prüfung, ob es einen Sieger gibt
        public static bool Finish(string[,] board)
        {
            bool finish = false;

            //Prüfung horizontal
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (board[i, j] != " ")
                    {
                        if (board[i, j] == board[i, j + 1] && board[i, j] == board[i, j + 2])
                        {
                            finish = true;
                        }
                    }
                }
            }

            //Prüfung vertikal
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] != " ")
                    {
                        if (board[i, j] == board[i + 1, j] && board[i, j] == board[i + 2, j])
                        {
                            finish = true;
                        }
                    }
                }
            }

            //Prüfung diagonal
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (board[i, j] != " ")
                    {
                        if (board[i, j] == board[i + 1, j + 1] && board[i, j] == board[i + 2, j + 2])
                        {
                            finish = true;
                        }
                    }
                }
            }
            return finish;
        }

        //Prüfung ob alle Felder belgt sind -> GameOver
        public static bool GameOver(string[,] board)
        {
            bool end = true;
            bool[] gameOver = new bool[81];
            int count = 0;

            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if(board[i, j] == " ")
                    {
                        gameOver[count] = false;
                    }
                    else
                    {
                        gameOver[count] = true;
                    }
                    count++;
                }
            }

            //wenn ein freies Felf vorhanden ist, ist das Spiel noch nicht beendet
            foreach(bool g in gameOver)
            {
                if(g == false)
                {
                    end = false;
                }
            }
            return end;
        }
    }
}
