// The Old Robot
// - Create robot command class with public and abstract void Run(Robot robot)
// - Turn the robot on and off by overriding the run method.
// - Make North, south, west and east commands. Should only work if robot is powered.
// - Main should collect commands, generate robot command ad use the run method.

public class Robot
{
	public int X { get; set; }
	public int Y { get; set; }
	
	public bool IsPowered { get; set; }
	public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
	
	public void Run()
	{
		foreach (RobotCommand? command in Commands)
		{
			command?.Run(this);
			Console.WriteLine($"[{X} {Y} {IsPowered}]");
		}
	}
}

public abstract class RobotCommand
{
	public virtual void Run(Robot robot)
	{
		if (!robot.IsPowered && !(this is OnCommand))
		{
			Console.WriteLine("Robot has no power ...");
			return;
		}

		ExecuteCommand(robot);
	}

	protected abstract void ExecuteCommand(Robot robot);
}

public class OnCommand : RobotCommand
{
	protected override void ExecuteCommand(Robot robot)
	{
		robot.IsPowered = true;
		Console.WriteLine("Robot powers up!");
	}
}

public class OffCommand : RobotCommand
{
	protected override void ExecuteCommand(Robot robot)
	{
		robot.IsPowered = false;
		Console.WriteLine("Robot powers down!");
	}
}

public class NorthCommand : RobotCommand
{
	protected override void ExecuteCommand(Robot robot)
	{
		robot.Y += 1;
		Console.WriteLine("Robot moves north");
	}
}

public class SouthCommand : RobotCommand
{
	protected override void ExecuteCommand(Robot robot)
	{
		robot.Y -= 1;
		Console.WriteLine("Robot move south");
	}
}

public class EastCommand : RobotCommand
{
	protected override void ExecuteCommand(Robot robot)
	{
		robot.X += 1;
		Console.WriteLine("Robot moves east");
	}
}

public class WestCommand : RobotCommand
{
	protected override void ExecuteCommand(Robot robot)
	{
		robot.X -= -1;
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
