// Write a program that takes in a triangles base size and height.
// The compute the area of the triangle and output to console.

// Create a program that lets the user input number of eggs gathered.
// Using / and % compute how many eggs each sister should get and how many are left.

// Final task is to calculate realm "points" using simple addition and multiplications.

const int SISTERS = 4;

// Computer triangle area task.
double triangleArea(int width, int height) {
	double area = (width * height) / 2.0;
	return area;
}

// Compute sisters eggs with remainder.
void duckEggs(int sisters, int eggs) {

	Console.WriteLine($"Each sister gets {eggs / sisters} eggs.");
	Console.WriteLine($"And the duck gets {eggs % sisters} eggs.");
}


// Realm total calculation.
int realmValue(int estates, int duchies, int provinces) {
	return estates + (duchies * 3) + (provinces * 6);
}

triangleArea(0,0);
duckEggs(SISTERS,0);

Console.WriteLine("How many estates?");
int estates = Int32.Parse(Console.ReadLine()!);

Console.WriteLine("How many duchies?");
int duchies = Int32.Parse(Console.ReadLine()!);

Console.WriteLine("How many provinces?");
int provinces = Int32.Parse(Console.ReadLine()!);

Console.WriteLine($"Your realm is valued at {realmValue(estates,duchies,provinces).ToString()}");
