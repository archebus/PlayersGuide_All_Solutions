// Password Validationa
// - Create a class that determines if a password is valid.
// - Rules:
// - Password must be >5 or <14 in length.
// - Password must contain one uppercase, one lowerase, on number.
// - Password must not contain an ampersand or a capital T

public static class Validator
{
	public static bool CheckLength(string pass)
	{
		if (pass.Length > 5 && pass.Length < 14) {return true;}
		
		Console.Write("Outside allowed length [6-14 length]");
		return false;
	}

	public static bool CheckUpper(string pass)
	{
		
		foreach (char l in pass)
		{
			if (char.IsUpper(l)) {return true;}
		}

		Console.Write("No uppercase char used.");
		return false;
	}

	public static bool CheckLower(string pass)
	{
		foreach (char l in pass)
		{
			if (char.IsLower(l)) {return true;}
		}

		Console.Write("No lowercase char used.");
		return false;
	}

	public static bool CheckNumber(string pass)
	{
		foreach (char l in pass)
		{
			if (char.IsDigit(l)) {return true;}
		}
		Console.Write("No number used.");
		return false;
	}

	public static bool CheckBanned(string pass)
	{
		foreach (char l in pass)
		{
			if (l == 'T' || l == '&') 
			{
				Console.Write("Banned character used [T / &]");
				return false;
			}
		}
		return true;
	}

	public static bool Check(string pass)
	{
		if (
			CheckLength(pass) &&
			CheckUpper(pass) &&
			CheckLower(pass) &&
			CheckNumber(pass) &&
			CheckBanned(pass)
		   )
		{ return true; }
		
		else

		{ return false; }
	
	}

}


class Program
{
	static void Main(string[] args)
	{
		Console.Write($" - {Validator.Check("password")}\n");
		Console.Write($" - {Validator.Check("anoohegl")}\n");
		Console.Write($" - {Validator.Check("UPPERCASE")}\n");
		Console.Write($" - {Validator.Check("w2xp9ptli9")}\n");
		Console.Write($" - {Validator.Check("Qhc2S2Y8uv1J")}\n");
		Console.Write($" - {Validator.Check("CRCbnkgJZPP4aRfp")}\n");
		Console.Write($" - {Validator.Check("11111111111111111111111111111")}\n");
	}

}
