using Godot;
using System;

public class volcano : MeshInstance
{
    [Export]
    public Spatial Crater;

    [Export]
    public Control UI;

    [Export]
    public Spatial Lavabombs;

    public static bool Erupting {get; private set;} = false;

    public override void _Ready()
    {
        Crater = GetNode<Spatial>("Crater");
        UI = GetParent().GetNode<Control>("Control");

        GD.Randomize();
    }

    public override void _Process(float delta)
    {
        if (UI.GetNode<Button>("Erupt").Pressed && !Erupting) {
            Erupt();
        }

        if (GD.RandRange(0, 100) > 98) {
            GD.Print("Boo");
        }
    }

    public async void Erupt() {
        GD.Print("Erupting");
        Erupting = true;
        Crater.GetNode<Particles>("Particles").Emitting = true;

        await ToSignal(GetTree().CreateTimer(new Random().Next(15, 60)), "timeout");

        Crater.GetNode<Particles>("Particles").Emitting = false;
        Erupting = false;
        GD.Print("Done erupting");
    }
}
