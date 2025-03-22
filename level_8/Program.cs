// Defense of Consalas
// - Ask user for Row and Column
// - Use Console Colors
// - Change window title
// - Play a sound with Console.Beep

Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Red;
Console.Clear();
Console.Title = "Defense of Consalas";

int row = 0;
int column = 0;

while (true) {
	
	Console.Write("Target Row? ");
	row = Int32.Parse(Console.ReadLine()!);
	Console.Write("Target Column? ");
	column = Int32.Parse(Console.ReadLine()!);

	if (column < 1 || column > 8 ||	row < 1 ||row > 8 ) 
	{	
		Console.WriteLine("Targets must be within 1 and 8");
		Console.ReadKey(true);
		Console.Clear();
		continue;
	}

	break;
}

Console.Beep();

Console.WriteLine("Deply to:");
Console.WriteLine($"({row + 1}, {column})");
Console.WriteLine($"({row}, {column + 1})");
Console.WriteLine($"({row - 1}, {column})");
Console.WriteLine($"({row}, {column - 1})");
