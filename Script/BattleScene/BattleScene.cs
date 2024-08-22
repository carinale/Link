using Godot;
using System;

public partial class BattleScene : Control
{
	public YardGrid yardGrid;

	public DeckZone deckZone;
	public HandZone handZone;
	public YardZone yardZone;
	public GraveZone graveZone;
	public BanishZone banishZone;


	public CardPile deckPile;
	public CardPile handPile;
	public CardPile yardPile;
	public CardPile gravePile;
	public CardPile banishPile;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		deckPile = GetNode<CardPile>("卡组区域/卡组卡堆");
		handPile = GetNode<CardPile>("手牌区域/手牌卡堆");
		yardPile = GetNode<CardPile>("场地区域/场地卡堆");
		gravePile = GetNode<CardPile>("墓地区域/墓地卡堆");
		banishPile = GetNode<CardPile>("除外区域/除外卡堆");

		deckZone = GetNode<DeckZone>("卡组区域");
		handZone = GetNode<HandZone>("手牌区域");
		yardZone = GetNode<YardZone>("场地区域");
		graveZone = GetNode<GraveZone>("墓地区域");
		banishZone = GetNode<BanishZone>("除外区域");


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Draw()
	{
		deckZone.MoveCardTo(deckZone.GetChild<CardUI>(0),handZone);
	}

	public void _on_button_pressed()
	{
		deckZone.MoveCardTo(deckZone.GetChild<CardUI>(0), handZone);
		GD.PrintErr("1");
	}


}
