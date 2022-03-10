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

    public int PosX { get { if (PosIndex < 0 || PosIndex >= IndexCount) return 0; return PosIndex % m_sideLength; } }
    public int PosY { get { if (PosIndex < 0 || PosIndex >= IndexCount) return 0; return PosIndex / m_sideLength; } }
    public int PosIndex { get; private set; }
    protected int m_sideLength = 0;
    public int IndexCount { get { return m_sideLength * m_sideLength; } }

    protected MapCompBase(int posIndex, int sideLength)
    {
        PosIndex = posIndex;
        m_sideLength = sideLength;
    }

    public virtual void Move(MoveType moveType)
    {
        int prePosX = PosX;
        int prePosY = PosY;
        switch(moveType)
        {
            case MoveType.Up:
                PosIndex -= m_sideLength;
                if (PosIndex < 0)
                {
                    PosIndex += IndexCount;
                }
                else if (PosIndex >= IndexCount)
                {
                    PosIndex -= IndexCount;
                }
                break;
            case MoveType.Down:
                PosIndex += m_sideLength;
                if (PosIndex < 0)
                {
                    PosIndex += IndexCount;
                }
                else if (PosIndex >= IndexCount)
                {
                    PosIndex -= IndexCount;
                }
                break;
            case MoveType.Right:
                PosIndex++;
                if (PosIndex < 0)
                {
                    PosIndex += IndexCount;
                }
                else if (PosIndex >= IndexCount)
                {
                    PosIndex -= IndexCount;
                }

                if (prePosY < PosY)
                {
                    PosIndex -= m_sideLength;
                }
                break;
            case MoveType.Left:
                PosIndex--;
                if (PosIndex < 0)
                {
                    PosIndex += IndexCount;
                }
                else if (PosIndex >= IndexCount)
                {
                    PosIndex -= IndexCount;
                }
                if (prePosY > PosY)
                {
                    PosIndex += m_sideLength;
                }
                break;
        }
    }
}
