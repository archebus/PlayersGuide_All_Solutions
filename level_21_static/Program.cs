// Fin Fletchers Arrows
// - define arrow class, fields like fletching, length etc..
// - allow user to pick arrowhead, fletching, length and create new arrow.
// - getCost method should return the cost of the arrow.

// Arrow Factories
// - create static methods for specific arrows.

public enum Material {Steel,Wood,Obsidian};
public enum Fletching {Plastic,TurkeyFeathers,GooseFeathers};

public class Arrow
{
	public int Shaft { get; set; } = default!;
	public Material Material { get; set; } = default!;
	public Fletching Fletching { get; set; } = default!;

	public Arrow() {}

	public Arrow(int shaft, Material mat, Fletching fletch)
	{

		Shaft = shaft;
		Material = mat;
		Fletching = fletch;
	}

	public double GetCost()
	{
	
		double[] matCosts = { 10, 3, 5 };
		double[] fletchCosts = { 10, 5, 3 };

		double shaftCost = 0.05 * (double)this.Shaft;
		double matCost = matCosts[(int)this.Material];
		double fletchCost = fletchCosts[(int)this.Fletching];

		return shaftCost + matCost + fletchCost;
	}

	public static Arrow CreateEliteArrow()
	{
		return new Arrow(95, Material.Steel, Fletching.Plastic);
	}

	public static Arrow CreateBeginnerArrow()
	{
		return new Arrow(75, Material.Wood, Fletching.GooseFeathers);
	}

	public static Arrow CreateMarksmanArrow()
	{
		return new Arrow(65, Material.Steel, Fletching.GooseFeathers);
	}

	public static Arrow CreateCustomArrow()
	{
		
		Arrow arrow = new Arrow();

		Console.WriteLine("Build your arrow!");
		Console.Write("How long? [60 - 100] ");

		while(true)
		{
			arrow.Shaft = Int32.Parse(Console.ReadLine()!);

			if (arrow.Shaft >= 60 && arrow.Shaft <= 100)
			{
				break;
			}

			Console.WriteLine("Arrow must be between 60 & 100");
		}

		
		while(true)
		{
			Console.Write("Which material? [Steel, Wood, Obsidian] ");
			string matChoice = Console.ReadLine()!;

			switch (matChoice.ToLower())
			{
				case "steel": arrow.Material = Material.Steel; break;
				case "wood": arrow.Material = Material.Wood; break;
				case "obsidian": arrow.Material = Material.Obsidian; break;
				default: arrow.Material = Material.Wood; break;
			}

			if (Enum.IsDefined(typeof(Material), arrow.Material)) {break;}

			Console.WriteLine("Invalid material.");
		}

		while(true)
		{

			Console.Write("And lastly the fletching? [Plastic, Turkey, Goose] ");
			string fleChoice = Console.ReadLine()!;

			switch (fleChoice.ToLower())
			{
				case "plastic": arrow.Fletching = Fletching.Plastic; break;
				case "turkey": arrow.Fletching = Fletching.TurkeyFeathers; break;
				case "goose": arrow.Fletching = Fletching.GooseFeathers; break;
				default: arrow.Fletching = Fletching.GooseFeathers; break;
			}

			if (Enum.IsDefined(typeof(Fletching), arrow.Fletching)) {break;}

			Console.WriteLine("Invalid fletching.");
		}

		return arrow;
	}

}

class Program
{

	static void Main(string[] args)
	{
		
		var arrow = new Arrow();

		Console.WriteLine("-- ARROW SHOP --");
		Console.WriteLine("1. Beginner Arrow");
		Console.WriteLine("2. Marksman Arrow");
		Console.WriteLine("3. Elite Arrow");
		Console.WriteLine("4. Custom Arrow");
		Console.Write("What would you like? [1-4] ");

		int menuInput = Int32.Parse(Console.ReadLine()!);

		switch (menuInput)
		{
			case 1: arrow = Arrow.CreateBeginnerArrow(); break;
			case 2: arrow = Arrow.CreateMarksmanArrow(); break;
			case 3: arrow = Arrow.CreateEliteArrow(); break;
			case 4: arrow = Arrow.CreateCustomArrow(); break;
			default: 
				Console.WriteLine("Invalid input. Defaulting to beginner arrow.");
				arrow = Arrow.CreateBeginnerArrow();
				break;
		}

		Console.WriteLine($"------------------------");
		Console.WriteLine($"Your arrow:");
		Console.WriteLine($"Shaft: {arrow.Shaft}");
		Console.WriteLine($"Material: {arrow.Material}");
		Console.WriteLine($"Fletching: {arrow.Fletching}");
		Console.WriteLine($"------------------------");
		Console.WriteLine($"Cost: {arrow.GetCost()}gp");
	}
}
