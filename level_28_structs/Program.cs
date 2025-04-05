// Room Co-ords
// - Create coord struct, room coord x and y.
// - Must be immutable.
// - Make method to determine if one cordinate is adjacent to another.
// - Main method that creates a few coords and determines if they are adjacent.

public struct Point
{
	public int X { get; }
	public int Y { get; }

	public Point(int x, int y)
	{
		X = x;
		Y = y;
	}

	public bool IsCardinalAdjacent(Point compare)		// Checks manhattan adjacency.
	{
		int dx = Math.Abs(this.X - compare.X);
		int dy = Math.Abs(this.Y - compare.Y);

		return (dx == 1 && dy == 0) || (dx == 0 && dy == 1);
	}

	public bool IsEightAdjacent(Point compare)		// Checks eight-directional adjacency.
	{
		int dx = Math.Abs(this.X - compare.X);
		int dy = Math.Abs(this.Y - compare.Y);

		return dx <= 1 && dy <= 1 && (dx + dy != 0);
	}

}



class Program
{
	static void Main(string[] args)
	{
		// Make some points
		Point alpha 	= new Point( 0, 0);
		Point beta 	= new Point(-1, 0);
		Point gamma 	= new Point( 1,-1);
		Point lambda	= new Point( 0, 1);

		// Check adjacency
		Console.WriteLine(alpha.IsCardinalAdjacent(beta));	// true
		Console.WriteLine(alpha.IsCardinalAdjacent(gamma));	// false
		Console.WriteLine(alpha.IsCardinalAdjacent(lambda));	// true
		Console.WriteLine(gamma.IsCardinalAdjacent(beta));	// false

		// Check adjacency
		Console.WriteLine(alpha.IsEightAdjacent(beta));		// true
		Console.WriteLine(alpha.IsEightAdjacent(gamma));	// true
		Console.WriteLine(alpha.IsEightAdjacent(lambda));	// true
		Console.WriteLine(gamma.IsEightAdjacent(beta));		// false
		
	}
}
