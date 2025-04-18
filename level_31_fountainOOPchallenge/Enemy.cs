namespace Fountain.Models
{
	public class Maelstrom : Entity, ICanBeSensed, ICanAttack
	{
		public string SenseDescription => "You hear an angry gnashing wind nearby...";
		public ConsoleColor SenseColor => ConsoleColor.Magenta;

		public Maelstrom(Position startPos, Room startRoom)
		{
			Pos = startPos;
			CurrentRoom = startRoom;
		}

		public void Attack(Player player, Dungeon level)
		{
			Display.ColorPrint("You are buffeted by the maelstroms winds!", SenseColor);

			Position pushPos = new Position(player.Pos.X+1, player.Pos.Y+2);

			if(!level.CheckValidPos(pushPos))
			{
				Display.ColorPrint("You are slammed into the dungeon wall.", ConsoleColor.Red);
				player.Alive = false;
			}
			else
			{
				player.Pos = pushPos;

				var destRoom = level.GetRoom(pushPos);
				destRoom.Enter(player, level);

				this.Move("south", level);
			}
		}
	}

	public class Beast : Entity, ICanBeSensed, ICanAttack
	{
		public string SenseDescription => "You smell rotting flesh nearby ...";
		public ConsoleColor SenseColor => ConsoleColor.DarkGreen;

		public Beast(Position startPos, Room startRoom)
		{
			Pos = startPos;
			CurrentRoom = startRoom;
		}

		public void Attack(Player player, Dungeon level)
		{
			Display.ColorPrint("A beast lashes out from the shadows!", SenseColor);
			player.Alive = false;
		}
	}
}
