using Godot;
using System;

public partial class HandZone : BattleSceneCardZone
{

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void InitState()
	{
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

	//card.CardStopDrag += battleScene.yardZone.TryAddCardToYard;
				//card.CardStopDrag -= battleScene.yardZone.TryAddCardToYard;
	//刷新ui
	protected override void AddCard(CardUI card)
	{
		card.Visible = true;
		RefreshState();

	}

	protected override void RemoveCard(CardUI card)
	{
		RefreshState();
	}



}
