// Colored Items
// - Put three class defs in (sword, axe, bow)
// - Define a generic class to represent a colored item.
// - Add a void display() method to your colored item class the changes the console color.
// - In your main create a new colored item containing a blue sword, red bow, green axe.
// - Display all three items to see their colors.

public class Weapon
{ 

	public override string ToString() => GetType().Name;

}

public class Sword : Weapon { }
public class Axe : Weapon { }
public class Bow : Weapon { } 

public class ColoredItem<T> where T : Weapon
{
	public T Item { get; set; } = default!;
	public ConsoleColor Color { get; set; }

	public ColoredItem(T item, ConsoleColor color)
	{
		Item = item;
		Color = color;
	}

	public void Display()
	{
		var startColor = Console.ForegroundColor;
		Console.ForegroundColor = Color;
		Console.WriteLine(Item);
		Console.ForegroundColor = startColor;
	}
}


class Program
{
	static void Main(string[] args)
	{
		var blueSword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
		var redBow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
		var greenAxe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);

		blueSword.Display();
		redBow.Display();
		greenAxe.Display();
	}
}
