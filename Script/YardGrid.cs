using Godot;
using System;

public partial class YardGrid : GridContainer
{
	//public YardCell[] arrYardCells;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//arrYardCells = new YardCell[GetChildCount()];
  //      for (int i = 0; i < GetChildCount(); i++)
  //      {
		//	arrYardCells[i] = GetChild<YardCell>(i);
  //      }

		////CellGlobalRect =new Rect2[GetChildCount()];
		////for (int i = 0; i < CellGlobalRect.Length; i++)
		////{
		////	CellGlobalRect[i]=this.GetChild<YardCell>(i).GetGlobalRect();
		////}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public YardCell GetMouseInWhichCell()
	{
		Vector2 globalMousePosition=GetGlobalMousePosition();
		for (int i = 0; i < GetChildCount(); i++)
		{
			if (GetChild<YardCell>(i).GetGlobalRect().HasPoint(globalMousePosition))
			{
				return GetChild<YardCell>(i);
			}
		}
		return null;
	}


}
