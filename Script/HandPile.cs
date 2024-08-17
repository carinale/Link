using Godot;
using System;

public partial class HandPile : TextureRect
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetHandCard();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	//整理手牌
	public void SetHandCard()
	{
		Vector2 relativePosition=Vector2.Zero;
		for (int i = 0; i < GetChildCount(); i++)
		{
			CardUI handCard = this.GetChild<CardUI>(i);
			handCard.SetAnchorsPreset(LayoutPreset.TopLeft);
			handCard.Position = relativePosition;
			relativePosition.X += handCard.Size.X + 10f;

		}
	}
}
