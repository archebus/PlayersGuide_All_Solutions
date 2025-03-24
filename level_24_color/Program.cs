// The Color
// - Define a new color class for traditional RGB channels.
// - Add appropriate constructor
// - Create factory props to define the 8 common colors.
// - In main make two Colors, one with a constructor the other with a factory prop.

class Color
{
	public byte R { get; }
	public byte G { get; }
	public byte B { get; }

	public Color () {}

	public Color (byte red, byte green, byte blue)
	{
		R = red;
		G = green;
		B = blue;
	}

	public static Color ColorRed()		=> new Color(255,0,0);
	public static Color ColorGreen() 	=> new Color(0,255,0);
	public static Color ColorBlue() 	=> new Color(0,0,255);
	public static Color ColorYellow() 	=> new Color(255,255,0);
	public static Color ColorCyan() 	=> new Color(0,255,255);
	public static Color ColorMagenta() 	=> new Color(255,0,255);
	public static Color ColorBlack() 	=> new Color(255,255,255);
	public static Color ColorWhite() 	=> new Color(0,0,0);

	public override string ToString() { return $"({R}, {G}, {B})"; }

}

class Program
{
	static void Main(string[] args)
	{
		var color1 = new Color();
		var color2 = new Color(123,10,80);
		var color3 = Color.ColorRed();

		Console.Write($"{color1}\n{color2}\n{color3}\n");
	}
}
