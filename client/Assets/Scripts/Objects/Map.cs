using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private int m_size = 0;
    private List<Tile> m_listTile = new List<Tile>();
    public Cursor Cursor { get; private set; }

    public static Map Create(int size)
    {
        var map = new Map();
        map.Init(size);
        return map;
    }

    public void OnMoveCursor(Cursor cursor, Cursor.MoveType type)
    {
        throw new System.NotImplementedException();
    }

    private void Init(int size)
    {
        for (int i = 0; i < size * size; i++)
        {
            var tile = new Tile(Tile.TileType.Empty, i, size);
            m_listTile.Add(tile);
        }

        Cursor = Cursor.Create(0, size);
        /*
        var goViewMap = new GameObject("ViewMap", typeof(ViewMap));
        goViewMap.transform.parent = parentView;
        var viewMap = goViewMap.GetComponent<ViewMap>();
        m_size = size;
        for (int i = 0; i < size * size; i++)
        {
            var tile = new Tile();
            viewMap.AddTileView(tile.GetView());
        }
        */
    }

    public Tile GetTile(int posIndex)
    {
        if (posIndex >= m_listTile.Count)
            return null;
        return m_listTile[posIndex];
    }
}


