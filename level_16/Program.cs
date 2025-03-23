// Simula's Test
// - Define an enumeration for the state of the chest.
// - Make a vriable whose type is the enum.
// - Write a function to manipulate the chests "state".
// - Loop forever (I will actually make an exit command).

class Program
{

	enum Chest
	{
		Locked,
		Closed,
		Open
	}

	static Chest LockChest(Chest userChest) 
	{
		switch(userChest)
		{
			case Chest.Locked:
				Console.WriteLine("Chest already locked!");
				return userChest;
			case Chest.Closed:
				Console.WriteLine("Chest has been locked.");
				return userChest = Chest.Locked;
			case Chest.Open:
				Console.WriteLine("Please close chest before locking.");
				return userChest;
			default:
				Console.WriteLine("Something wen't wrong.");
				return userChest;
		}
	}

	static Chest UnlockChest(Chest userChest) 
	{	
		switch(userChest)
		{
			case Chest.Locked:
				Console.WriteLine("Chest has been unlocked!");
				return userChest = Chest.Closed;
			case Chest.Closed:
				Console.WriteLine("Chest is already unlocked.");
				return userChest;
			case Chest.Open:
				Console.WriteLine("Chest is already open & unlocked!");
				return userChest;
			default:
				Console.WriteLine("Something wen't wrong.");
				return userChest;
		}
	}

	static Chest OpenChest(Chest userChest) 
	{	
		switch(userChest)
		{
			case Chest.Locked:
				Console.WriteLine("Chest is locked!");
				return userChest;
			case Chest.Closed:
				Console.WriteLine("Chest has been opened.");
				return userChest = Chest.Open;
			case Chest.Open:
				Console.WriteLine("Chest is already open.");
				return userChest;
			default:
				Console.WriteLine("Something wen't wrong.");
				return userChest;
		}
	}

	
	static Chest CloseChest(Chest userChest) 
	{	
		switch(userChest)
		{
			case Chest.Locked:
				Console.WriteLine("Chest already closed!");
				return userChest;
			case Chest.Closed:
				Console.WriteLine("Chest already closed!");
				return userChest;
			case Chest.Open:
				Console.WriteLine("Chest has been closed.");
				return userChest = Chest.Closed;
			default:
				Console.WriteLine("Something wen't wrong.");
				return userChest;
		}
	}

	static void Main(string[] args) 
	{
		Chest myChest = Chest.Locked;
		
		// Main Loop
		while(true)
		{
			
			Console.Write($"The chest is {myChest}. What do you want to do? ");
			string userCommand = Console.ReadLine()!;

			switch (userCommand.ToLower())
			{
				case "unlock":
					myChest = UnlockChest(myChest);
					break;
				case "lock":
					myChest = LockChest(myChest);
					break;
				case "close":
					myChest = CloseChest(myChest);
					break;
				case "open":
					myChest = OpenChest(myChest);
					break;
				default:
					Console.WriteLine("Unrecognised command...");
					break;
			}

		}

	}

}
