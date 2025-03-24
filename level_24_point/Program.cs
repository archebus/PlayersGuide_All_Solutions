// The Point
// - Define a point class with X and Y
// - Make a constructor to create a point with specific X & Y
// - Paramaterless constructor should init (0,0)
// - In main make a default point, and points (2,3) and (-4,0)
// - Points should be immutable
// - Points should output to the console with the above format

class Point
{
	public int X { get; }
	public int Y { get; }

	public Point() 
	{
		X = 0;
		Y = 0;
	}

	public Point(int x, int y)
	{
		X = x;
		Y = y;
	}

	public override string ToString()
	{
		return $"({X}, {Y})";
	}
}

class Program
{

	static void Main(string[] args)
	{
		var aPoint = new Point();
		var bPoint = new Point(2,3);
		var cPoint = new Point(-4,0);

		Console.WriteLine(aPoint);
		Console.WriteLine(bPoint);
		Console.WriteLine(cPoint);
	}

}
