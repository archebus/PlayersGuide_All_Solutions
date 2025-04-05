// Fountain of Objects (Large project challenge)
// - Fountain = rooms, grid, player, pit.


// DISPLAY HELPER CLASS FOR MAIN --------------------
public static class Display
{
	public static void GameScreen(Room room, Player player)
	{
		Console.WriteLine($"--------------------------------------------------");
		Console.WriteLine($"You are in the room at (Row: {player.Pos.X}, Col: {player.Pos.Y}");
		if (room.GetType() != typeof(Room))
		{ 
			Console.WriteLine($"{room.Description}");
		}
		Console.Write($"What do you want to do? ");
	}
}
// ---------------------------------------------------


// ROOM DEFS -----------------------------------------
public class Room 
{
	public string Description { get; set; } = string.Empty;
}

public class Entrance : Room
{
	public Entrance() { Description = "You see light coming from the cavern entrance."; }
}

public class Pit : Room 
{
	public Pit() { Description = "A pit opens up, you fall to your Death!"; }
}

public class Fountain : Room 
{
	public Fountain() { Description = "You hear water dripping in this room. The fountain is here!"; }
}
// ---------------------------------------------------


// PLAYER DEFS ---------------------------------------
public record Position(int X, int Y);

public class Player
{
	public Position Pos { get; set; } = default!;
	public bool Alive { get; set; } = true;

	public Player()
	{
		Pos = new Position(0,0);
	}

	public bool Command() { } // Look up string manipulation --> need to break verb and noun into 2 sep strings. Parse verb, and noun seperatly. Call helper methods.

}
// ---------------------------------------------------


// DUNGEON DEFS --------------------------------------
public class Dungeon
{
	public Room[,] Rooms { get; set; }

	public Dungeon()
	{
		Rooms = new Room[4,4];		// Starting 4x4, expand this to be variable with diff.
		InitRooms();
	}

	public Room GetRoom(Position pos) => Rooms[pos.X,pos.Y];

	private void InitRooms()
	{
		Random rand = new Random();

		for (int i = 0; i < Rooms.GetLength(0); i++)
		{
			for (int j = 0; j < Rooms.GetLength(1); j++)
			{
				if (i == 0 && j == 0)
				{
					Rooms[i,j] = new Entrance();
					continue;
				}
				else if (i == 0 && j == 2)
				{
					Rooms[i,j] = new Fountain();
					continue;
				}
				int roomRoll = rand.Next(0,5);
				
				Rooms[i,j] = roomRoll == 1 ? new Pit() : new Room();
			}
		}
	}
}
// ---------------------------------------------------


class Program
{
	static void Main(string[] args)
	{
		Dungeon main = new Dungeon();
		Player p1 = new Player();
		
		while(p1.Alive)
		{
			Display.GameScreen(main.GetRoom(p1.Pos), p1);
		}
	}
}
