using Godot;
using System;

public partial class BattleSceneZone : TextureRect
{
	public CardPile cardPile=null;
	public BattleScene battleScene=null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		cardPile=GetCardPileInZone();
		battleScene = GetNode<BattleScene>("/root/战斗场景");
        InitState();

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	public virtual void InitState()
	{

	}

	public virtual void RefreshState()
	{

	}

	public CardPile GetCardPileInZone()
	{
		for (int i = 0; i < GetChildCount(); i++)
		{
			if (GetChildOrNull<CardPile>(i) != null)
			{
				return GetChildOrNull<CardPile>(i);

            }

		}
		return null;
	}

	public void SetAllCardReturnTarget()
	{
		for (int i = 0; i < cardPile.GetChildCount(); i++)
		{
			CardUI card = cardPile.GetChildOrNull<CardUI>(i);
			if (card != null) 
			{
                card.moveTargetGlobalPosition = card.GlobalPosition;
            }	
		}
	}

	//不处理节点移动，处理其他任务
	protected virtual void AddCard(CardUI card)
	{

	}
    protected virtual void RemoveCard(CardUI card)
	{

	}
	


    public void MoveCardTo(CardUI card, BattleSceneZone targetZone)
	{
		if(this.cardPile.ContainCard(card))
		{
            RemoveCard(card);
            targetZone.AddCard(card);
			this.cardPile.MoveCardTo(card, targetZone.cardPile);
        }
		else
		{
			GD.PrintErr(Name+"not have"+card.Name);
		}

	}


}
