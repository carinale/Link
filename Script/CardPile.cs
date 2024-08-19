using Godot;
using System;
using System.Collections.Generic;


//卡牌区域的基类，包括卡组，手牌，场地，墓地，除外
public partial class CardPile : TextureRect
{


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void AddCard(CardUI card)
	{
		
		if (IsAncestorOf(card))
		{
			GD.Print("已在内部");
		}
		else
		{
			AddChild(card);
			RefrshState();
			GD.Print("Add card");
		}
	}

	public void RemoveCard(CardUI card)
	{
		if(IsAncestorOf(card))
		{
			RemoveChild(card);
			RefrshState();
			GD.Print("remove");
		}
		else
		{
			GD.Print("not have this card");
		}


	}

	public void MoveCardTo(CardUI card,CardPile cardPile)
	{
		if (IsAncestorOf(card) && !cardPile.IsAncestorOf(card))
		{
			cardPile.AddCard(card);
			this.RemoveCard(card);
			GD.Print("move succes");
		}
		else
		{
			GD.Print("dont have this card");
		}
	}

	public virtual void RefrshState()
	{

	}

	public virtual void InitState()
	{

	}


	public  void SetAllCardReturnTarget()
	{
		for (int i = 0; i < GetChildCount(); i++)
		{
			CardUI card = GetChild<CardUI>(i);
			card.moveTargetGlobalPosition=card.GlobalPosition;
		}

	}

}
