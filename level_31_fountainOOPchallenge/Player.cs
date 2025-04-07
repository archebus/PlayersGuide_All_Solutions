namespace Fountain.Models
{
	public class Player : Entity
	{
		public bool Alive { get; set; } = true;
		public bool Victory { get; set; } = false;
		public string Weapon { get; set; } = "Bow";
		public int Arrows { get; set; }

		public Player(Dungeon level)
		{
			Pos = level.RefEntrance.Pos;
			CurrentRoom = level.RefEntrance;
			Arrows = 5;
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

		public bool Shoot(string dir, Dungeon level)
                {
                        Position? shootPos;
			Entity? deadEnemy;
			
			if(Arrows == 0)
			{
				Console.WriteLine("Your quiver is empty ...");
				return false;
			}
			
			Arrows--;
                        
                        switch(dir)
                        {
                                case "north":
                                        shootPos = new Position(Pos.X,Pos.Y-1);
                                        break; 
                                case "south":
                                        shootPos = new Position(Pos.X,Pos.Y+1);
                                        break;
                                case "east":
                                        shootPos = new Position(Pos.X+1,Pos.Y);
                                        break;
                                case "west":
                                        shootPos = new Position(Pos.X-1,Pos.Y);
                                        break;
                                default:
                                        Console.WriteLine("Unrecognized direction");
                                        return false;
                        }                                               
                        
                        if(shootPos == null)
                                return false;
                        
			if (level.CheckValidPos(shootPos))
    			{
        			deadEnemy = level.Enemies.FirstOrDefault(e => shootPos == e.Pos && e is ICanAttack);

        			if (deadEnemy != null)
        			{
            				Console.WriteLine("Your arrow strikes a creature.... ");
            				level.Enemies.Remove(deadEnemy);
					return true;
        			}
    			}                                                    
			else
			{
				Console.WriteLine("Your arrow strikes a wall");
				return false;
			}
                        
			Console.WriteLine("Your arrow sails into the darkness..");
                        return false;
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
					if(Move(c.Noun, level))
						CurrentRoom.Enter(this, level);
					else
						Console.WriteLine("You cannot move that way.");
					break;
				case "enable":
					CurrentRoom.Enable();
					break;
				case "exit":
					CurrentRoom.Exit(this, level);
					break;
				case "shoot":
					this.Shoot(c.Noun, level);
					break;
				case "help":
					Display.HelpScreen();
					break;
				default:
					Console.WriteLine("Unknown command.");
					break;	
			}
		}
	}
}
