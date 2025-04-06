namespace Fountain.Models
{
	public static class Display
	{
		public static ConsoleColor GoodNews = ConsoleColor.Blue;
		public static ConsoleColor BadNews = ConsoleColor.Red;
		public static ConsoleColor Enemy = ConsoleColor.DarkGreen;

		public static void LevelOutput(Room r)
		{
			ConsoleColor startColor = Console.ForegroundColor;
			
			if(r is Pit pit)
			{
                        	Console.ForegroundColor = BadNews;
                        	Console.WriteLine(pit.SenseDescription);
			}
			else if(r is Fountain fountain)
			{
                        	Console.ForegroundColor = GoodNews;
                        	Console.WriteLine(fountain.SenseDescription);
			}

                        Console.ForegroundColor = startColor;
		}

		public static void ColorPrint(string text, ConsoleColor c)
		{
			ConsoleColor startColor = Console.ForegroundColor;
			Console.ForegroundColor = c;
			Console.WriteLine(text);
			Console.ForegroundColor = startColor;
		}

		public static void GameScreen(Room room, Player player)
		{
			Console.WriteLine($"--------------------------------------------------");
			Console.WriteLine($"You are in the room at (Row: {player.Pos.X}, Col: {player.Pos.Y})");
			if (room.GetType() != typeof(Room))
			{ 
				ColorPrint($"{room.Description}", GoodNews);
			}
		}

		public static void DiffPrompt()
		{
			Console.Clear();
			Console.WriteLine($"Choose a starting difficulty: ");
			Console.WriteLine($"1. Easy:\t[4x4] [2x pits]");
			Console.WriteLine($"2. Medium:\t[6x6] [3x pits]"); 
			Console.WriteLine($"3. Hard:\t[8x8] [4x pits]");
		}
	}
}
