using Godot;
using System;

public class volcano : MeshInstance
{
    [Export]
    public Spatial Crater;

    public override void _Ready()
    {
        Crater = GetNode<Spatial>("Crater");
    }

    public override void _Process(float delta)
    {
        
    }
}
