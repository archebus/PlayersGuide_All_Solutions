// Write a program that uses Console.WriteLine at least 5 times.
// Write a program that takes in user input, and then outputs to the console.

void speakLots() {

	int i = 0;
	
	while (i < 5) {
		Console.WriteLine($"Hey I've said this {i} times");
		i++;
	}
}

void whoseBread() {
	Console.Write("Bread is ready!\nWho is the bread for?\n");
	string? name = Console.ReadLine();
	Console.Write($"Noted: {name} got some bread!\n");
}

whoseBread();

speakLots();
