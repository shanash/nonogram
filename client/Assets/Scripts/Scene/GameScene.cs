using UnityEngine;
using UnityEngine.InputSystem;

public class GameScene : SceneBase
{
    private Map m_map = null;
    private Cursor m_cursor = null;
    protected override void Awake()
    {
        base.Awake();

        m_map = Map.Create(10);
        m_cursor = m_map.Cursor;
    }

    public override void OnOK(InputAction.CallbackContext context)
    {
        base.OnOK(context);
        if (context.started)
        {
            var tile = m_map.GetTile(m_cursor.PosIndex);
            if (tile.Type != Tile.TileType.Empty)
                tile.Type = Tile.TileType.Empty;
            else
                tile.Type = Tile.TileType.Painted;
        }
    }

    public override void OnCancel(InputAction.CallbackContext context)
    {
        base.OnCancel(context);
        if (context.started)
        {
            var tile = m_map.GetTile(m_cursor.PosIndex);
            if (tile.Type != Tile.TileType.Empty)
                tile.Type = Tile.TileType.Empty;
            else
                tile.Type = Tile.TileType.Crossed;
        }
    }

    public override void OnUp(InputAction.CallbackContext context)
    {
        base.OnUp(context);
        if (context.started)
            m_cursor.Move(Cursor.MoveType.Up);
    }

    public override void OnDown(InputAction.CallbackContext context)
    {
        base.OnDown(context);
        if (context.started)
            m_cursor.Move(Cursor.MoveType.Down);
    }

    public override void OnRight(InputAction.CallbackContext context)
    {
        base.OnRight(context);
        if (context.started)
            m_cursor.Move(Cursor.MoveType.Right);
    }

    public override void OnLeft(InputAction.CallbackContext context)
    {
        base.OnLeft(context);
        if (context.started)
            m_cursor.Move(Cursor.MoveType.Left);
    }
}
