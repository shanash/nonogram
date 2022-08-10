using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModelMap : Cursor.IMoveCursor, IViewOrigin, IObserver
{
    private ViewMap m_view = null;

    public int Count { get { return m_listTile.Count; } }
    public int LengthSide { get; private set; }

    private List<ModelTile> m_listTile = new List<ModelTile>();
    private int[] m_answer = null;

    private MapQuestion m_vertical = null;
    private MapQuestion m_horizon = null;

    public Cursor Cursor { get; private set; }

    public static ModelMap Create(RectTransform parent, int[] answer)
    {
        var map = new ModelMap();
        if (!map.Init(parent, answer))
        {
            Debug.Assert(false, "망함");
            return null;
        }
        return map;
    }

    private ModelMap()
    {

    }

    public void OnMoveCursor(Cursor cursor)
    {
        cursor.SetTile(m_listTile[cursor.PosIndex]);
    }

    private bool Init(RectTransform parent, int[] answer)
    {
        double dSize = Math.Sqrt(answer.Length);
        // 제곱근이 양의 정수가 아니라면 생성 실패
        if (dSize % 1 != 0 || dSize < 0)
            return false;

        m_answer = answer;
        LengthSide = (int)dSize;

        var goViewMap = new GameObject("ViewMap", typeof(RectTransform), typeof(ViewMap));
        m_view = goViewMap.GetComponent<ViewMap>();

        m_vertical = MapQuestion.Create(MapQuestion.Direction.Vertical, answer);
        m_horizon = MapQuestion.Create(MapQuestion.Direction.Horizon, answer);

        m_view.Init(this, parent, ref m_vertical, ref m_horizon);

        for (int i = 0; i < LengthSide * LengthSide; i++)
        {
            var tile = ModelTile.Create(this, m_view.ParentTiles, i, LengthSide);
            m_listTile.Add(tile);
        }

        Cursor = Cursor.Create(0, LengthSide);
        Cursor.SetTile(m_listTile[0]);
        Cursor.AddListner(this);
        Cursor.AddObserver(this);

        m_horizon.Init(m_listTile, Cursor);
        m_vertical.Init(m_listTile, Cursor);

        return true;
    }

    public ModelTile GetTile(int posIndex)
    {
        if (posIndex >= m_listTile.Count)
            return null;
        return m_listTile[posIndex];
    }

    public void OnUpdate(ViewBase viewBase)
    {

    }

    public bool CheckAndClear()
    {
        foreach(var tile in m_listTile)
        {
            if (m_answer[tile.PosIndex] == 1 && tile.Type != ModelTile.TileType.Painted)
                return false;
            if (m_answer[tile.PosIndex] == 0 && tile.Type == ModelTile.TileType.Painted)
                return false;
        }

        GameScene scene = (GameScene)SceneManager.I.CurrentScene;
        scene.CreateResultPopup();

        return true;
    }

    public void OnNotify(ISubject s)
    {
        if (s is Cursor)
        {
            CheckAndClear();
        }
    }
}


