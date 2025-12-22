using Godot;
using System;

public partial class Drawing_Board : ColorRect
{
	Sprite2D sprite;
	const float minimum_size = 0.1f;
	Vector2 one = new Vector2(1,1);

	public override void _Ready()
	{ sprite = GetNode<Sprite2D>("Sprite2D"); }

	public override void _Process(double delta)
	{
	}

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseMotion input)
        {
            sprite.Scale = one * (minimum_size + input.Pressure);
			sprite.Position = input.Position;
        }
    }

}
