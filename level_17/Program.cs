// Simulas Soup
// - Define enums for three variations of food (type, main ing. & seasoning).
// - Make a tuple variation to represent a soup composed of the above.
// - Let the user pick ingredients from the menu.
// - When done, display the name of the soup.

class Program
{
	enum Meal {Soup,Stew,Gumbo}
	enum Ingredient {Mushroom,Chicken,Carrot,Potato}
	enum Seasoning {Spicy,Salt,Sweet}

	static Meal ChooseMeal()
	{
		Console.WriteLine("Please choose the type of meal you want:");
		Console.WriteLine("1. Soup");
		Console.WriteLine("2. Stew");
		Console.WriteLine("3. Gumbo");

		int choice = Int32.Parse(Console.ReadLine()!);

		return choice switch
		{
			1 => Meal.Soup,
			2 => Meal.Stew,
			3 => Meal.Gumbo,
			_ => throw new ArgumentException("Invalid choice!")
		};
	}

	static Ingredient ChooseIngredient()
	{
		Console.WriteLine("Choose an ingredient:");
		Console.WriteLine("1. Mushrooms");
		Console.WriteLine("2. Chicken");
		Console.WriteLine("3. Carrots");
		Console.WriteLine("4. Potatoes");

		int choice = Int32.Parse(Console.ReadLine()!);

		return choice switch
		{
			1 => Ingredient.Mushroom,
			2 => Ingredient.Chicken,
			3 => Ingredient.Carrot,
			4 => Ingredient.Potato,
			_ => throw new ArgumentException("Invalid choice!")
		};
	}

	static Seasoning ChooseSeasoning()
	{
		Console.WriteLine("Choose a seasoning:");
		Console.WriteLine("1. Spicy");
		Console.WriteLine("2. Salt");
		Console.WriteLine("3. Sweet");

		int choice = Int32.Parse(Console.ReadLine()!);

		return choice switch
		{
			1 => Seasoning.Spicy,
			2 => Seasoning.Salt,
			3 => Seasoning.Sweet,
			_ => throw new ArgumentException("Invalid choice!")
		};
	}

	static void Main()
	{
		// Define tuple with named elements
		(Meal Type, Ingredient MainIngredient, Seasoning Flavor) mySoup;

		mySoup.Type = ChooseMeal();
		mySoup.MainIngredient = ChooseIngredient();
		mySoup.Flavor = ChooseSeasoning();

		Console.WriteLine($"\nYour Meal: {mySoup.Flavor} {mySoup.MainIngredient} {mySoup.Type}!");
	}
}

