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
