namespace Fountain.Models
{
	public class Player : Entity
	{
		public bool Alive { get; set; } = true;
		public bool Victory { get; set; } = false;

		public Player(Dungeon level)
		{
			Pos = level.RefEntrance.Pos;
			CurrentRoom = level.RefEntrance;
		}

		public void Sense(Dungeon level)
		{
			Position[] adjSquares =
			{
				// Cardinals
				new Position(Pos.X+1,Pos.Y),
				new Position(Pos.X-1,Pos.Y),
				new Position(Pos.X,Pos.Y+1),
				new Position(Pos.X,Pos.Y-1),

				// Diagonals
				new Position(Pos.X+1,Pos.Y+1),
				new Position(Pos.X+1,Pos.Y-1),
				new Position(Pos.X-1,Pos.Y+1),
				new Position(Pos.X-1,Pos.Y-1),
			};
			
			foreach(Position p in adjSquares)
			{
    				if(level.CheckValidPos(p))
    				{
        				if (level.GetRoom(p) is ICanBeSensed sensedRoom)
        					Display.SenseOutput(sensedRoom);
        			}

				foreach(Entity e in level.Enemies)
				{
					if(e.Pos == p && e is ICanBeSensed sensedEnemy)
						Display.SenseOutput(sensedEnemy);
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
					PlayerMove(c.Noun, level);
					break;
				case "enable":
					CurrentRoom.Enable();
					break;
				case "exit":
					CurrentRoom.Exit(this, level);
					break;
				default:
					Console.WriteLine("Unknown command.");
					break;	
			}
		}
        
        	public void PlayerMove(string c, Dungeon level)
        	{
            		Position? desiredPos = Move(c, level);

            		if(desiredPos == null)
                		return;
            
            		if(level.CheckValidPos(desiredPos))
		    	{
				Pos = desiredPos!;
			    	CurrentRoom = level.Rooms[Pos.X,Pos.Y];
			    	CurrentRoom.Enter(this, level);
			    	return;
		    	}

			Console.WriteLine("You cannot move that way");
        	}
	}
}
