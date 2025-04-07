namespace Fountain.Models
{
	public interface ICanBeSensed
	{
		string SenseDescription { get; }
		ConsoleColor SenseColor { get; }
	}

	public class Room 
	{
		public virtual string Description { get; set; } = string.Empty;

		public virtual void Enter(Player player, Dungeon level) 
		{
			foreach(Entity e in level.Enemies)
			{
				if(player.Pos == e.Pos && e is ICanAttack validEnemy)
					validEnemy.Attack(player, level);
			}
		}

        	public virtual void Exit(Player player, Dungeon level)
        	{
            		Console.WriteLine("You cannot find any exit here."); 
        	}

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

        	public override void Exit(Player player, Dungeon level)
        	{
            		if(level.RefFountain.Enabled)
			{
				Console.WriteLine("You've escaped the dungeon!");
				player.Victory = true;
			}
            		else
            		{
                		Console.WriteLine("The exit is barred... you must find the fountain!");
            		}
        	}
	}

	public class Pit : Room, ICanBeSensed
	{
		public Pit() 
		{ 
			Description = ""; // This never gets read, player dies before Description is called.
		}

		public string SenseDescription => "You hear a soft whistling wind ... there is a pit nearby";
		public ConsoleColor SenseColor => ConsoleColor.Red;

		public override void Enter(Player player, Dungeon level)
		{
			Display.ColorPrint("A pit opens beneath you and you fall.", ConsoleColor.Red);
			player.Alive = false;
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

		public ConsoleColor SenseColor => ConsoleColor.Blue;

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
}
