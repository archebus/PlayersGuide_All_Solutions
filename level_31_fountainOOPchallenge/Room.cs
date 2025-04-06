namespace Fountain.Models
{
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
}
