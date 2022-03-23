using UnityEngine;
using System;
using System.Collections.Generic;

public class Tile : MapCompBase, IViewOrigin
{
    public enum TileType
    {
        None = 0,
        Empty,
        Painted,
        Crossed,
        MAX,
    }

    public TileType Type { 
        get
        {
            return m_type;
        }
        set
        {
            m_type = value;
        }
    }

    private TileType m_type = TileType.None;
    public ViewTile View { get { return m_view; } }
    private ViewTile m_view = null;
    private Map m_map = null;

    public static Tile Create(Map map, RectTransform parent, int posIndex, int sideLength)
    {
        var tile = new Tile(posIndex, sideLength);
        tile.Init(map, parent);
        return tile;
    }

    protected Tile(int posIndex, int mapSize)
        : base(posIndex, mapSize)
    {
        m_type = TileType.Empty;
    }

    private void Init(Map map, RectTransform parent)
    {
        m_map = map;
        var goViewTile = new GameObject($"ViewTile{PosIndex}", typeof(RectTransform), typeof(ViewTile));
        m_view = goViewTile.GetComponent<ViewTile>();
        m_view.Init(this, parent, PosIndex, m_sideLength);
    }

    public void OnUpdate(ViewBase viewBase)
    {
        if (viewBase is ViewTile)
        {
            var viewTile = viewBase as ViewTile;

            switch(this.Type)
            {
                case TileType.Painted:
                    if (viewTile.ImageName != "dot")
                    {
                        viewTile.SetImage("dot", Color.black);
                    }
                    break;
                case TileType.Crossed:
                    if (viewTile.ImageName != "x")
                    {
                        viewTile.SetImage("x", Color.gray);
                    }
                    break;
                case TileType.Empty:
                    if (viewTile.ImageName != string.Empty)
                    {
                        viewTile.SetImage(string.Empty, Color.white);
                    }
                    break;
            }
        }
    }
}
