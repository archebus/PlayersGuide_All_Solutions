// Repairing the clock-tower.
// - Take a number from the console.
// - Display the word tick if its even.
// - Display tock if it's odd.

// Watchtower
// - Ask the user for an x or y value (co-ords).
// - Output enemy cardinal directions based on classical x-y grid.
// - E.g. --> (1,1) enemy to the North East.

void tickTock() {
	while (true)
	{
		Console.Write("Enter a number: ");
		int num = Int32.Parse(Console.ReadLine()!);

		if (num % 2 == 0) {
			Console.WriteLine("Tick");
		} else {
			Console.WriteLine("Tock");
		}
	}
}

void watchtower() {
	
	Console.Write("Input x co-ord: ");
	int x = Int32.Parse(Console.ReadLine()!);
	Console.Write("Input y co-ord: ");
	int y = Int32.Parse(Console.ReadLine()!);

	string horizontalDirection = (x > 0) ? "East" : (x < 0) ? "West" : "";
        
        string verticalDirection = (y > 0) ? "North" : (y < 0) ? "South" : "";

        string direction = "";

        if (horizontalDirection != "" && verticalDirection != "")
        {
            direction = $"{verticalDirection} {horizontalDirection}";
        }
        else if (horizontalDirection != "")
        {
            direction = horizontalDirection;
        }
        else if (verticalDirection != "")
        {
            direction = verticalDirection;
        }
        else
        {
            direction = "here";
        }

        // Output
        Console.WriteLine($"Enemy is {direction}");
	
}

watchtower();
