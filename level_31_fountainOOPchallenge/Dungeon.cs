namespace Fountain.Models
{
	public class Dungeon
	{
		public Room[,] Rooms { get; set; }
		public List<Entity> Enemies { get; set; } = new List<Entity>();
		private static Random rng = new Random();

		// References to common rooms (for ease of access)
		public Fountain RefFountain { get; set; } = default!;
		public Entrance RefEntrance { get; set; } = default!;
		
		public Dungeon(int diff)
		{
			Rooms = new Room[diff,diff];
			InitRooms(diff);
			InitEnemy(diff);
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
				default: pitCount = 0; break;
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

		private void InitEnemy(int diff)
		{
			int maelCount = 0;
			
			switch (diff)
			{
				case 4: maelCount = 0; break;
				case 6: maelCount = 1; break;
				case 8: maelCount = 2; break;
				default: maelCount = 0; break;
			}

			List<Position> occupied = new();
			Position placePos;

			for(int i = 0; i < maelCount; i++)
			{
				placePos = GetUniqueRandomPosition(occupied, diff);
				Enemies.Add(new Maelstrom(placePos, GetRoom(placePos)));
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
}
