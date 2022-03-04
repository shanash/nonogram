using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveCursor
{

    void OnMoveCursor(Cursor cursor, Cursor.MoveType type);
}

public class Cursor : MapCompBase
{
    private List<IMoveCursor> m_listeners = new List<IMoveCursor>();

    public static Cursor Create(int posIndex, int mapSize)
    {
        return new Cursor(posIndex, mapSize);
    }

    protected Cursor(int posIndex, int mapSize)
        : base(posIndex, mapSize)
    {

    }

    public void AddListner(IMoveCursor listner)
    {
        m_listeners.Add(listner);
    }

    public override void Move(MoveType moveType)
    {
        base.Move(moveType);
        Debug.LogError($"Move : {moveType}");
    }
}
