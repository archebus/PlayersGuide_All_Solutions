class Program {

	static Random rand = new Random();

	static int GetEnemyDistance() 
	{
		return rand.Next(100)+1;
	}

	static void OutputGameScreen(int r, int ch, int mh, int cd) 
	{
	    Console.WriteLine($"------------------------------------------------------");

	    Console.Write($"STATUS | Round : {r} | City : ");
	    SetHealthColor(ch, 10, 5);
	    Console.Write($"{ch}/15");
	    Console.ResetColor();

	    Console.Write(" | Manticore : ");
	    SetHealthColor(mh, 6, 3);
	    Console.WriteLine($"{mh}/10");
	    Console.ResetColor();

	    Console.WriteLine($"The Cannon is expected to deal {cd} damage this round.");
	    Console.Write($"Enter desired cannon range: ");
	}

	static void SetHealthColor(int health, int yellowThreshold, int redThreshold) 
	{
	    if (health < redThreshold) 
		Console.ForegroundColor = ConsoleColor.Red;
	    else if (health < yellowThreshold) 
		Console.ForegroundColor = ConsoleColor.Yellow;
	    else 
		Console.ForegroundColor = ConsoleColor.White;
	}

	static int GetCannonDamage(int round)
	{
		if (round % 5 == 0 && round % 3 == 0) 	{return 10;}
		if (round % 5 == 0 || round % 3 == 0)	{return 3;}
		else					{return 1;}
	}

	static int GetPlayerGuess()
	{
		int num;
		while(true)
		{
			if (int.TryParse(Console.ReadLine()!, out num)) {
				if (num >= 1 && num <= 100) {
					return num;
				}
			}
			Console.WriteLine("Invalid input. Please input valid number 1-100");
		}
	}

	static bool CheckHit(int guess, int dist, int dam)
	{
		if (guess > dist) {
			Console.WriteLine("That round OVERSHOT the target.");
			return false;
		}
		if (guess < dist) {
			Console.WriteLine("That round FELL SHORT of the target.");
			return false;
		}
		if (guess == dist) {
			Console.WriteLine($"DIRECT HIT!!, {dam} damage dealt.");
			return true;
		}
		return false;
	}


	static void Main(string[] args) {
		
		int round = 1;
		int city_health = 15;
		int manticore_health = 10;
		int cannon_damage, player_guess;
		int enemy_distance = GetEnemyDistance();

		Console.WriteLine("The Manticore Approaches, dial the in the cannon range (1-100)");

		while(true)
		{

			cannon_damage = GetCannonDamage(round);

			OutputGameScreen(round, city_health, manticore_health, cannon_damage);
			
			player_guess = GetPlayerGuess();

			city_health--;

			if (CheckHit(player_guess, enemy_distance, cannon_damage))
			{
				manticore_health -= cannon_damage;
			}

			if (manticore_health <= 0) 
			{
				Console.WriteLine("You Win!");
				break;
			}
			
			if (city_health <= 0)
			{
				Console.WriteLine("You Lose :(");
				break;
			}

			round++;
		}
	}
}
