using System.Reflection.Metadata.Ecma335;

namespace TicToeGame
{
    internal class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char[] board1 = {' ',' ',' ',' ',' ',' ',' ',' ',' '};
        static int playerTurn = 1; // Player 1 starts
       
        static void Main(string[] args)
        {
            bool gameover = false;
             do
                {
                    Console.Clear();
                    Console.WriteLine("Player 1: X and Player 2: O");
                    Console.WriteLine("Enter Box Number for writing X there !!");
                    Console.WriteLine("\n");
                    Print();
                    if (playerTurn % 2 == 0)
                    {
                        Console.WriteLine("Turn Player 2");
                        GameInput(Convert.ToInt32(Console.ReadLine()));
                    }
                    else
                    {
                        Console.WriteLine("Turn Player 1");

                        GameInput(Convert.ToInt32(Console.ReadLine()));
                    }
                    Console.WriteLine("\n");

                   if(playerTurn>=5)
                      gameover = CheckWin();
                } while (!gameover && playerTurn <= 9);

                Console.Clear();
                Print();

                if (gameover)
                {
                    if (playerTurn % 2 == 0)
                        Console.WriteLine("Player 1 wins!");
                    else
                        Console.WriteLine("Player 2 wins!");
                }
                else
                    Console.WriteLine("It's a draw!");

        }

        static void Print()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board1[0], board1[1], board1[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board1[3], board1[4], board1[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board1[6], board1[7], board1[8]);
            Console.WriteLine("     |     |      ");
        }

        static bool CheckWin()
        {
            // Rows
            if (board[0] == board[1] && board[1] == board[2])
                return true;
            if (board[3] == board[4] && board[4] == board[5])
                return true;
            if (board[6] == board[7] && board[7] == board[8])
                return true;

            // Columns
            if (board[0] == board[3] && board[3] == board[6])
                return true;
            if (board[1] == board[4] && board[4] == board[7])
                return true;
            if (board[2] == board[5] && board[5] == board[8])
                return true;

            // Diagonals
            if (board[0] == board[4] && board[4] == board[8])
                return true;
            if (board[2] == board[4] && board[4] == board[6])
                return true;

            return false;
        }

        static void GameInput(int choosed)
        {
            int choice = choosed;
            bool run = true;
            while (run)
            {
                if (choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
                {
                    Console.WriteLine("Invalid move! Press enter and try again.");
                    choice = Convert.ToInt32(Console.ReadLine());
                    run= true;
                }
                else
                {
                    if (playerTurn % 2 == 0)
                    {
                        board[choice - 1] = 'O';
                        board1[choice - 1] = 'O';
                        playerTurn++;
                    }
                    else
                    {
                        board[choice - 1] = 'X';
                        board1[choice - 1] = 'X';
                        playerTurn++;
                    }
                    run = false;
                }
            }
        }

    }
}