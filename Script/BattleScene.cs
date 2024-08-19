using Godot;
using System;

public partial class BattleScene : Control
{
	public YardPile yardPile;
	public HandPile handPile;
	public YardGrid yardGrid;



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		yardPile = GetNode<YardPile>("场地牌堆");
		handPile = GetNode<HandPile>("手牌牌堆");
		yardGrid = GetNode<YardGrid>("场地网格");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}



}
