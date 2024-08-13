using Godot;
using System;

public partial class YardGrid : GridContainer
{
	public Rect2[] CellGlobalRect;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CellGlobalRect=new Rect2[GetChildCount()];
		for (int i = 0; i < CellGlobalRect.Length; i++)
		{
			CellGlobalRect[i]=this.GetChild<YardCell>(i).GetGlobalRect();
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public int GetMouseInWhichCell()
	{
		Vector2 mousePosition=GetGlobalMousePosition();
		for (int i = 0; i< CellGlobalRect.Length; i++)
		{
			if(CellGlobalRect[i].HasPoint(mousePosition))
			{
				return i;
			}            
		}
		return -1;

	}
}
