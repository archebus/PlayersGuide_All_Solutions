// TO DO!!
// Implement players sense into main.
// Move game loop out of main into it's own class.


// Records for data a transfer between classes.
public record Position(int X, int Y);
public record Command(string Verb, string Noun);


// DISPLAY & GAME CLASS CLASS --------------------
public static class Display
{
	public static void GameScreen(Room room, Player player)
	{
		Console.WriteLine($"--------------------------------------------------");
		Console.WriteLine($"You are in the room at (Row: {player.Pos.X}, Col: {player.Pos.Y})");
		if (room.GetType() != typeof(Room))
		{ 
			Console.WriteLine($"{room.Description}");
		}
		Console.Write($"What do you want to do? ");
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

		string input;

		while(P1.Alive && !P1.Victory)
		{
			Display.GameScreen(Level.GetRoom(P1.Pos), P1);
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
		Console.WriteLine("Game Over!");
    }
}
// ---------------------------------------------------


// ROOM DEFS -----------------------------------------
public interface ICanBeSensed
{
    	string SenseDescription { get; }  
}

public class Room 
{
	public virtual string Description { get; set; } = string.Empty;

    	public virtual void Enter(Player player) { }

    	public virtual void Enable()
    	{
        	Console.WriteLine("There is nothing to enable here.");
    	}
}

public class Entrance : Room
{
    	public Position Pos { get; set; } = default!;

    	public Entrance(Position pos) 
    	{ 
        	Pos = pos;
        	Description = "You see light coming from the cavern entrance.";
    	}
}

public class Pit : Room, ICanBeSensed
{
    	public Pit() 
    	{ 
        	Description = "A pit opens up, you fall to your Death!";
    	}

    	public string SenseDescription => "You hear a soft whistling wind ... there is a pit nearby";

    	public override void Enter(Player player)
    	{
        	player.Alive = false;
        	Console.WriteLine("You fell in a pit and died.");
    	}
}

public class Fountain : Room, ICanBeSensed
{
	public bool Enabled { get; set; } = false;

    	public override string Description =>
        	Enabled
        	? "You hear water rushing from the fountain."
        	: "You hear water dripping in this room. The fountain is here!";

    	public string SenseDescription =>
        	Enabled
        	? "You hear water rushing nearby."
        	: "You hear water dripping softly ... The fountain is nearby!";

    	public override void Enable()
    	{
        	if (!Enabled)
        	{
            		Console.WriteLine("You have enabled the fountain.");
            		this.Enabled = true;
            		return;
        	}

        	Console.WriteLine("The fountain is already Enabled!");
    	}
}
// ---------------------------------------------------



// ENTITY DEFS ---------------------------------------
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
		Room senseMe;

		Position[] adjSquares =
		{
			new Position(Pos.X+1,Pos.Y),
			new Position(Pos.X-1,Pos.Y),
			new Position(Pos.X,Pos.Y+1),
			new Position(Pos.X,Pos.Y-1),
		};

		foreach(Position p in adjSquares)
		{
			senseMe = level.GetRoom(p);
			if(senseMe is ICanBeSensed sensed)
				Console.WriteLine(sensed.SenseDescription);
		}
	}

	public string GetInput()
	{
		Console.Write("> ");
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
// ---------------------------------------------------


// DUNGEON DEFS --------------------------------------
public class Dungeon
{
	public Room[,] Rooms { get; set; }
	private static Random rng = new Random();

	// References to common rooms (for ease of access)
	public Fountain RefFountain { get; set; } = default!;
	public Entrance RefEntrance { get; set; } = default!;
	
	public Dungeon(int diff)
	{
		Rooms = new Room[diff,diff];
		InitRooms(diff);
	}

	public Room GetRoom(Position pos) => Rooms[pos.X,pos.Y];

	private static int Rand(int maxReturn) => rng.Next(0, maxReturn);
	
	private void InitRooms(int diff)
	{
		int pitCount;

		switch (diff)
		{
			case 4: pitCount = 2; break;
			case 6: pitCount = 3; break;
			case 8: pitCount = 4; break;
			default: pitCount = 0; break; // Default to 0 pits if something unexpected happens
		}

		List<Position> occupied = new();

		Position entrancePos = GetUniqueRandomPosition(occupied, diff);
		Position fountainPos = GetUniqueRandomPosition(occupied, diff);

		while (entrancePos == fountainPos)
		{
			entrancePos = GetUniqueRandomPosition(occupied, diff);
		}

		for (int i = 0; i < Rooms.GetLength(0); i++)
		{
			for (int j = 0; j < Rooms.GetLength(1); j++)
			{
				Position currentPos = new Position(i, j);

				if (currentPos == entrancePos)
				{
		    			Rooms[i, j] = new Entrance(currentPos);
		    			RefEntrance = (Entrance)Rooms[i, j];
				}
				else if (currentPos == fountainPos)
				{
		    			Rooms[i, j] = new Fountain();
		    			RefFountain = (Fountain)Rooms[i, j];
				}
				else if (pitCount > 0 && Rand(5) == 1)
				{
		    			Rooms[i, j] = new Pit();
		    			pitCount--;
				}
				else
				{
		    			Rooms[i, j] = new Room();
				}
			}
		}
	}

    	private Position GetUniqueRandomPosition(List<Position> occupied, int diff)
    	{
        	Position pos;
        	do
        	{
			pos = new Position(Rand(diff), Rand(diff));
		}
		while (occupied.Contains(pos));

		occupied.Add(pos);
		return pos;
	}


	public bool CheckValidPos(Position pos)
	{	 
		return 
		pos.X >= 0 && pos.X < Rooms.GetLength(0) &&
		pos.Y >= 0 && pos.Y < Rooms.GetLength(1);
	}
}
// ---------------------------------------------------


class Program
{
	static void Main(string[] args)
	{
        Game game = new Game();
        game.Run();
	}
}
