using Godot;
using System;

public class destroyable : Spatial
{
    [Export]
    public Spatial Lavaflow;

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        if (Translation.DistanceTo(Lavaflow.Translation) <= Lavaflow.Scale.x) {
            QueueFree();
        }
    }
}
