using Godot;
using System;

public class info : Label
{
    [Export]
    public int Info = 0;

    [Export]
    public string[] Boxes = {
        "Cinder cone:\nCinder cones are a special type of volcano formed from ash from mafic volcanic eruptions. They sometimes can grow thousands of feet. Their slope is around 30 degrees. Cinder cones frequently form near other, larger volcanoes.\nDangers include: Lava flows, ash, and lava bombs.",
        "Stratovolcano:\nStratovolcanoes or composite volcanoes are large volcano made of a variety of rock types like basalt and rhyolite. They are what you typically think of when you think about volcanoes. They grow very slowly from lava and pyroclastic flows. They typically form near plate boundaries, hotspots, and other geological activites.\nDangers include: Lava flows, pyroclastic flows, ash.",
        "Shield volcano:\nShield volcanoes are the biggest type of volcano. They are typically made of basalt, or similar. They take a very long time to grow. The tallest mountain on Earth, Mauna Kea, is a shield volcano. Shield volcanoes form near plate boundaries and hotspots.\nDangers include: Lava flows, lava bombs, explosions."
    };

    public override void _Ready()
    {
        Display();
    }

    public void Display() {
        Text = Boxes[Info];
    }

    public override void _Input(InputEvent @event) {
        if (@event.IsActionPressed("info_left")) {
            if (Info == 0) {
                Info = Boxes.Length - 1;
            }
            else {
                Info--;
            }
        }

        if (@event.IsActionPressed("info_right")) {
            Info++;
            if (Info == Boxes.Length) {
                Info = 0;
            }
        }

        Display();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
