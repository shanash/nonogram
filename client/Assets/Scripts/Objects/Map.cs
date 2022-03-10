using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : Cursor.IMoveCursor, IViewOrigin
{
    private ViewMap m_view = null;

    private int m_size = 0;
    private List<Tile> m_listTile = new List<Tile>();
    private int[] m_answer = null;

    private List<List<int>> m_questionVertical = new List<List<int>>();
    private List<List<int>> m_questionHorizon = new List<List<int>>();

    public Cursor Cursor { get; private set; }

    public static Map Create(RectTransform parent, int[] answer)
    {
        var map = new Map();
        if (!map.Init(parent, answer))
        {
            Debug.Assert(false, "망함");
            return null;
        }
        return map;
    }

    private Map()
    {

    }

    public void OnMoveCursor(Cursor cursor, Cursor.MoveType type, int destPosIndex)
    {
        cursor.SetTile(m_listTile[destPosIndex]);
    }

    private bool Init(RectTransform parent, int[] answer)
    {
        double dSize = Math.Sqrt(answer.Length);
        // 제곱근이 양의 정수가 아니라면 생성 실패
        if (dSize % 1 != 0 || dSize < 0)
            return false;

        var goViewMap = new GameObject("ViewMap", typeof(RectTransform), typeof(ViewMap));
        m_view = goViewMap.GetComponent<ViewMap>();

        m_answer = answer;
        int size = (int)dSize;

        SetQuestion(size);
        
        m_view.Init(this, parent, size);

        for (int i = 0; i < size * size; i++)
        {
            var tile = Tile.Create((RectTransform)goViewMap.transform, i, size);
            m_listTile.Add(tile);
        }

        Cursor = Cursor.Create(0, size);
        Cursor.SetTile(m_listTile[0]);
        Cursor.AddListner(this);

        return true;
    }

    public Tile GetTile(int posIndex)
    {
        if (posIndex >= m_listTile.Count)
            return null;
        return m_listTile[posIndex];
    }

    public void OnUpdate(ViewBase viewBase)
    {

    }

    private void SetQuestion(int size)
    {
        int iTile = 0;
        
        // 세로 문제 작성
        for (int iQuestion = 0; iQuestion < size; iQuestion++)
        {
            List<int> lineQuestion = new List<int>();
            int value = 0;
            for (; iTile < size * (iQuestion+1); iTile++)
            {
                if (m_answer[iTile] == 1)
                {
                    value++;
                }
                else if (value > 0)
                {
                    lineQuestion.Add(value);
                    value = 0;
                }
            }

            if (value > 0 || lineQuestion.Count == 0)
            {
                lineQuestion.Add(value);
            }

            m_questionVertical.Add(lineQuestion);
        }

        //가로 문제 작성
        for (int iQuestion = 0; iQuestion < size; iQuestion++)
        {
            List<int> lineQuestion = new List<int>();
            int value = 0;
            for (iTile = iQuestion; iTile < size * size; iTile+=size)
            {
                if (m_answer[iTile] == 1)
                {
                    value++;
                }
                else if (value > 0)
                {
                    lineQuestion.Add(value);
                    value = 0;
                }
            }

            if (value > 0 || lineQuestion.Count == 0)
            {
                lineQuestion.Add(value);
            }

            m_questionHorizon.Add(lineQuestion);
        }
    }
}


