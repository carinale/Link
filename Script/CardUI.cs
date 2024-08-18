using Godot;
using System;

public partial class CardUI : TextureRect
{
	//坐标移动相关变量
	public Vector2 dragTargetGlobalPosition;
	public Vector2 returnTargetGlobalPosition;
    public Vector2 clickPositionBias;
    public float dragSpeed = 1f;
	public float returnSpeed = 0.3f;
	public float distanceAccuracy = 5.0f;


    //卡牌状态
    public bool isLocked = false;
	public bool isDetailMode=false;

	//是否在下述操作流程中
	public bool isDragging=false;
	public bool isReturning = false;

	//卡牌初始化信息
	public Vector2 initSize = new Vector2(80, 80);
	YardGrid yardGrid;

	public override void _Ready()
	{
		Size = initSize;
		returnTargetGlobalPosition = GlobalPosition;
		MouseEntered += OnMouseEntered;
		MouseExited += OnMouseExited;
		GuiInput += OnGuiInput;
		yardGrid = GetNodeOrNull<YardGrid>("/root/战斗场景/场地网格");
	}


	public override void _Process(double delta)
	{
		if (isDragging)
		{
			if (!isLocked)
			{
				DragCard();
				HideDetailInfo();

            }
		}
		else if (isReturning)
		{
            HideDetailInfo();
            if (Position.IsEqualApprox(returnTargetGlobalPosition))
			{
				isReturning = false;
			}
			else
			{
				ReturnCard();
			}

		}
		else  
		{
			if(isDetailMode)
			{
				ShowDetailInfo();
			}
			else
			{
				HideDetailInfo();
			}

        }
	}

	public void ShowDetailInfo()
	{
		GetNode<Control>("卡牌信息").Visible = true;
	}

    public void HideDetailInfo()
    {
        GetNode<Control>("卡牌信息").Visible = false;
    }

    //卡牌拖动
    public void DragCard()
	{
		dragTargetGlobalPosition = GetGlobalMousePosition() - clickPositionBias;
		GlobalPosition = GlobalPosition.Lerp(dragTargetGlobalPosition, dragSpeed);
	}

	

	public void ReturnCard()
	{
		if (GlobalPosition.DistanceTo(returnTargetGlobalPosition) < distanceAccuracy)
		{
            GlobalPosition = returnTargetGlobalPosition;
		}
		else
		{
            GlobalPosition = GlobalPosition.Lerp(returnTargetGlobalPosition, returnSpeed);
		}

	}


	//根据当前状态设置停靠的目标点
	public void SetReturnTargetPostion()
	{
		if (yardGrid==null)
		{
			return;
		}
		if(!isLocked)
		{
			YardCell yardCell = yardGrid.GetMouseInWhichCell();
			if (yardCell != null)
			{
				//根据卡牌当前大小和cell大小计算目标坐标
				returnTargetGlobalPosition = yardCell.GlobalPosition + (yardCell.Size - this.Size) * 0.5f;
				isLocked = true;
			}
		}

	}


	private void OnMouseEntered()
	{
		isDetailMode = true;
		GD.PrintErr("in");
	}
	
	private void OnMouseExited()
	{
		isDetailMode =false;
		GD.PrintErr("out");
	}

	private void OnGuiInput(InputEvent @event)
	{
		if(@event is InputEventMouseButton mouseEvent )
		{
			if(mouseEvent.ButtonIndex == MouseButton.Left)
			{
				if(mouseEvent.Pressed)
				{
					isDragging = true;
					clickPositionBias = mouseEvent.GlobalPosition - GlobalPosition;
				}
				else
				{
					//拖动终止 开始返回
					isDragging=false;
					isReturning = true;
					isDetailMode = false;
					//设置卡牌返回目标坐标点
					SetReturnTargetPostion();


				}				
			}

		}
	}

}
