using Godot;

public partial class Coin : Area2D
{
	[Signal] public delegate void CollectedEventHandler();

	public override void _Ready()
	{
		AddToGroup("coins");
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is Player)
		{
			EmitSignal(SignalName.Collected);
			QueueFree(); // removes the coin from the scene
		}
	}
}
