using Godot;

public partial class Hud : CanvasLayer
{
	private int _score = 0;
	private Label _scoreLabel;

	public override void _Ready()
	{
		_scoreLabel = GetNode<Label>("ScoreLabel");
		UpdateLabel();
	}

	public void AddScore(int points)
	{
		_score += points;
		UpdateLabel();
	}

	private void UpdateLabel()
	{
		_scoreLabel.Text = $"Score: {_score}";
	}
}
