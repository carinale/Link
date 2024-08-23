using Godot;
using System;

public partial class YardCellZone : BattleSceneCardZone
{
    public bool isHaveCard;
    public bool isActive;
    public TextureRect upLink, downLink, leftLink, rightLink;
    public TextureRect leftUpLink, leftDownLink, rightUpLink, rightDownLink;
    public static Vector2 InitSize = new(100, 100);

    public override void InitState()
	{
        upLink = GetNode<TextureRect>("上箭头");
        downLink = GetNode<TextureRect>("下箭头");
        leftLink = GetNode<TextureRect>("左箭头");
        rightLink = GetNode<TextureRect>("右箭头");
        leftUpLink = GetNode<TextureRect>("左上箭头");
        leftDownLink = GetNode<TextureRect>("左下箭头");
        rightUpLink = GetNode<TextureRect>("右上箭头");
        rightDownLink = GetNode<TextureRect>("右下箭头");
        isHaveCard = false;
        isActive = true;
        Size = InitSize;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}


	protected override void AddCard(CardUI card)
	{	   
        //刷新箭头
	}

	protected override void RemoveCard(CardUI card)
	{
        //刷新箭头
    }


}
