using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MapCompBase
{
    public interface IMoveCursor
    {
        void OnMoveCursor(Cursor cursor, Cursor.MoveType type, int destPosIndex);
    }

    public enum CursorMode
    {
        None = 0,
        Normal,
        Paint,
        Cross,
        Remove,
    }

    public CursorMode Mode {
        get
        {
            return m_mode;
        }
        set
        {
            m_mode = value;
            FillTile();
        }
    }
    private CursorMode m_mode = CursorMode.None;
    private List<IMoveCursor> m_listeners = new List<IMoveCursor>();
    public Tile Tile { get { return m_hasTile; } }
    private Tile m_hasTile = null;
    private ViewCursor m_view = null;

    public static Cursor Create(int posIndex, int mapSize)
    {
        var cursor = new Cursor(posIndex, mapSize);
        cursor.Init();

        return cursor;
    }

    protected Cursor(int posIndex, int mapSize)
        : base(posIndex, mapSize)
    {

    }

    private void Init()
    {
        var goViewCursor = new GameObject($"ViewTile{PosIndex}", typeof(RectTransform), typeof(ViewCursor));
        m_view = goViewCursor.GetComponent<ViewCursor>();
        m_view.Init();
    }

    public void AddListner(IMoveCursor listner)
    {
        m_listeners.Add(listner);
    }

    public override void Move(MoveType moveType)
    {
        base.Move(moveType);
        foreach (var listener in m_listeners)
        {
            listener.OnMoveCursor(this, moveType, PosIndex);
        }
        FillTile();
        Debug.LogError($"Move : {moveType}");
    }

    public void SetTile(Tile tile)
    {
        m_hasTile = tile;
        m_view.SetParent(tile.View);
    }

    private void FillTile()
    {
        switch (m_mode)
        {
            case CursorMode.Paint:
                m_hasTile.Type = Tile.TileType.Painted;
                break;
            case CursorMode.Cross:
                m_hasTile.Type = Tile.TileType.Crossed;
                break;
            case CursorMode.Remove:
                m_hasTile.Type = Tile.TileType.Empty;
                break;
        }
    }
}
