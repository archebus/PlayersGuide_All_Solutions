// The Card
// - define enumurations for card color and card ranks.
// - colors = red, green, blue, yellow
// - ranks = 1 - 10 then $, %, ^, & (face cards.)
// - define class card to represent using the enums.
// - add props or methods to tell you if card is a number or a symbol.
// - main method will create a card instance for the whole deck and display all.

enum Color {red,green,blue,yellow}
enum Rank {one,two,three,four,five,six,seven,eight,nine,ten,dollar,percent,caret,ampersand}

class Card
{
	public Color Color { get; }
	public Rank Rank { get; }

	public Card(Color col, Rank rank) 
	{
		Color = col;
		Rank = rank;
	}

	public override string ToString() => $"{Color} {Rank}";
}

class Program
{
	static void Main(string[] args)
	{
		Color[] colors = (Color[])Enum.GetValues(typeof(Color));
		Rank[] ranks = (Rank[])Enum.GetValues(typeof(Rank));

		Card[] deck = new Card[colors.Length * ranks.Length];

		for (int i = 0; i < colors.Length; i++)
		{
			for (int j = 0; j < ranks.Length; j++)
			{
				int index = i * ranks.Length + j;
				deck[index] = new Card(colors[i], ranks[j]);
			}
		}

		foreach (Card c in deck) 
		{ 
			Console.WriteLine(c); 
		}
	}
}
