namespace Fountain.Models
{
	public static class Display
	{
		public static ConsoleColor GoodNews = ConsoleColor.Blue;

		public static void SenseOutput(ICanBeSensed s)
		{
			var startColor = Console.ForegroundColor;
		    	Console.ForegroundColor = s.SenseColor;
    			Console.WriteLine(s.SenseDescription);
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
			Console.WriteLine($"You are in the room at (Row: {player.Pos.Y+1}, Col: {player.Pos.X+1})");
			Console.WriteLine($"Weapon: {player.Weapon}\tArrows: {player.Arrows}");
			if (room.GetType() != typeof(Room))
			{ 
				ColorPrint($"{room.Description}", GoodNews);
			}
		}

		public static void DiffPrompt()
		{
			Console.Clear();
			Console.WriteLine($"Choose a starting difficulty: ");
			Console.WriteLine($"1. Easy:\t[4x4] [2x pits] [0x maels] [1x beast]");
			Console.WriteLine($"2. Medium:\t[6x6] [3x pits] [1x maels] [1x beasts]"); 
			Console.WriteLine($"3. Hard:\t[8x8] [4x pits] [2x maels] [2x beasts]");
		}

		public static void HelpScreen()
        	{
            		Console.Clear();
            		Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with hazards in search of the Fountain of Objects.\n");
			Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
			Console.WriteLine("You must navigate the Caverns with your other senses.");
			Console.WriteLine("Use commands [move] [shoot] [enable] to interact with the dungeon.");
			Console.WriteLine("You can also combine the above with the 4 cardinal directions [north | south | east | west]");
			Console.WriteLine();
			ColorPrint("Your Goal: Find the Fountain of Objects, activate it, and return to the entrance.", GoodNews);
			Console.WriteLine();
			ColorPrint("HAZARDS: ", ConsoleColor.Red);
			Console.WriteLine("[PITS]\tYou will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.");
			Console.WriteLine("[MAELSTROMS]\tEntering a room with one will push you through the dungeon.");
			Console.WriteLine("[BEASTS]\tYou can smell their rotten stench in nearby rooms, you will die if you encounter one.");
			Console.WriteLine();
			Console.WriteLine("You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned: you have a limited supply.");
			Console.WriteLine();
			Console.WriteLine("Press any key to continue");
			Console.ReadKey(true);
        	}
	}
}
