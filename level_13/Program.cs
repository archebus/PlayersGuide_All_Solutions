// Take a number
// - make a method that takes a prompt for a number and returns an int.
// - override the method with a min and max value allowed for return.

// Countdown
// - Write code that counts down from 10 using recursion.
// - Ensure you include a base case that ends the recusion.

class Program {

	static int NumberAsk(string text) {
		
		Console.Write(text);
		return Int32.Parse(Console.ReadLine()!);
	}

	static int NumberAsk(string text, int min, int max) {
		
	    int num;
	    
	    while (true) {
		Console.Write(text);
		if (int.TryParse(Console.ReadLine(), out num)) {
		    if (num >= min && num <= max) {
			return num;
		    }
		    Console.WriteLine($"Number must be between {min} and {max}.");
		} else {
		    Console.WriteLine("Invalid input. Please enter a valid integer.");
		}
	    }

	}

	static void countdown (int n) {
		Console.WriteLine(n);
		if (n==0) {return;}
		countdown(n-1);
	}

	static void Main() {

		countdown(10);

		int aNum = NumberAsk("Give me a number: ", 10, 20);
		Console.WriteLine(aNum);

	}
}


