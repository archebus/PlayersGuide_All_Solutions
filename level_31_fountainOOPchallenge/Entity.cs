namespace Fountain.Models
{
	// Records for data a transfer between classes.
	public record Position(int X, int Y);
	public record Command(string Verb, string Noun);

	public interface ICanAttack
	{
		public void Attack(Player player, Dungeon level);
	}

    	public abstract class Entity
    	{
        	public Position Pos { get; set; } = default!;
		public Room CurrentRoom { get; set; } = default!;

        	public virtual bool Move(string dir, Dungeon level)
		{
			Position? desiredPos;

			switch(dir)
			{
				case "north":
					desiredPos = new Position(Pos.X,Pos.Y-1);
					break;
				case "south":
					desiredPos = new Position(Pos.X,Pos.Y+1);
					break;
				case "east":
					desiredPos = new Position(Pos.X+1,Pos.Y);
					break;
				case "west":
					desiredPos = new Position(Pos.X-1,Pos.Y);
					break;
				default:
					Console.WriteLine("Unrecognized direction");
					return false;
			}

                        if(desiredPos == null)
                                return false;
                        
                        if(level.CheckValidPos(desiredPos))
                        {                                               
                                Pos = desiredPos!;
                                this.CurrentRoom = level.Rooms[Pos.X,Pos.Y];
                                return true;
                        }

			return false;
		}
    	}
}
