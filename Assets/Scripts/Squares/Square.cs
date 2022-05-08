using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GridControlBasicCompoments
{
    // 普通のマス目
public class Square : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public BoardPosition boardPosition { private set; get; }
    public Action<Square> OnClick = null;
    public Action<Square, SquareState> OnChangeState = null;
    // 現在選択中などマスのStateが変わることがあるのでそれに合わせた管理をする
    public SquareState CurrentState { private set; get; }

    private void Awake()
    {
    }

	public void Initialize(int positionX, int positionY)
    {
        this.CurrentState = SquareState.Normal;
        this.boardPosition = new BoardPosition(positionX, positionY);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.CurrentState == SquareState.Normal)
        {
            this.ChangeState(SquareState.Hovering);
        }
        else if(this.CurrentState == SquareState.Movable)
        {
            this.ChangeState(SquareState.MovableHovering);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.CurrentState == SquareState.Hovering)
        {
            this.ChangeState(SquareState.Normal);
        }
        else if (this.CurrentState == SquareState.MovableHovering)
        {
            this.ChangeState(SquareState.Movable);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClick != null)
        {
            OnClick(this);
        }
    }

    public void ChangeState(SquareState squareState)
    {
        this.CurrentState = squareState;
        if(OnChangeState != null){
            OnChangeState(this, this.CurrentState);
        }
    }
}
}