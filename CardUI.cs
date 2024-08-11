using Godot;
using System;

public partial class CardUI : Control
{
	public bool isDragging = false;
	public bool isLocked = false;
	public bool isLarge=false;
	public float dragSpeed = 0.03f;
	public float zoomSpeed = 0.3f;
    public float staySpeed = 0.5f;
	public Vector2 clickPositionBias = new();
	public Vector2 smallSize = new Vector2(100, 100);
	public Vector2 largeSize = new Vector2(200, 200);
	public Vector2 stayTargetPosition = new();

	//卡牌所在的牌堆：卡组 手牌 场地……
	public enum CardPileType
	{
		Deck,
        Hand,
		Yard,
		Grave
    };

	public CardPileType cardPileType;


    public override void _Ready()
	{
		stayTargetPosition = Position;
		Size = smallSize;
        MouseEntered += OnMouseEntered;
		MouseExited += OnMouseExited;
		GuiInput += OnGuiInput;
	}


	public override void _Process(double delta)
	{
        if (!isLocked)
		{
			if (isDragging)
			{
                DragCard();
            }
		}
        if(!isDragging)
		{
            if(isLarge)
			{
				SetCardLargeSize();
			}
			else
			{
				SetCardSmallSize();
			}
			StayCard();
        }
    }



	public void SetStayTargetPosition()
	{
		switch(cardPileType)
		{
			case CardPileType.Deck:
				break;
			case CardPileType.Hand:
				break;
			case CardPileType.Yard:
				break;
			case CardPileType.Grave:
				break;
		}
	}

    //将卡牌停在特定位置
    public void StayCard()
    {
        Position = Position.Lerp(stayTargetPosition,staySpeed);
    }

    //      if (isDragging && (!isLocked))
    //{
    //	targetPosition = GetGlobalMousePosition();
    //	this.Position = targetPosition - clickPositionBias;
    //          Position.Lerp
    //          position = lerp(position, target_position, return_speed)
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


    //卡牌拖动
    public void DragCard()
	{
        Position = Position.Lerp(GetGlobalMousePosition() - clickPositionBias,dragSpeed);
    }



    //显示卡牌缩小模式
    public void SetCardSmallSize()
	{
        Size = Size.Lerp(smallSize, zoomSpeed);
        Position = Position.Lerp(Position + (Size - smallSize) * 0.5f, zoomSpeed);
    }

	//显示卡牌放大模式
	public void SetCardLargeSize()
	{
        Size = Size.Lerp(largeSize, zoomSpeed);
        Position = Position.Lerp(Position - (largeSize - Size) , zoomSpeed);
	}

	private void OnMouseEntered()
	{
		isLarge = true;
	}
	
	private void OnMouseExited()
	{
		isLarge = false;       
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
                    //点击时强制变为large模式
                    //Position += (Size - largeSize) * 0.5f;
                    //Size = largeSize;	
                    clickPositionBias = mouseEvent.GlobalPosition - GlobalPosition;
                    GD.Print("start drag");
				}
				else
				{
					isDragging = false;
					//clickPositionBias = Vector2.Zero;
					//Position = stayTargetPosition;
					//SetCardLargeSize();
					isLarge = false;
                    GD.Print("stop drag");
				}				
			}

		}
	}

}
