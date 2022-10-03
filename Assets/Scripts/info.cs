using Godot;
using System;

public class info : Label
{
    [Export]
    public int Info = 0;

    [Export]
    public string[] Boxes = {
        "Cindercone:\nTesting",
        "Stratovolcano:",
        "Shield volcano"
    };

    public override void _Ready()
    {
        Display();
    }

    public void Display() {
        Text = Boxes[Info];
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
