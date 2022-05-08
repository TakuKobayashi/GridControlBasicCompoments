using System;
using UnityEngine;

[Serializable]
public struct BoardPosition
{
    [SerializeField] public int x;
    [SerializeField] public int y;

    public BoardPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

}
