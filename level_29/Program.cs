// War Preperations
// - Create the enum for sword mats (book)
// - Gemstones can be attached to a sword (another enum.)
// - Create a SWORD record with mat, gem, length, crossguard width.
// - In main init a sword, iron no gem, then create two variations using "with"
// - Display all three swords with a simple pass of the pointer.


public enum SwordMat
{
	wood,
	bronze,
	iron,
	steel,
	binarium,
}

public enum SwordGem
{
	emerald,
	amber,
	sapphire,
	diamond,
	bitstone,
}

public record Sword(SwordMat material, SwordGem gem, float length, float crossWidth);


class Program
{
	static void Main(string[] args)
	{
		
		Sword sword1 = new Sword(SwordMat.iron, SwordGem.emerald, 10, 2);
		Sword sword2 = sword1 with { material = SwordMat.steel };
		Sword sword3 = sword1 with { material = SwordMat.binarium, gem = SwordGem.bitstone };

		Console.WriteLine($"{sword1}\n{sword2}\n{sword3}");

	} 
}
