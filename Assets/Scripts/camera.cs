using Godot;
using System;

public class camera : Camera
{
    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("ui_left")) {
            GD.Print("ug");
            GetParent<Spatial>().Rotate(Vector3.Up, -0.01f);
        }

        if (Input.IsActionPressed("ui_right")) {
            GD.Print("ug");
            GetParent<Spatial>().Rotate(Vector3.Up, 0.01f);
        }

        if (Input.IsActionPressed("ui_up")) {
            GD.Print("ug");
            GetParent<Spatial>().Rotate(Vector3.Right, -0.01f);
        }

        if (Input.IsActionPressed("ui_down")) {
            GD.Print("ug");
            GetParent<Spatial>().Rotate(Vector3.Right, 0.01f);
        }
    }
}
