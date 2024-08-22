using Godot;
using System;

public partial class HandZone : BattleSceneZone
{

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void InitState()
	{

		PackedScene scene = GD.Load<PackedScene>("res://Scene/卡牌CardUI.tscn");
		if (scene != null)
		{
			for (int i = 0; i < 5; i++)
			{
				CardUI instance = scene.Instantiate<CardUI>();
				instance.Name = "Card" + i.ToString();
				cardPile.AddChild(instance);
			}
		}

		SetCardPosition();
	}


	public override void RefreshState()
	{
		SetCardPosition();
	}

	public void SetCardPosition()
	{
		Vector2 relativePosition = Vector2.Zero;
		for (int i = 0; i < cardPile.GetChildCount(); i++)
		{

			CardUI handCard = cardPile.GetChildOrNull<CardUI>(i);
			if (handCard != null)
			{
				handCard.GlobalPosition = GlobalPosition + relativePosition;
				relativePosition.X += handCard.Size.X + 10f;
			}
		}
		base.SetAllCardReturnTarget();
	}

	//移动卡牌节点位置
	//绑定信号
	protected override void AddCard(CardUI card)
	{
		card.CardStopDrag += battleScene.yardZone.TryAddCardToYard;
	}

	protected override void RemoveCard(CardUI card)
	{
		card.CardStopDrag -= battleScene.yardZone.TryAddCardToYard;
	}



}
