using System.Text;

public static class ClassTester
{
	//Random 
	static Random Rng { get; set; } = new Random();
	static Random RngSeed { get; set; } = new Random(5000);

	//Datetime
	static DateTime time1 { get; set; }
	static DateTime time2 { get; set; }

	//TimeSpan
	static TimeSpan timeSpan1 { get; set; } = new TimeSpan(1, 30, 0); 		// 1 hour, 30 minutes, 0 seconds.
	static TimeSpan timeSpan2 { get; set; } = new TimeSpan(2, 12, 0, 0); 		// 2 days, 12 hours.
	static TimeSpan timeSpan3 { get; set; } = new TimeSpan(0, 0, 0, 0, 500); 	// 500 milliseconds.
	static TimeSpan timeSpan4 { get; set; } = new TimeSpan(10); 			// 10 "ticks" == 1 microsecond

	//GUID
	static Guid id { get; } = Guid.NewGuid();
	
	//List
	static List<string> myList { get; set; } = new List<string>() { "apple", "banana", "corn", "durian" };

	//IEnumerable
	// - No practice code, just know that it allows the use of the foreach loop through enumerable methods.
	
	//Dictionary -- [key, value]
	static Dictionary<string, string> myDict { get; set; } = new Dictionary<string, string>();

	//Nullable<T> 
	static Nullable<int> maybeNumber = new Nullable<int>(3);
	static Nullable<int> another = new Nullable<int>();

	static int? maybeNumber2 = 3;
	static int? another2;

	//StringBuilder
	static StringBuilder stringer = new StringBuilder();

	public static void stringBuild()
	{
		while(true)
		{
			string? input = Console.ReadLine();
			if (input == null || input == "") break;
			stringer.Append(input);
			stringer.Append(' ');
		}
		Console.WriteLine(stringer.ToString());
	}

	public static void nullable()
	{
		Console.WriteLine(maybeNumber2);
		Console.WriteLine(another2);
	}

	public static void dictionary()
	{
		myDict["battleship"] = "a large warship with big guns";
		myDict["cruiser"] = "a fast but large warship";
		myDict["submarine"] = "a ship capable of moving under the water's surface";

		Console.WriteLine(myDict["cruiser"]);

		myDict["carrier"] = "a ship that carries stuff";
		myDict["carrier"] = "a ship that serves as a floating runway for aircraft";
		Console.WriteLine(myDict["carrier"]);

		Console.WriteLine(myDict.GetValueOrDefault("gunship", "unknown"));
	}

	public static void list()
	{
		myList.Add("pear");
		Console.WriteLine(myList.Contains("pear"));
		
		foreach (String s in myList)
		{
			Console.WriteLine(s);
		}
	}

	public static void guid()
	{
		Console.WriteLine(id);
	}

	public static void time()
	{
		Console.Write($"{timeSpan1}\n{timeSpan2}\n{timeSpan3}\n{timeSpan4}\n");
	}

	public static void rng()
	{
		Console.WriteLine(Rng.Next());
		Console.WriteLine(Rng.Next(6));
		Console.WriteLine(Rng.Next(6)+1);
		Console.WriteLine(Rng.Next(18, 22));
		Console.WriteLine(Rng.NextDouble());
		Console.WriteLine(Rng.NextDouble()*10);
		Console.WriteLine(Rng.NextDouble()*20-10);

		// Will always print the same.
		Console.WriteLine(RngSeed.Next());
		Console.WriteLine(RngSeed.Next(5));
	}

	public static void date()
	{
		time1 = new DateTime(2022, 12, 31);
		time2 = new DateTime();

		Console.WriteLine($"{time1}\n{time2}");
		Console.WriteLine(DateTime.Now);
		Console.WriteLine(DateTime.Now.AddDays(1));
	}
}

class Program
{
	static void Main(string[] args)
	{
		
		//ClassTester.rng();
		//ClassTester.date();
		//ClassTester.time();
		//ClassTester.guid();
		//ClassTester.list();
		//ClassTester.dictionary();
		//ClassTester.nullable();
		ClassTester.stringBuild();
	}
}
