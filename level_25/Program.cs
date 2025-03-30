// Packing Inventory
// - Create InvItem class rep any type of object (weight + volume).
// - Create derived classes for Arrow, Bow, Rope, Water, Food, Sword.
// - Create a pack that can store an array of items, it should have a max volume and weight allowed.
// - Make a public bool add (item) to pack class, it should fail it item would exceed volume or weight.
// - Create a menu that allows the user to add or remove the items above from the pack.

class InvItem
{
	public double Weight { get; set; }
	public double Volume { get; set; }
}

class Arrow : InvItem
{
	public Arrow()
	{
		Weight = 0.1;
		Volume = 0.05;
	}
}

class Bow : InvItem
{
	public Bow()
	{
		Weight = 1;
		Volume = 4;
	}
}

class Rope : InvItem
{
	public Rope()
	{
		Weight = 1;
		Volume = 1.5;
	}
}

class Water : InvItem
{
	public Water()
	{
		Weight = 2;
		Volume = 3;
	}
}

class Food : InvItem
{
	public Food()
	{
		Weight = 1;
		Volume = 0.5;
	}
}

class Sword : InvItem
{
	public Sword()
	{
		Weight = 5;
		Volume = 3;
	}
}

class Pack
{
	public InvItem[] Items { get; set; } = default!;
	public double CurrentWeight { get; set; }
	public double CurrentVolume { get; set; }

	private double _maxWeight;
	private double _maxVolume;

	public Pack()
	{
		Items = new InvItem[20];

		CurrentWeight = 0;
		CurrentVolume = 0;

		_maxWeight = 10;
		_maxVolume = 10;
		
	}

	public bool Add(InvItem item)
	{
		
		// Will item fit?
		if	(CurrentWeight + item.Weight > _maxWeight ||
			 CurrentVolume + item.Volume > _maxVolume)
			{ return false; }
		
		// If so: add the item.
		for(int i = 0; i < Items.Length; i++)
		{
			if(Items[i] == null)
			{
				Items[i] = item;
				CurrentWeight += item.Weight;
				CurrentVolume += item.Volume;
				return true;
			}
		}

		return false;
	}
}

class Program
{
	static void Main(string[] args)
	{
		var pack = new Pack();
		bool exit = false;

		while(!exit)
		{
			Console.Clear();
			Console.WriteLine($"Put an item in the bag?");
			Console.WriteLine($"W: {pack.CurrentWeight} | V: {pack.CurrentVolume}");
			Console.WriteLine($"1. Arrow");
			Console.WriteLine($"2. Bow");
			Console.WriteLine($"3. Rope");
			Console.WriteLine($"4. Water");
			Console.WriteLine($"5. Food");
			Console.WriteLine($"6. Sword");
			Console.WriteLine($"7. [ EXIT PROGRAM ]");
			Console.Write("What will you add? ");
			
			int choice;
			bool success = false;

			if(Int32.TryParse(Console.ReadLine()!, out choice))
			{
				switch(choice)
				{
					case 1: success = pack.Add(new Arrow()); break;
					case 2: success = pack.Add(new Bow()); break;
					case 3: success = pack.Add(new Rope()); break;
					case 4: success = pack.Add(new Water()); break;
					case 5: success = pack.Add(new Food()); break;
					case 6: success = pack.Add(new Sword()); break;
					case 7: exit = true; break;
					default:
						Console.WriteLine("Out of menu range");
						Thread.Sleep(1000);
						break;
				}

				if(success)
				{
					Console.WriteLine("Item added to bag!");
				} 
				else if(!success)
				{
					Console.WriteLine("The item does not fit...");
				}

				Thread.Sleep(1000);
			}
		}
	}
}
