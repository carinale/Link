using Godot;
using System;

public partial class YardGrid : TextureRect
{
	public YardCellZone[,] arrYardCellZone;
	public static int rows=6, columns=5;
	public static Vector2 initSize=new();
    public static float margin=50;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		//设置网格大小
		Vector2 cellPosition=new(margin,margin);
		initSize.X = YardCellZone.InitSize.X * rows+ margin*2;
        initSize.Y = YardCellZone.InitSize.Y * columns + margin * 2;
		Size = initSize;

        //创建场地格子节点，排序
        arrYardCellZone = new YardCellZone[rows,columns];
		PackedScene scene = GD.Load<PackedScene>("res://Scene/场地格子YardCell.tscn");
		if (scene != null)
		{
			for (int i = 0; i < rows; i++)			
			{
                for (int j = 0; j < columns; j++)
				{
                    YardCellZone instance = scene.Instantiate<YardCellZone>();
                    instance.Name = "Cell" +" "+ i.ToString()+","+j.ToString();
                    this.AddChild(instance);
                    arrYardCellZone[i,j]= instance;
                    instance.SetAnchorsAndOffsetsPreset(LayoutPreset.TopLeft);
                    instance.Position = cellPosition;
					cellPosition.X += YardCellZone.InitSize.X;
                }
                cellPosition.X =margin;
				cellPosition.Y += YardCellZone.InitSize.Y;
            }
		}


	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public YardCellZone GetMouseInWhichCell()
	{
		Vector2 globalMousePosition=GetGlobalMousePosition();
		GD.PrintErr(globalMousePosition);
		for (int i = 0; i < GetChildCount(); i++)
		{
			Rect2 re = GetChild<YardCell>(i).GetGlobalRect();
			if (GetChild<YardCell>(i).GetGlobalRect().HasPoint(globalMousePosition))
			{
				return GetChild<YardCellZone>(i);
			}
		}
		return null;
	}


}
