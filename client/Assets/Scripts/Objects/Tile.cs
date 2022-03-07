using UnityEngine;

public class Tile : MapCompBase
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
            UnityEngine.Debug.Log($"Set {PosX}, {PosY} Tile : {value}");
            m_type = value;
        }
    }

    private TileType m_type = TileType.None;
    private ViewTile m_view = null;

    public static Tile Create(RectTransform parent, int posIndex, int sideLength)
    {
        var tile = new Tile(posIndex, sideLength);
        tile.Init(parent);
        return tile;
    }

    protected Tile(int posIndex, int mapSize)
        : base(posIndex, mapSize)
    {
        Type = TileType.Empty;
    }

    private void Init(RectTransform parent)
    {
        var goViewTile = new GameObject($"ViewTile{PosIndex}", typeof(RectTransform), typeof(ViewTile));
        m_view = goViewTile.GetComponent<ViewTile>();
        m_view.Init(parent, PosIndex, m_sideLength);
    }

}
