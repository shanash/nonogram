using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : Cursor.IMoveCursor, IViewOrigin
{
    private ViewMap m_view = null;

    public int Count { get { return m_listTile.Count; } }
    public int LengthSide { get; private set; }

    private List<Tile> m_listTile = new List<Tile>();
    private int[] m_answer = null;

    private MapQuestion m_vertical = null;
    private MapQuestion m_horizon = null;

    public Cursor Cursor { get; private set; }

    public static Map Create(RectTransform parent, int[] answer)
    {
        var map = new Map();
        if (!map.Init(parent, answer))
        {
            Debug.Assert(false, "망함");
            return null;
        }
        return map;
    }

    private Map()
    {

    }

    public void OnMoveCursor(Cursor cursor, Cursor.MoveType type, int destPosIndex)
    {
        cursor.SetTile(m_listTile[destPosIndex]);
    }

    private bool Init(RectTransform parent, int[] answer)
    {
        double dSize = Math.Sqrt(answer.Length);
        // 제곱근이 양의 정수가 아니라면 생성 실패
        if (dSize % 1 != 0 || dSize < 0)
            return false;

        m_vertical = MapQuestion.Create(MapQuestion.Direction.Vertical, answer);
        m_horizon = MapQuestion.Create(MapQuestion.Direction.Horizon, answer);

        m_answer = answer;
        LengthSide = (int)dSize;

        var goViewMap = new GameObject("ViewMap", typeof(RectTransform), typeof(ViewMap));
        m_view = goViewMap.GetComponent<ViewMap>();

        m_view.Init(this, parent, ref m_vertical, ref m_horizon);

        for (int i = 0; i < LengthSide * LengthSide; i++)
        {
            var tile = Tile.Create(m_view.ParentTiles, i, LengthSide);
            m_listTile.Add(tile);
        }

        Cursor = Cursor.Create(0, LengthSide);
        Cursor.SetTile(m_listTile[0]);
        Cursor.AddListner(this);

        return true;
    }

    public Tile GetTile(int posIndex)
    {
        if (posIndex >= m_listTile.Count)
            return null;
        return m_listTile[posIndex];
    }

    public void OnUpdate(ViewBase viewBase)
    {

    }
}


