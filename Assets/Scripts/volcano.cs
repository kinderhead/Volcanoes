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

    [Export]
    public Spatial Lavaflow;

    [Export]
    public PackedScene DriedLavaflow;

    [Export]
    public PackedScene Tree;

    public static bool Erupting {get; private set;} = false;

    [Export]
    public double NextFlow = 550;

    [Export]
    public float MinSpawnRadius = 150;

    [Export]
    public float MaxSpawnRadius = 700;

    public override void _Ready()
    {
        Crater = GetNode<Spatial>("Crater");
        UI = GetParent().GetNode<Control>("Control");
        Lavaflow = GetNode<Spatial>("Lavaflow");

        GD.Randomize();

        SpawnObjects();
    }

    public override void _Process(float delta)
    {
        if (UI.GetNode<Button>("Erupt").Pressed && !Erupting) {
            Erupt();
        }
    }

    public async void Erupt() {
        GD.Print("Erupting");
        Erupting = true;
        Crater.GetNode<Particles>("Particles").Emitting = true;

        double nextNext = GD.RandRange(NextFlow-150, NextFlow - 1);
        float duration = (float) GD.RandRange(15, 60);

        Lavaflow.GetNode<Tween>("Tween").InterpolateProperty(Lavaflow, "scale", new Vector3(Lavaflow.Scale.x, Lavaflow.Scale.y, Lavaflow.Scale.z), new Vector3((float) nextNext, Lavaflow.Scale.y, (float) nextNext), duration);
        Lavaflow.GetNode<Tween>("Tween").Start();

        await ToSignal(GetTree().CreateTimer(duration), "timeout");

        Crater.GetNode<Particles>("Particles").Emitting = false;

        Lavaflow.GetNode<Tween>("Tween").StopAll();

        Spatial dried = (Spatial) DriedLavaflow.Instance();
        dried.Scale = Lavaflow.Scale;
        dried.Transform = Lavaflow.Transform;
        AddChild(dried);

        Lavaflow.Scale = new Vector3(50, Lavaflow.Scale.y + 1, 50);
        NextFlow = nextNext;

        Erupting = false;
        GD.Print("Done erupting");

        SpawnObjects();
    }

    public void SpawnObjects() {
        GD.Print("Spawning objects");

        for (float i = 0; i < GD.RandRange(50, 200); i++)
        {
            destroyable obj = Tree.Instance<destroyable>();

            obj.Lavaflow = Lavaflow;
            obj.Translate(new Vector3((float) GD.RandRange(-MaxSpawnRadius, MaxSpawnRadius), -41.487f, (float) GD.RandRange(-MaxSpawnRadius, MaxSpawnRadius)));

            GetParent().CallDeferred("add_child", obj);
        }
    }
}
