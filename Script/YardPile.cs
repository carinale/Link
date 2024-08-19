using Godot;
using System;

public partial class YardPile : CardPile
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InitState();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public override void InitState()
	{
		base.InitState();
	}
}
