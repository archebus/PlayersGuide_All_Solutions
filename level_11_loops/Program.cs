// The Prototype
// - User enters a number
// - If number is outside of 1 - 100 guess again
// - Randomly generate a number between 1-100
// - Compare and tell user if number too high or low
// - Loop until correct.

// Magic Cannon
// - Loop through cannon shots 1 - 100.
// - Every third shot = fire shot.
// - Every fifth shot = electric shot.
// - Fire & electric shot = combined shot.
// - Otherwise normal shot.
// - Also change the color of the text when the shot is "special".


void magicCannon() {

	string shotType;
	ConsoleColor fire = ConsoleColor.Red;
	ConsoleColor electric = ConsoleColor.Yellow;
	ConsoleColor combined = ConsoleColor.Magenta;
	ConsoleColor normal = ConsoleColor.White;

	for (int i=1;i<101;i++) {
		
		ConsoleColor shotColor;

		if (i % 3 == 0 && i % 5 == 0) 	{shotType = "Combined"; shotColor = combined;} 
		else if (i % 3 == 0) 		{shotType = "Fire"; shotColor = fire;} 
		else if (i % 5 == 0) 		{shotType = "Electric"; shotColor = electric;} 
		else 				{shotType = "Normal"; shotColor = normal;}

		Console.Write($"{i}: "); 
		Console.ForegroundColor = shotColor;
		Console.WriteLine(shotType);
		Console.ResetColor();

	}
}


void thePrototype() {

	Random r = new Random();
	int target = r.Next(100)+1;

	int uGuess = 0;

	Console.WriteLine("Guess the number! (1-100)");

	while (uGuess != target) {
				
		Console.Write("Guess: ");
		uGuess = Int32.Parse(Console.ReadLine()!);

		if (uGuess > target) {
			Console.WriteLine("Too High!");
		} else if (uGuess < target) {
			Console.WriteLine("Too Low!");
		} else if (uGuess == target) {
			Console.WriteLine("GOT IT!!");
			break;
		} else {
			Console.WriteLine("Something went wrong.");
		}
	}
}

//thePrototype();
magicCannon();
