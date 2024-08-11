using Godot;
using System;

public partial class CardUI : Control
{
	public Vector2 dragTargetPosition;
	public Vector2 zoomTargetPosition;
    public Vector2 zoomTargetSize;
	public Vector2 returnTargetPosition;
    public float dragSpeed = 1f;
    public float zoomSpeed = 0.1f;
    public float returnSpeed = 0.3f;
	public float distanceAccuracy = 5.0f;


    //卡牌目标状态 锁定 细节模式
    public bool isLocked = false;
	public bool isDetailMode=false;

	//是否在下述操作流程中
	public bool isDragging=false;
	public bool isZooming=false;
	public bool isReturning = false;

	public Vector2 clickPositionBias = new();
	public Vector2 smallSize = new Vector2(100, 100);
	public Vector2 largeSize = new Vector2(200, 200);
	public Vector2 stayTargetPosition = new();


    public override void _Ready()
	{
		Size = smallSize;
		returnTargetPosition = Position;
        MouseEntered += OnMouseEntered;
		MouseExited += OnMouseExited;
		GuiInput += OnGuiInput;
	}


	public override void _Process(double delta)
	{
		if (isDragging)
		{
			if (!isLocked)
			{
                DragCard();
            }
		}
		else if (isReturning)
		{
			if(Position.IsEqualApprox(returnTargetPosition))
			{
                isReturning = false;
            }
			else
			{
                ReturnCard();
            }

		}
		else if (isZooming) 
		{
            ZoomCard();
            if (Position.IsEqualApprox(zoomTargetPosition))
			{
				isZooming = false;
			}						

				
            

        }
    }




    //卡牌拖动
    public void DragCard()
	{
		dragTargetPosition = GetGlobalMousePosition() - clickPositionBias;
        Position = Position.Lerp(dragTargetPosition, dragSpeed);
    }

	public void ZoomCard()
	{
		if (isDetailMode)
		{
            zoomTargetPosition = Position - (largeSize - Size) * 0.5f;
            zoomTargetSize = largeSize;
        }
		else
		{
            zoomTargetPosition = Position + (Size - smallSize) * 0.5f;
            zoomTargetSize = smallSize;
        }

		if (Position.DistanceTo(zoomTargetPosition) <= distanceAccuracy) 
		{
			Position = zoomTargetPosition;
			Size = zoomTargetSize;

        }
		else
		{
            Position = Position.Lerp(zoomTargetPosition, zoomSpeed);
            Size = Size.Lerp(zoomTargetSize, zoomSpeed);
        }


    }

	public void ReturnCard()
	{
        if (Position.DistanceTo(returnTargetPosition) <= distanceAccuracy)
		{
			Position=returnTargetPosition;
		}
		else
		{
            Position = Position.Lerp(returnTargetPosition, returnSpeed);
        }

	}


	//根据当前状态设置停靠的目标点
	public void SetReturnTargetPostion()
	{
        GridContainer grid = GetParent().GetNode<GridContainer>("GridContainer");

        //          //GridContainer grid = this.GetParent().GetNode<GridContainer>("GridContainer");
        //          //Vector2 cellPosition;
        //          //for (int i = 0; i < grid.GetChildCount() - 1; i++)
        //          //{
        //          //	cellPosition = grid.GetChild<Control>(i).GlobalPosition;
        //          //	if (Position.IsEqualApprox(cellPosition))
        //          //	{
        //          //		Position = cellPosition;
        //          //		canMove = false;
        //          //		break;
        //          //	}
        //          //}
        //      }
    }


    private void OnMouseEntered()
	{
		isZooming = true;
		isDetailMode = true;
    }
	
	private void OnMouseExited()
	{
        isZooming = true;
        isDetailMode =false;
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

                }				
			}

		}
	}

}



