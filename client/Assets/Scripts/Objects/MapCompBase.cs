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

    public int PosX
    { 
        get { if (PosIndex < 0 || PosIndex >= IndexCount) return 0; return PosIndex % m_sideLength; }
        private set
        {
            int modifyX = value;
            while (modifyX < 0)
            {
                modifyX += m_sideLength;
            }

            modifyX = modifyX % m_sideLength;
            PosIndex = modifyX + PosY * m_sideLength;
        }
    }
    public int PosY
    { 
        get { if (PosIndex < 0 || PosIndex >= IndexCount) return 0; return PosIndex / m_sideLength; }
        private set
        {
            int modifyY = value;
            while(modifyY < 0)
            {
                modifyY += m_sideLength;
            }

            modifyY = modifyY % m_sideLength;
            PosIndex = PosX + modifyY * m_sideLength;
        }
    }
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
        switch(moveType)
        {
            case MoveType.Up:
                PosY--;
                break;
            case MoveType.Down:
                PosY++;
                break;
            case MoveType.Right:
                PosX++;
                break;
            case MoveType.Left:
                PosX--;
                break;
        }
    }
}
