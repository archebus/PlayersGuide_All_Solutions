// Fin Fletchers ArrowsJOSHUA
// - define arrow class, fields like fletching, length etc..
// - allow user to pick arrowhead, fletching, length and create new arrow.
// - getCost method should return the cost of the arrow.

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

		this.Shaft = shaft;
		this.Material = mat;
		this.Fletching = fletch;
	}

	public double GetCost()
	{
		double shaftCost, matCost, fletchCost = default!;
		
		double[] matCosts = { 10, 3, 5 };
		double[] fletchCosts = { 10, 5, 3 };

		shaftCost = 0.05 * (double)this.Shaft;
		matCost = matCosts[(int)this.Material];
		fletchCost = fletchCosts[(int)this.Fletching];

		return shaftCost + matCost + fletchCost;
	}

}

class Program
{
	static void Main(string[] args)
	{
		
		var arrow = new Arrow();

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

			Console.Write("And lastly the fletching? [Plastic, Turkey-Feather, Goose-Feather] ");
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

		Console.WriteLine($"------------------------");
		Console.WriteLine($"Your arrow:");
		Console.WriteLine($"Shaft: {arrow.Shaft}");
		Console.WriteLine($"Material: {arrow.Material}");
		Console.WriteLine($"Fletching: {arrow.Fletching}");
		Console.WriteLine($"------------------------");
		Console.WriteLine($"Cost: {arrow.GetCost()}gp");
	}
}

