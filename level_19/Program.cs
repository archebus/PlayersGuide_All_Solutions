// Fin Fletchers Arrows
// - define arrow class, fields like fletching, length etc..
// - allow user to pick arrowhead, fletching, length and create new arrow.
// - getCost method should return the cost of the arrow.

public enum Material {Steel,Wood,Obsidian};
public enum Fletching {Plastic,TurkeyFeathers,GooseFeathers};

public class Arrow
{


	private int _shaft = default!;
	private Material _material = default!;
	private Fletching _fletching = default!;

	public int GetShaft => _shaft;
	public void SetShaft(int shaft) { _shaft = shaft; }

	public Material GetMaterial => _material;
	public void SetMaterial(Material mat) { _material = mat; }

	public Fletching GetFletching => _fletching;
	public void SetFletching(Fletching fletch) { _fletching = fletch; } 


	public Arrow() {}

	public Arrow(int shaft, Material mat, Fletching fletch)
	{

		_shaft = shaft;
		_material = mat;
		_fletching = fletch;
	}

	public double GetCost()
	{
		double shaftCost, matCost, fletchCost = default!;
		
		double[] matCosts = { 10, 3, 5 };
		double[] fletchCosts = { 10, 5, 3 };

		shaftCost = 0.05 * (double)_shaft;
		matCost = matCosts[(int)_material];
		fletchCost = fletchCosts[(int)_fletching];

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
			arrow.SetShaft(Int32.Parse(Console.ReadLine()!));

			int arrowShaft = arrow.GetShaft;

			if (arrowShaft >= 60 && arrowShaft <= 100)
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
				case "steel": arrow.SetMaterial(Material.Steel); break;
				case "wood": arrow.SetMaterial(Material.Wood); break;
				case "obsidian": arrow.SetMaterial(Material.Obsidian); break;
				default: arrow.SetMaterial(Material.Wood); break;
			}

			if (Enum.IsDefined(typeof(Material), arrow.GetMaterial)) {break;}

			Console.WriteLine("Invalid material.");
		}

		while(true)
		{

			Console.Write("And lastly the fletching? [Plastic, Turkey-Feather, Goose-Feather] ");
			string fleChoice = Console.ReadLine()!;

			switch (fleChoice.ToLower())
			{
				case "plastic": arrow.SetFletching(Fletching.Plastic); break;
				case "turkey": arrow.SetFletching(Fletching.TurkeyFeathers); break;
				case "goose": arrow.SetFletching(Fletching.GooseFeathers); break;
				default: arrow.SetFletching(Fletching.GooseFeathers); break;
			}

			if (Enum.IsDefined(typeof(Fletching), arrow.GetFletching)) {break;}

			Console.WriteLine("Invalid fletching.");
		}

		Console.WriteLine($"------------------------");
		Console.WriteLine($"Your arrow:");
		Console.WriteLine($"Shaft: {arrow.GetShaft}");
		Console.WriteLine($"Material: {arrow.GetMaterial}");
		Console.WriteLine($"Fletching: {arrow.GetFletching}");
		Console.WriteLine($"------------------------");
		Console.WriteLine($"Cost: {arrow.GetCost()}gp");
	}
}

