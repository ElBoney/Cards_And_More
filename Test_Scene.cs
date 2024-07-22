using Godot;
using System;

public partial class Test_Scene : Godot.Node2D
{
	Sprite2D cursor;
	Sprite2D click_informer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		cursor = GetNode<Sprite2D>("Cursor");
		click_informer = GetNode<Sprite2D>("Click_Informer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Vector2I mouse_location = DisplayServer.MouseGetPosition();
		//Vector2 mouse_location = GetLocalMousePosition();
		Vector2 mouse_location = GetGlobalMousePosition();
		cursor.GlobalPosition = mouse_location;

		if(Input.IsActionPressed("left_mouse_down"))
		{
			click_informer.Visible = true;
		}
		else{click_informer.Visible = false;}
	}

}
