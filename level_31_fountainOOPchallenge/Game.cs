namespace Fountain.Models
{
	public class Game 
	{
		public int Difficulty { get; set; } = 0;
		public Player P1 { get; set; } = default!;
		public Dungeon Level { get; set; } = default!;

		public Game()
		{
			while(Difficulty == 0)
			{
				Display.DiffPrompt();
				Difficulty = GetDifficulty();
			}

			Level = new Dungeon(Difficulty);
			P1 = new Player(Level);
		}

		private int GetDifficulty()
		{
			Console.Write("> ");
			string input = Console.ReadLine()!;

			if (input == string.Empty || input.Length == 0) return 0;
			
			if (int.TryParse(input, out int number))
			{
				switch (number)
				{
					case 1: return 4;
					case 2: return 6;
					case 3: return 8;
					default:
					Console.WriteLine("Invalid Input");
						Console.ReadKey();
						return 0;
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a valid integer.");
				Console.ReadKey();
				return 0;
			}
		}

		public void Run()
		{
			if(P1 == null || Level == null)
			{
				Console.WriteLine("ERROR: Game init failed.");
				return;
			}

			Display.HelpScreen();

			string input;

			while(P1.Alive && !P1.Victory)
			{
				Display.GameScreen(Level.GetRoom(P1.Pos), P1);
				P1.Sense(Level);
				input = P1.GetInput();
				Command? command = P1.ParseInput(input);

				if (command != null)
				{
					P1.Action(command, Level);
				}
			}

			if (P1.Victory)
			Console.WriteLine("Congratulations! You've won!");
			else
			Display.ColorPrint("You have died ...", ConsoleColor.Red);
			Console.WriteLine("Game Over!");
		}
	}
}
