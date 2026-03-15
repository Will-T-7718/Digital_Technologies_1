using System;

public class Program

{
	static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1;
    static int choice;
    static int flag = 0; // seting condition of tic tac 1 = win and -1 is draw
	static Random rand = new Random();
	public static void Main( string[] args)

	
	{
		bool running = true;
		while (running)
		{
		//main menu
		Console.WriteLine("_Bill's Console Game Browser_");
		Console.WriteLine("1 For Tic Tac Toe");
		Console.WriteLine("2 For Rock, Paper, Sccisors");
		Console.WriteLine("3 To Leave");
		Console.WriteLine("Select One");
			
		String choice = Console.ReadLine();
	
		switch (choice)
		{
			case "1":
				PlayTicTac();
				break;
			case "2":
				PlayRPS();
				break;
			case "3":
				System.Environment.Exit(3);
				Console.WriteLine("See you next time");
				break;
			default:
				Console.WriteLine();
				Console.WriteLine("Please chose another number, inavalid choice");
				Console.WriteLine();
				break;
		}	
	}
}
		
	static void PlayTicTac()
	{
		do
		{
			//Tic Tac Starting Menu
			Console.WriteLine("Tic Tac Toe");
			Console.WriteLine("Player_1 - X, Player_2 O");
			Console.WriteLine();
			PrintBoard();

			player = (player % 2 == 0) ? 2 : 1;
			Console.Write($"player {player}, enter (1-9): ");

			bool validInput = int.TryParse(Console.ReadLine(), out choice);
			if (!validInput || choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O' )
			{
				Console.WriteLine("Invalid move, Chose another number");
				Console.WriteLine();
				Console.ReadLine();
				continue;
			}
			// players turn
			board[choice - 1]  = (player == 1) ? 'X' : 'O';
			flag = CheckWin();
			player++;
		}
		while (flag == 0); 
		
		PrintBoard();
		
		// saying if the game was a win or draw
		if (flag == 1)
			Console.WriteLine($"Player {(player % 2) + 1} wins");
		else
			Console.WriteLine("Draw");
		
		Console.WriteLine();
		
	}

	 static void PrintBoard()
    {
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]}");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]}");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]}");
        Console.WriteLine("     |     |     ");
    }

    static int CheckWin()
    {
        // Horizontal wins
        if (board[0] == board[1] && board[1] == board[2]) return 1;
        if (board[3] == board[4] && board[4] == board[5]) return 1;
        if (board[6] == board[7] && board[7] == board[8]) return 1;

        // Vertical wins
        if (board[0] == board[3] && board[3] == board[6]) return 1;
        if (board[1] == board[4] && board[4] == board[7]) return 1;
        if (board[2] == board[5] && board[5] == board[8]) return 1;

        // Diagonal wins
        if (board[0] == board[4] && board[4] == board[8]) return 1;
        if (board[2] == board[4] && board[4] == board[6]) return 1;

        // Check for draw
        bool allFilled = true;
        foreach (char c in board)
        {
            if (c != 'X' && c != 'O')
            {
                allFilled = false;
                break;
            }
        }

        return allFilled ? -1 : 0;
    }
	
	static void PlayRPS()
	{
		bool runningRPS = true;
		while (runningRPS)
		{
		int userIn;

		Console.WriteLine("Press 1 for Rock, 2 for Paper, 3 for Scissors");
		Console.WriteLine("Press 4 Menu");

		int.TryParse(Console.ReadLine(), out userIn);

		if (userIn == 4)
		{
			break;
		}

		Console.WriteLine($"The player chose {userIn}");

		int computerIn = randomNumberGenerator();
		Console.WriteLine($"The computer chose {computerIn}");

		if (computerIn == userIn)
		{
			Console.WriteLine("Draw");
			}
			else if (computerIn == 1 && userIn == 2)
			{
				Console.WriteLine("You Won");
			}
			else if (computerIn == 2 && userIn == 1)
			{
				Console.WriteLine("You Lost");
			}
			else if (computerIn == 3 && userIn == 1)
			{
				Console.WriteLine("You Lost");
			}
			else if (computerIn == 1 && userIn == 3)
			{
				Console.WriteLine("You Won");
			}
			else if (computerIn == 2 && userIn == 3)
			{
				Console.WriteLine("You Lost");
			}
			else if (computerIn == 3 && userIn == 2)
			{
				Console.WriteLine("You Won");
			}
			else
			{
				Console.WriteLine("Invalid Number");
			}
		}
	}
	static int randomNumberGenerator() 
	{
		int randomValue = rand.Next(1, 4);
		return randomValue;
	}
}
