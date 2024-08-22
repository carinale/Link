using Godot;
using System;

public partial class YardGrid : TextureRect
{
	public YardCell[] arrYardCell;
	public int rows=6, columns=5;
	public Vector2 cellSize = new(100, 100);
	//public YardCell[] arrYardCells;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//初始化
		arrYardCell = new YardCell[GetChildCount()];
		for (int i = 0; i < GetChildCount(); i++)
		{
			arrYardCell[i] = GetChild<YardCell>(i);
			arrYardCell[i].SetAnchorsAndOffsetsPreset(LayoutPreset.TopLeft);
			arrYardCell[i].Size = cellSize;

		}
		Size=new Vector2 (100*rows, 100*columns);
		
		Vector2 cellPosition= new(0,0);
		for (int i = 0;i < arrYardCell.Length;i++)
		{

			arrYardCell[i].Position= cellPosition;
			cellPosition.X += cellSize.X;
			if(Math.Abs(cellPosition.X- cellSize.X*columns) <1f)
			{
				cellPosition.X = 0f;
				cellPosition.Y += cellSize.Y;

			}
		}
	}

	public int count = 0;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public YardCell GetMouseInWhichCell()
	{
		Vector2 globalMousePosition=GetGlobalMousePosition();
		GD.PrintErr(globalMousePosition);
		for (int i = 0; i < GetChildCount(); i++)
		{
			Rect2 re = GetChild<YardCell>(i).GetGlobalRect();
			if (GetChild<YardCell>(i).GetGlobalRect().HasPoint(globalMousePosition))
			{
				return GetChild<YardCell>(i);
			}
		}
		return null;
	}


}
