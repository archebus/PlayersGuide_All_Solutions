// The Locked Door
// - class door that only unlocks with the right passcode
// - door has 3 states OPEN | CLOSED | LOCKED
// - methods for unlock, open, close and lock
// - the door requires an initial passcode when constructed
// - change code function if current code is supplied


public enum DoorState {Locked,Closed,Open}

public class Door
{
	public DoorState State { get; set; } = default!;
	public string Code { get; set; } = default!;

	public Door(string code)
	{
		State = DoorState.Locked;
		Code = code;
	}

	public void Open()
	{
		switch(State)
		{
			case DoorState.Locked:
				Console.WriteLine("Door is locked.");
				break;
			case DoorState.Closed:
				Console.WriteLine("Door opens!");
				State = DoorState.Open;
				break;
			case DoorState.Open:
				Console.WriteLine("Door is already open.");
				break;
			default:
				Console.WriteLine("Invalid Door State.");
				break;
		}
	}

	public void Close()
	{
		switch(State)
		{
			case DoorState.Locked:
				Console.WriteLine("Door is already closed.");
				break;
			case DoorState.Closed:
				Console.WriteLine("Door is already closed.");
				break;
			case DoorState.Open:
				Console.WriteLine("You close the door!");
				State = DoorState.Closed;
				break;
			default:
				Console.WriteLine("Invalid Door State.");
				break;
		}
	}

	public void Lock()
	{
		switch(State)
		{
			case DoorState.Locked:
				Console.WriteLine("Door is already locked.");
				break;
			case DoorState.Closed:
				Console.WriteLine("Door locks!");
				State = DoorState.Locked;
				break;
			case DoorState.Open:
				Console.WriteLine("Door is locked.");
				break;
			default:
				Console.WriteLine("Invalid Door State.");
				break;
		}
	}

	public void Unlock(string code)
	{
		switch(State)
		{
			case DoorState.Locked:
				if (code == Code)
				{
					Console.WriteLine("You unlocked the door!");
					State = DoorState.Closed;
					break;
				}
				Console.WriteLine("Invalid Code!");
				break;
			case DoorState.Closed:
				Console.WriteLine("Door is already unlocked.");
				break;
			case DoorState.Open:
				Console.WriteLine("Door is already open.");
				break;
			default:
				Console.WriteLine("Invalid Door State.");
				break;
		}
	}

	public void Change(string code)
	{
		if (code == Code)
		{
			Console.Write("New passcode? ");
			Code = Console.ReadLine()!;
			Console.WriteLine("Code changed!");
			return;
		}

		Console.WriteLine("Invalid code.");
		return;

	}


}

class Program
{
	static void Main(string[] args)
	{
		Console.Clear();
		var door = new Door("tits");
		string code;
		
		while(true)
		{
			Console.WriteLine($"The door is {door.State}");
			Console.WriteLine($"1. Lock Door");
			Console.WriteLine($"2. Unlock Door");
			Console.WriteLine($"3. Close Door");
			Console.WriteLine($"4. Open Door");
			Console.WriteLine($"5. Change Door Code");
			Console.WriteLine($"6. Leave");
			Console.Write("What should you do? ");

			int menuInput = Int32.Parse(Console.ReadLine()!);

			switch(menuInput)
			{
				case 1: door.Lock(); break;
				case 2: 
					Console.Write("Password? ");
					code = Console.ReadLine()!;
					door.Unlock(code); break;
				case 3: door.Close(); break;
				case 4: door.Open(); break;
				case 5: 
					Console.Write("Password? ");
					code = Console.ReadLine()!;
					door.Change(code); break;
				case 6: return;
				default: break;
			}

			Console.ReadKey(true);
			Console.Clear();
		}
	}
}
