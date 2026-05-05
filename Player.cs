using Godot;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 200f;
	[Export] public float JumpVelocity = -400f;

	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Apply gravity
		if (!IsOnFloor())
			velocity.Y += _gravity * (float)delta;

		// Jump
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Left / right movement
		float direction = Input.GetAxis("ui_left", "ui_right");
		velocity.X = direction != 0 ? direction * Speed : Mathf.MoveToward(Velocity.X, 0, Speed);

		Velocity = velocity;
		MoveAndSlide();
	}
}
