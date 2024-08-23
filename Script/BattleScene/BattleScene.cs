using Godot;
using System;

public partial class BattleScene : Control
{
	public YardGrid yardGrid;

	public DeckZone deckZone;
	public HandZone handZone;
	public YardCellZone[,] arrYardCellZone;
	public GraveZone graveZone;
	public BanishZone banishZone;



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		yardGrid= GetNodeOrNull<YardGrid>("场地区域/场地网格");

        deckZone = GetNodeOrNull<DeckZone>("卡组区域");
        handZone = GetNodeOrNull<HandZone>("手牌区域");
        graveZone = GetNodeOrNull<GraveZone>("墓地区域");
        banishZone = GetNodeOrNull<BanishZone>("除外区域");

		arrYardCellZone = yardGrid.arrYardCellZone;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}



	public void _on_button_pressed()
	{
        CardUI card = deckZone.GetCardInZone();
        if (card != null)
        {
            deckZone.MoveCardTo(card, handZone);
        }
    }



    //只执行 不检测条件是否满足
    public void DrawCard()
	{
        CardUI card = deckZone.GetCardInZone();
		if (card != null)
		{
            deckZone.MoveCardTo(card, handZone);
        }
    }

	public void SummonCard(CardUI card,YardCellZone cell)
	{
		card.
	}

}
