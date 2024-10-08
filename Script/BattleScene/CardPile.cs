using Godot;
using System;
using System.Collections.Generic;


//卡牌区域的基类，包括卡组，手牌，场地，墓地，除外
public partial class CardPile : Control
{

	public void AddCard(CardUI card)
	{
		
		if (IsAncestorOf(card))
		{
			GD.Print(card.Name+"已在"+this.Name);
		}
		else
		{
			AddChild(card);
			GD.Print(card.Name + "添加到" + this.Name);
		}
	}

	public void RemoveCard(CardUI card)
	{
		if(IsAncestorOf(card))
		{
			RemoveChild(card);
			GD.Print("删除"+this.Name+"  "+card.Name);
		}
		else
		{
			GD.Print(this.Name + "不存在" + card.Name);
		}


	}

	public void MoveCardTo(CardUI card,CardPile cardPile)
	{
		if (ContainCard(card) && !cardPile.ContainCard(card))
		{
			this.RemoveCard(card);
			cardPile.AddCard(card);

		}
		else
		{
			GD.Print(this.Name + "不存在"+ card.Name);
		}
	}

	public bool ContainCard(CardUI card)
	{
		return IsAncestorOf(card);
	}

	public CardUI GetCardInPile()
	{
		return GetChildOrNull<CardUI>(0);
	}



}
