using Godot;
using System;

public partial class CardUI : TextureRect
{
	//坐标移动相关变量
	public Vector2 dragTargetGlobalPosition;
	public Vector2 moveTargetGlobalPosition;
    public Vector2 clickPositionBias;
    public float dragSpeed = 1f;
	public float moveSpeed = 0.3f;
	public float distanceAccuracy = 5.0f;


    //卡牌状态
    public bool isCanBeUsed = true; //是否能够放在场地上
	public bool isDetailMode=false;

	//是否在下述操作流程中
	public bool isDragging = false;
	public bool isMoving = false;

	//卡牌初始化信息
	public Vector2 initSize = new Vector2(80, 80);


	//卡牌使用信号
	[Signal]
	public delegate void CardStopDragEventHandler();


	public override void _Ready()
	{
		Size = initSize;
        MouseEntered += OnMouseEntered;
		MouseExited += OnMouseExited;
		GuiInput += OnGuiInput;
	}


	public override void _Process(double delta)
	{
		if (isDragging)
		{
			if (isCanBeUsed)
			{
				DragCard();
				HideDetailInfo();
            }
		}
		else if (isMoving)
		{
            HideDetailInfo();
            if (GlobalPosition.IsEqualApprox(moveTargetGlobalPosition))
			{
				isMoving = false;
			}
			else
			{
				MoveCard();
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

	
	//卡牌自动移动到目标点
	public void MoveCard()
	{
		if (GlobalPosition.DistanceTo(moveTargetGlobalPosition) < distanceAccuracy)
		{
            GlobalPosition = moveTargetGlobalPosition;
		}
		else
		{
            GlobalPosition = GlobalPosition.Lerp(moveTargetGlobalPosition, moveSpeed);
		}

	}

	public void SetMoveTarget()
	{
        moveTargetGlobalPosition = GlobalPosition;
    }

	//检测卡牌是否能够使用
	public bool CanCardBeUsed()
	{
		if(isCanBeUsed)
		{
			return true;
		}
		return false;
	}

	//尝试将卡牌放置在当前鼠标位置的场地中
	//public void TrySetCardInYard()
	//{
	//	if(CanCardBeUsed())
	//	{
	//		if(battleScene!=null)
	//		{
	//			YardCell yardCell = battleScene.yardGrid.GetMouseInWhichCell();
	//			if(yardCell != null)
	//			{
 //                   if (yardCell.isActive && !yardCell.isHaveCard)
	//				{
 //                       moveTargetGlobalPosition = yardCell.GlobalPosition + (yardCell.Size - this.Size) * 0.5f;
 //                       isCanBeUsed = true;//后续修改成枚举
 //                       yardCell.isHaveCard=true;//后续直接引用
	//					//ChangeCardPile(battleScene.yardPile);
 //                   }

 //               }
 //           }
	//	}
	//}




	private void OnMouseEntered()
	{
		isDetailMode = true;
	}
	
	private void OnMouseExited()
	{
		isDetailMode =false;
	}

	public void OnGuiInput(InputEvent @event)
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
					//拖动终止
					isDragging=false;
					isMoving = true;
					EmitSignal(nameof(CardStopDrag));
                }				
			}
		}
	}
}
