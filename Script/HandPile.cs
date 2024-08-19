using Godot;
using System;

public partial class HandPile : CardPile
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        InitState();

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


    public override void InitState()
    {
        Vector2 relativePosition = Vector2.Zero;
        for (int i = 0; i < GetChildCount(); i++)
        {
            CardUI handCard = this.GetChild<CardUI>(i);
            handCard.SetAnchorsPreset(LayoutPreset.TopLeft);
            handCard.Position = relativePosition;
            relativePosition.X += handCard.Size.X + 10f;
        }
        SetAllCardReturnTarget();
    }

    public override void RefrshState()
    {
        Vector2 relativePosition = Vector2.Zero;
        for (int i = 0; i < GetChildCount(); i++)
        {
            CardUI handCard = this.GetChild<CardUI>(i);
            handCard.SetAnchorsPreset(LayoutPreset.TopLeft);
            handCard.Position = relativePosition;
            relativePosition.X += handCard.Size.X + 10f;
        }
        SetAllCardReturnTarget();
    }

}
