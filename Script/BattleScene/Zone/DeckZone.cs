using Godot;
using System;

public partial class DeckZone : BattleSceneCardZone
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
            for (int i = 0; i < 20; i++)
            {
                CardUI instance = scene.Instantiate<CardUI>();
                instance.Name = "Card" + (i+5).ToString();
                instance.Visible = false;
                cardPile.AddChild(instance);
            }
        }
    }


    public override void RefreshState()
    {

    }


    protected override void AddCard(CardUI card)
    {
        card.Visible = false;
    }

    protected override void RemoveCard(CardUI card)
    {

    }
}
