using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class YardCell : TextureRect
{
	public bool isHaveCard;
	public bool isActive;
	public TextureRect upLink,downLink, leftLink, rightLink;
	public TextureRect leftUpLink, leftDownLink, rightUpLink, rightDownLink;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		upLink = GetNode<TextureRect>("上箭头");
		downLink = GetNode<TextureRect>("下箭头");
		leftLink = GetNode<TextureRect>("左箭头");
		rightLink = GetNode<TextureRect>("右箭头");
		leftUpLink= GetNode<TextureRect>("左上箭头");
		leftDownLink = GetNode<TextureRect>("左下箭头");
		rightUpLink = GetNode<TextureRect>("右上箭头");
		rightDownLink = GetNode<TextureRect>("右下箭头");
		isHaveCard = false;
		isActive = true;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void TrySetCard(CardUI card)
	{
		if (isActive && !isHaveCard)
		{
			if (card.isCanBeUsed)
			{
				card.moveTargetGlobalPosition = GlobalPosition + (Size - card.Size) * 0.5f;
				isHaveCard=true;
				card.isCanBeUsed=false;
				GD.Print("succes to set card");
				return;
			}

		}
		GD.Print("fail to set card");

	}

}
