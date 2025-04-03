// Robotic Interface
public class Robot
{
	public int X { get; set; }
	public int Y { get; set; }
	
	public bool IsPowered { get; set; }
	public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
	
	public void Run()
	{
		foreach (IRobotCommand? command in Commands)
		{
			// Skip if null command
			if (command == null) continue;
			
			// Power validation makes more sense as part of the robot (tell, don't ask)
			// Check if robot is powered or if this is a power command
			if (IsPowered || command is OnCommand)
			{
				command.Run(this);
			}
			else
			{
				Console.WriteLine("Robot is not powered.");
			}
			
			Console.WriteLine($"[{X} {Y} {IsPowered}]");
		}
	}
}

public interface IRobotCommand
{
	void Run(Robot robot);
}

// All command implementations just focus on their specific behavior
public class OnCommand : IRobotCommand
{
	public void Run(Robot robot)
	{
		robot.IsPowered = true;
		Console.WriteLine("Robot powers up!");
	}
}

public class OffCommand : IRobotCommand
{
	public void Run(Robot robot)
	{
		robot.IsPowered = false;
		Console.WriteLine("Robot powers down!");
	}
}

public class NorthCommand : IRobotCommand
{
	public void Run(Robot robot)
	{
		robot.Y += 1;
		Console.WriteLine("Robot moves north");
	}
}

public class SouthCommand : IRobotCommand
{
	public void Run(Robot robot)
	{
		robot.Y -= 1;
		Console.WriteLine("Robot move south");
	}
}

public class EastCommand : IRobotCommand
{
	public void Run(Robot robot)
	{
		robot.X += 1;
		Console.WriteLine("Robot moves east");
	}
}

public class WestCommand : IRobotCommand
{
	public void Run(Robot robot)
	{
		robot.X -= 1;
		Console.WriteLine("Robot moves west");
	}
}

class Program
{
	static void Main(string[] args)
	{
		Robot robot = new Robot();
		
		robot.Commands[0] = new OnCommand();
		robot.Commands[1] = new NorthCommand();
		robot.Commands[2] = new EastCommand();
		
		robot.Run();
	}
}
