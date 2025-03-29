// Tic Tac Toe
// - Computer vs Human (use random).
// - Player can pick X or O
// - Use numpad to select square
// - Game state (score) is kept track of
// - Game should detect win state / draw state.

class Game
{
	public int Moves { get; set; }
	public char[,] Board { get; set; }

	public Game()
	{
		Moves = 0;
		Board = new char[3,3];

		for(int i = 0; i < 3; i++)
			for(int j = 0; j < 3; j++) 
				Board[i,j] = ' ';
	}

	public void DrawBoard(char c)
	{
		Console.Clear();
		Console.WriteLine($"It's {c}'s turn.");
		Console.WriteLine($" {Board[0,0]} | {Board[0,1]} | {Board[0,2]} ");
		Console.WriteLine($"---+---+---");
		Console.WriteLine($" {Board[1,0]} | {Board[1,1]} | {Board[1,2]} ");
		Console.WriteLine($"---+---+---");
		Console.WriteLine($" {Board[2,0]} | {Board[2,1]} | {Board[2,2]} ");

	}

	public bool PlaceMove(int input, char player)
	{
		if (input < 1 || input > 9) 
		{
			Console.WriteLine("Invalid move..");
			return false;
		}

		int row = (input - 1) / 3;
		int col = (input - 1) % 3;

    		if (Board[row, col] == ' ')
    		{
        		Board[row, col] = Char.ToUpper(player);
        		return true;
    		}
		
		Console.WriteLine("Invalid move..");
    		return false;
	}

	public bool CheckWin(char player)
	{
		player = Char.ToUpper(player);

		for (int i = 0; i < 3; i++)
		{
			if (Board[i,0] == player && Board[i,1] == player && Board[i,2] == player)
				return true; 

			if (Board[0,i] == player && Board[1,i] == player && Board[2,i] == player)
				return true; 
		}

		if 	((Board[0,0] == player && Board[1,1] == player && Board[2,2] == player) || 
			(Board[0,2] == player && Board[1,1] == player && Board[2,0] == player))
			return true;

		return false;
	}
}

class Player
{
	public char Char { get; set; }
	public int Score { get; set; }

	public Player()
	{
		Char = this.GetPiece();
		Score = 0;
	}

	public char GetPiece()
	{
		while(true)
		{	
			Console.Write("Which piece do you want to play as? [X | O]: ");
			string input = Console.ReadLine()!.Trim().ToLower();

			if(input.Length != 1 || input == null)
			{
				Console.WriteLine("Invalid Input.");
				continue;
			}

			switch(input) 
			{
				case "x": return 'x';
				case "o": return 'o';
				default:
					Console.WriteLine("Invalid input. Please enter 'X' or 'O'.");
					continue;

			}
		}
	}

	public int GetMove()
	{
		while(true)
		{
			Console.Write("Pick a square [1-9]: ");
			int n;
			if(Int32.TryParse(Console.ReadLine()!, out n))
			{
				if(n <= 9  && n >= 1)
				{
					return n;
				} else {
					Console.WriteLine("Please input a number between 1-9");
					continue;
				}
			} else {
				Console.WriteLine("Bad input, please input a number between 1-9");
			}
		}
	}
}

class Computer
{
	public char Char { get; set; }
	public int Score { get; set; }
	public Random Rand = new Random();

	public Computer(char c)

	{
		Score = 0;
		Char = (c == 'x' ? 'o' : 'x');
	}

	public int Move(char[,] board)
	{
		Console.Write("Computer thinking ...");
		
		for (int i = 0; i < 10; i++)
		{
			Console.Write("\b\b\b");
			Thread.Sleep(50);
			Console.Write(".");
			Thread.Sleep(50);
			Console.Write(".");
			Thread.Sleep(50);
			Console.Write(".");
		}
		
		List<int> spaces = new List<int>();

		for (int row = 0; row < 3; row++)
		{
			for (int col = 0; col < 3; col++)
			{
				if (board[row,col] == ' ')
				{
					int position = row * 3 + col + 1;
					spaces.Add(position);
				}
			}
		}

		int rIndex = Rand.Next(spaces.Count);
		return spaces[rIndex];


	}
}

class Program
{

	static void Main(string[] args)
	{
		var game = new Game();
		var player = new Player();
		var comp = new Computer(player.Char);

		bool playerTurn = (player.Char == 'x' ? true : false);
		bool validMove;
		char currentChar;
		int move;

		while(true)
		{
			validMove = false;
			currentChar = (playerTurn ? player.Char : comp.Char);
			
			while(!validMove)
			{
				game.DrawBoard(currentChar);
				if(playerTurn) 	{ move = player.GetMove(); } 
				else 		{ move = comp.Move(game.Board); }
				validMove = game.PlaceMove(move, currentChar);
			}

			game.Moves++;
			playerTurn = !playerTurn;
			
			if (game.CheckWin(currentChar))
			{
				game.DrawBoard(currentChar);
				Console.WriteLine($"{currentChar} wins!");
				return;
			} 
			else if (game.Moves == 9)
			{ 
				game.DrawBoard(currentChar);
				Console.WriteLine("Game is a draw!");
				return;
			}
		}
	}
}
