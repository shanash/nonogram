using UnityEngine;
using UnityEngine.InputSystem;

public class GameScene : SceneBase
{
    [SerializeField]
    private RectTransform m_parentViewMap = null;

    private Map m_map = null;
    private Cursor m_cursor = null;
    protected override void Awake()
    {
        base.Awake();

        m_map = Map.Create(m_parentViewMap, 10);
        m_cursor = m_map.Cursor;
    }

    public override void OnOK(InputAction.CallbackContext context)
    {
        base.OnOK(context);
        if (context.started)
        {
            if (m_cursor.Tile.Type == Tile.TileType.Empty)
                m_cursor.Mode = Cursor.CursorMode.Paint;
            else
                m_cursor.Mode = Cursor.CursorMode.Remove;
        }
        else if (context.canceled)
        {
            m_cursor.Mode = Cursor.CursorMode.Normal;
        }
    }

    public override void OnCancel(InputAction.CallbackContext context)
    {
        base.OnCancel(context);
        if (context.started)
        {
            if (m_cursor.Tile.Type == Tile.TileType.Empty)
                m_cursor.Mode = Cursor.CursorMode.Cross;
            else
                m_cursor.Mode = Cursor.CursorMode.Remove;
        }
        else if (context.canceled)
        {
            m_cursor.Mode = Cursor.CursorMode.Normal;
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
