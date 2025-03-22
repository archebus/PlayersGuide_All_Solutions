// The Replicator of D'To
// - Create an array length of 5
// - Prompt user for 5 numbers, store them in array.
// - Make second array length 5
// - Use loop to copy original array to new array.
// - Display contents of both arrays.

// The Laws of Freach
// - write a function that finds the smallest value in an array.
// - only use foreach loops.

int[] replicator(int[] uArray) {
	int[] copiedArray = new int[uArray.Length];

	for (int i = 0; i < uArray.Length; i++) {
		copiedArray[i] = uArray[i];
	}

	return copiedArray;
}

int findSmallest(int[] uArray) {
	int current = int.MaxValue;
	foreach (int value in uArray) {
		if (value < current) {
			current = value;
		}
	}
	return current;
}

int[] uArray = new int[5];

for (int i = 0; i < uArray.Length; i++) 
{
	Console.Write($"Enter #{i+1}: ");
	uArray[i] = Int32.Parse(Console.ReadLine()!);
}

int[] copiedArray = replicator(uArray);

for (int i = 0; i < uArray.Length; i++) 
{
	Console.WriteLine($"{uArray[i]} | {copiedArray[i]}");
}

Console.WriteLine($"The smallest value is {findSmallest(uArray)}");
