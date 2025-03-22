// Buying Inventory
// - Output the menu from the book.
// - User to enter a number from the menu.
// - Show the items cost using switch.

// Discounted Inventory
// - Modify inventory to also ask for users name.
// - If their name == Josh divide cost in half.


Console.WriteLine("Welcome to my ShoP!");
Console.Write("So what's your name? ");
string name = Console.ReadLine()!;

// Items

Console.WriteLine("The following items are available:");
Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing Equipment");
Console.WriteLine("4 - Clean Water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food Supplies");
Console.Write("What do you want to see the price of [1-7]: ");

int selection = Int32.Parse(Console.ReadLine()!);

while (selection < 1 || selection > 7) {
	Console.WriteLine("Please keep selecting in range 1-7");
	selection = Int32.Parse(Console.ReadLine()!);
}

decimal[] prices = [10m,15m,25m,1m,20m,200m,1m];

Console.WriteLine($"Great, that will be {((name.ToLower() == "josh") ? prices[(selection-1)]/2m : prices[selection-1])} gold");
