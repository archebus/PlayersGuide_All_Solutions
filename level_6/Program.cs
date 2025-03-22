// Write a program that uses all 14 built in C# types.
// Second excersise is to change all the values in each assignment (done).

void allTypes() {

	bool 	a	= true;		// 1
	byte	b	= 12;		// 2
	sbyte	c	= -11;		// 3
	char	d	= 'J';		// 4
	decimal	e	= 2.11m;	// 5
	double	f	= 2.11;		// 6
	float	g	= 2.11F;	// 7
	int	h	= 12;		// 8
	uint	i	= 124;		// 9
	nint	j	= -58;		// 10
	nuint	k	= 238;		// 11
	long	l	= 83935;	// 12
	short	m	= 1;		// 13
	ushort	n	= 12;		// 14

	Console.WriteLine($"{a} {b} {c} {d} {e} {f} {g} {h} {i} {j} {k} {l} {m} {n}");
}

allTypes();
