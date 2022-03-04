using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapCompBase
{
    public enum MoveType
    {
        None = 0,
        Up,
        Right,
        Down,
        Left,
    }

    public int PosX { get { if (PosIndex < 0 || PosIndex >= IndexCount) return 0; return PosIndex % m_mapSize; } }
    public int PosY { get { if (PosIndex < 0 || PosIndex >= IndexCount) return 0; return PosIndex / m_mapSize; } }
    public int PosIndex { get; private set; }
    protected int m_mapSize = 0;
    public int IndexCount { get { return m_mapSize * m_mapSize; } }

    protected MapCompBase(int posIndex, int mapSize)
    {
        PosIndex = posIndex;
        m_mapSize = mapSize;
    }

    public virtual void Move(MoveType moveType)
    {
        int prePosX = PosX;
        int prePosY = PosY;
        switch(moveType)
        {
            case MoveType.Up:
                PosIndex -= m_mapSize;
                if (PosIndex < 0)
                {
                    PosIndex += IndexCount;
                }
                break;
            case MoveType.Down:
                PosIndex += m_mapSize;
                if (PosIndex >= IndexCount)
                {
                    PosIndex -= IndexCount;
                }
                break;
            case MoveType.Right:
                PosIndex++;
                if (prePosY < PosY)
                {
                    PosIndex -= m_mapSize;
                }
                break;
            case MoveType.Left:
                PosIndex--;
                if (prePosY > PosY)
                {
                    PosIndex += m_mapSize;
                }
                break;
        }

        Debug.LogError($"PosX : {PosX}, PosY : {PosY}");
    }
}
