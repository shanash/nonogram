using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : Cursor.IMoveCursor
{
    private ViewMap m_view = null;

    private int m_size = 0;
    private List<Tile> m_listTile = new List<Tile>();
    public Cursor Cursor { get; private set; }

    public static Map Create(RectTransform parent, int size)
    {
        var map = new Map();
        map.Init(parent, size);
        return map;
    }

    private Map()
    {

    }

    public void OnMoveCursor(Cursor cursor, Cursor.MoveType type, int destPosIndex)
    {
        Debug.LogError($"OnMoveCursor destPosIndex: {destPosIndex}");
        cursor.SetTile(m_listTile[destPosIndex]);
    }

    private void Init(RectTransform parent, int size)
    {
        var goViewMap = new GameObject("ViewMap", typeof(RectTransform), typeof(ViewMap));
        m_view = goViewMap.GetComponent<ViewMap>();
        m_view.Init(parent, size);

        for (int i = 0; i < size * size; i++)
        {
            var tile = Tile.Create(parent, i, size);
            m_listTile.Add(tile);
        }

        Cursor = Cursor.Create(0, size);
        Cursor.SetTile(m_listTile[0]);
        Cursor.AddListner(this);
    }

    public Tile GetTile(int posIndex)
    {
        if (posIndex >= m_listTile.Count)
            return null;
        return m_listTile[posIndex];
    }
}


