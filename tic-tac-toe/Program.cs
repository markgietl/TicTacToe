namespace Tictactoe
{
    internal class Program
    {
        //The game board
        private static char[,] gameBoard = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };

        private static int turns = 0;

        public static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;

            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXorO(player, input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO(player, input);
                }

                PrintBoard();

                //Check if either play has won the game
                char[] playerChars = { 'X', 'O' };

                foreach (char playerChar in playerChars)
                {
                    if (((gameBoard[0, 0] == playerChar) && (gameBoard[0, 1] == playerChar) && (gameBoard[0, 2] == playerChar))
                         || ((gameBoard[1, 0] == playerChar) && (gameBoard[1, 1] == playerChar) && (gameBoard[1, 2] == playerChar))
                         || ((gameBoard[2, 0] == playerChar) && (gameBoard[2, 1] == playerChar) && (gameBoard[2, 2] == playerChar))
                         || ((gameBoard[0, 0] == playerChar) && (gameBoard[1, 0] == playerChar) && (gameBoard[2, 0] == playerChar))
                         || ((gameBoard[0, 1] == playerChar) && (gameBoard[1, 1] == playerChar) && (gameBoard[2, 1] == playerChar))
                         || ((gameBoard[0, 2] == playerChar) && (gameBoard[1, 2] == playerChar) && (gameBoard[2, 2] == playerChar))
                         || ((gameBoard[0, 0] == playerChar) && (gameBoard[1, 1] == playerChar) && (gameBoard[2, 2] == playerChar))
                         || ((gameBoard[0, 2] == playerChar) && (gameBoard[1, 1] == playerChar) && (gameBoard[2, 0] == playerChar))
                         )
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("Player 2 wins!");
                        }
                        else
                        {
                            Console.WriteLine("Player 1 wins!");
                        }

                        Console.WriteLine("Press any key to play again.");
                        Console.ReadKey();
                        ResetBoard();
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("Draw");
                        Console.WriteLine("Press any key to play again.");
                        Console.ReadKey();
                        ResetBoard();
                        break;
                    }
                }

                //Check if the player has chosen a space that has already been chosen previously
                do
                {
                    Console.WriteLine($"Player {player} - choose a space on the board.");
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect input. Please enter a number.");
                    }

                    if ((input == 1) && (gameBoard[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (gameBoard[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (gameBoard[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (gameBoard[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (gameBoard[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (gameBoard[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (gameBoard[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (gameBoard[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (gameBoard[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("That space has already been taken, choose another.");
                        inputCorrect = false;
                    }
                } while (!inputCorrect);
            } while (true);
        }

        public static void ResetBoard()
        {
            char[,] boardInitial =
            {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };

            gameBoard = boardInitial;
            PrintBoard();
            turns = 0;
        }

        public static void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"   {gameBoard[0, 0]} | {gameBoard[0, 1]} | {gameBoard[0, 2]}");
            Console.WriteLine("   ---------");
            Console.WriteLine($"   {gameBoard[1, 0]} | {gameBoard[1, 1]} | {gameBoard[1, 2]}");
            Console.WriteLine("   ---------");
            Console.WriteLine($"   {gameBoard[2, 0]} | {gameBoard[2, 1]} | {gameBoard[2, 2]}");
            Console.WriteLine("");
            turns++;
        }

        public static void EnterXorO(int player, int input)
        {
            char playerXO = ' ';

            if (player == 1)
                playerXO = 'X';
            else if (player == 2)
                playerXO = 'O';

            switch (input)
            {
                case 1: gameBoard[0, 0] = playerXO; break;
                case 2: gameBoard[0, 1] = playerXO; break;
                case 3: gameBoard[0, 2] = playerXO; break;
                case 4: gameBoard[1, 0] = playerXO; break;
                case 5: gameBoard[1, 1] = playerXO; break;
                case 6: gameBoard[1, 2] = playerXO; break;
                case 7: gameBoard[2, 0] = playerXO; break;
                case 8: gameBoard[2, 1] = playerXO; break;
                case 9: gameBoard[2, 2] = playerXO; break;
            }
        }
    }
}