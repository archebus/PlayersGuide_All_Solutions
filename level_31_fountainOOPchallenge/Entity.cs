namespace Fountain.Models
{
	// Records for data a transfer between classes.
	public record Position(int X, int Y);
	public record Command(string Verb, string Noun);

	public class Player
	{
		public Position Pos { get; set; } = default!;
		public bool Alive { get; set; } = true;
		public bool Victory { get; set; } = false;
		public Room CurrentRoom { get; set; } = default!;

		public Player(Dungeon level)
		{
			Pos = level.RefEntrance.Pos;
			CurrentRoom = level.RefEntrance;
		}

		public void Sense(Dungeon level)
		{
			Position[] adjSquares =
			{
				new Position(Pos.X+1,Pos.Y),
				new Position(Pos.X-1,Pos.Y),
				new Position(Pos.X,Pos.Y+1),
				new Position(Pos.X,Pos.Y-1),
			};

			foreach(Position p in adjSquares)
			{
				if(level.CheckValidPos(p))
				{
					Display.LevelOutput(level.GetRoom(p));
				}
			}
		}

		public string GetInput()
		{
			Console.Write("What do you want to do? > ");
			return Console.ReadLine()?.Trim().ToLower() ?? "";
		} 

		public Command? ParseInput(string input)
		{
			if (string.IsNullOrWhiteSpace(input)) return null;

			var parts = input.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length == 0) return null;

			var Verb = parts[0];
			var Noun = parts.Length > 1 ? parts[1] : "";

			return new Command(Verb, Noun);
		}

		public void Action(Command c, Dungeon level)
		{
			switch(c.Verb)
			{
				case "move":
					Move(c.Noun, level);
					break;
				case "enable":
					CurrentRoom.Enable();
					break;
				case "exit":
					Exit(level);
					break;
				default:
					Console.WriteLine("Unknown command.");
					break;	
			}
		}

		public void Move(string dir, Dungeon level)
		{
			Position desiredPos;

			switch(dir)
			{
				case "north":
					desiredPos = new Position(Pos.X,Pos.Y+1);
					break;
				case "south":
					desiredPos = new Position(Pos.X,Pos.Y-1);
					break;
				case "east":
					desiredPos = new Position(Pos.X+1,Pos.Y);
					break;
				case "west":
					desiredPos = new Position(Pos.X-1,Pos.Y);
					break;
				default:
					Console.WriteLine("Unrecognized direction");
					return;
			}
			
			if(level.CheckValidPos(desiredPos))
			{
				Pos = desiredPos;
				CurrentRoom = level.Rooms[Pos.X,Pos.Y];
				CurrentRoom.Enter(this);
				return;
			}

			Console.WriteLine("You cannot move that way");
		}

		public void Exit(Dungeon level)
		{
			if(CurrentRoom is Entrance && level.RefFountain.Enabled)
			{
				Console.WriteLine("You've escaped the dungeon!");
				Victory = true;
			}
		}
	}
}
