﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Timers;

public class Cursor : MapCompBase, PlayerControls.ICursorActions, IViewOrigin, ISubject
{
    public interface IMoveCursor
    {
        void OnMoveCursor(Cursor cursor);
    }

    public enum CursorMode
    {
        None = 0,
        Normal,
        Paint,
        Cross,
        Remove,
    }

    // 방향키 누르고 있을때 반복입력 주기 1000 = 1초
    private readonly static int kREPEAT_INPUT_TERM = 100;

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

    //반복입력값
    private MoveType m_repeatInputMove = MoveType.None;
    private Timer m_repeatTimer = null;

    // 타일입력시에 다른 오브젝트의 업데이트용
    private List<IObserver> m_observers = new List<IObserver>();

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
        m_mode = CursorMode.Normal;
        m_repeatInputMove = MoveType.None;

        m_repeatTimer = new Timer();
        m_repeatTimer.Interval = kREPEAT_INPUT_TERM;
        m_repeatTimer.Elapsed += new ElapsedEventHandler(MoveRepeat);

        var goViewCursor = new GameObject($"Cursor", typeof(RectTransform), typeof(ViewCursor));
        m_view = goViewCursor.GetComponent<ViewCursor>();
        m_view.Init(this);
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
            listener.OnMoveCursor(this);
        }
        FillTile();
    }

    private void StartMove(MoveType moveType)
    {
        if (m_repeatInputMove == MoveType.None)
            m_repeatTimer.Start();

        m_repeatInputMove = moveType;
    }

    private void EndMove(MoveType moveType)
    {
        if (m_repeatInputMove == moveType)
        {
            m_repeatInputMove = MoveType.None;
            m_repeatTimer.Stop();
        }
    }

    public void SetTile(Tile tile)
    {
        m_hasTile = tile;
        //m_view.SetParent(tile.View);
    }

    private void FillTile()
    {
        Tile.TileType pastType = m_hasTile.Type;
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

        if (pastType != m_hasTile.Type) // 타일타입이 변경!
        {
            
            /*
            if (m_map.CheckClear())
            {
                GameScene scene = (GameScene)SceneManager.I.CurrentScene;
                scene.CreateResultPopup();
            }
            */
        }

        Notify();
    }

    public virtual void OnOK(InputAction.CallbackContext context)
    {
        PrintContext("OnOK", context);
        if (context.started)
        {
            if (Tile.Type == Tile.TileType.Empty)
                Mode = Cursor.CursorMode.Paint;
            else
                Mode = Cursor.CursorMode.Remove;
        }
        else if (context.canceled)
        {
            Mode = Cursor.CursorMode.Normal;
        }
    }

    public virtual void OnCancel(InputAction.CallbackContext context)
    {
        PrintContext("OnCancel", context);
        if (context.started)
        {
            if (Tile.Type == Tile.TileType.Empty)
                Mode = Cursor.CursorMode.Cross;
            else
                Mode = Cursor.CursorMode.Remove;
        }
        else if (context.canceled)
        {
            Mode = Cursor.CursorMode.Normal;
        }
    }

    public virtual void OnUp(InputAction.CallbackContext context)
    {
        PrintContext("OnUp", context);
        _OnMove(context, Cursor.MoveType.Up);
    }

    public virtual void OnLeft(InputAction.CallbackContext context)
    {
        PrintContext("OnLeft", context);
        _OnMove(context, Cursor.MoveType.Left);
    }

    public virtual void OnDown(InputAction.CallbackContext context)
    {
        PrintContext("OnDown", context);
        _OnMove(context, Cursor.MoveType.Down);
    }

    public virtual void OnRight(InputAction.CallbackContext context)
    {
        PrintContext("OnRight", context);
        _OnMove(context, Cursor.MoveType.Right);
    }

    private void _OnMove(InputAction.CallbackContext context, MoveType type)
    {
        if (context.started)
        {
            Move(type);
        }
        else if (context.performed)
        {
            StartMove(type);
        }
        else if (context.canceled)
        {
            EndMove(type);
        }
    }

    private void PrintContext(string Label, InputAction.CallbackContext context)
    {
        Debug.Log($"{Label} : {context}");
    }

    private void MoveRepeat(object sender, ElapsedEventArgs e)
    {
        Move(m_repeatInputMove);
    }

    public void OnUpdate(ViewBase viewBase)
    {
        if (viewBase is ViewCursor)
        {
            var viewCursor = viewBase as ViewCursor;
            if (Tile.View.transform != viewCursor.transform.parent)
            {
                viewCursor.SetParent(Tile.View);
            }
        }
    }

    public void AddObserver(IObserver o)
    {
        m_observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        m_observers.Remove(o);
    }

    public void Notify()
    {
        foreach (var item in m_observers)
        {
            item.OnNotify(this);
        }
    }
}
