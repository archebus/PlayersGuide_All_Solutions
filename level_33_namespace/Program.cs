using IField;
using McDroid;

class Program
{
	static void Main(string[] args)
	{
		var IPig = new IField.Pig();
		var MPig = new McDroid.Pig();

		var Sheep = new Sheep();
		var Cow = new Cow();

		Console.Write($"{IPig}\n{MPig}\n{Sheep}\n{Cow}\n");
	}
}
