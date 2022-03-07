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

    public static Tile Create(RectTransform parent, int posIndex, int mapSize)
    {
        var tile = new Tile(posIndex, mapSize);
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

    }

}
