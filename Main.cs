using Godot;

public partial class Main : Node2D
{
	private Hud _hud;

	public override void _Ready()
	{
		_hud = GetNode<Hud>("HUD");

		// Connect every coin's Collected signal to our score handler
		foreach (Node node in GetTree().GetNodesInGroup("coins"))
		{
			if (node is Coin coin)
				coin.Collected += () => _hud.AddScore(10);
		}
	}
}
