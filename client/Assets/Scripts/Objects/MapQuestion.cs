using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapQuestion
{
    public enum Direction
    {
        None = 0,
        Vertical,
        Horizon,
    }

    private int m_length = 0;
    public int Length
    {
        get
        {
            if (m_length == 0)
            {
                foreach (var line in m_listQuestion)
                {
                    if (line.Count > m_length)
                        m_length = line.Count;
                }
            }

            return m_length;
        }
    }

    public int CountLine
    {
        get
        {
            return m_listQuestion.Count;
        }
    }
    public Direction Dir { get { return m_direction; } }
    private Direction m_direction = Direction.None;
    private List<List<int>> m_listQuestion = new List<List<int>>();
    private ViewQuestion m_view = null;

    public static MapQuestion Create(Direction dir, int[] answer)
    {
        var question = new MapQuestion();
        if (!question.Init(dir, answer))
        {
            return null;
        }

        return question;
    }

    private bool Init(Direction dir, int[] answer)
    {
        double dSize = Math.Sqrt(answer.Length);
        // 제곱근이 양의 정수가 아니라면 생성 실패
        if (dSize % 1 != 0 || dSize < 0)
            return false;

        m_direction = dir;
        int size = (int)dSize;
        int iTile = 0;

        for (int iQuestion = 0; iQuestion < size; iQuestion++)
        {
            List<int> lineQuestion = new List<int>();
            int value = 0;
            switch (dir)
            {
                case Direction.Vertical:
                    for (; iTile < size * (iQuestion + 1); iTile++)
                    {
                        if (answer[iTile] == 1)
                        {
                            value++;
                        }
                        else if (value > 0)
                        {
                            lineQuestion.Add(value);
                            value = 0;
                        }
                    }
                    break;
                case Direction.Horizon:
                    for (iTile = iQuestion; iTile < size * size; iTile += size)
                    {
                        if (answer[iTile] == 1)
                        {
                            value++;
                        }
                        else if (value > 0)
                        {
                            lineQuestion.Add(value);
                            value = 0;
                        }
                    }
                    break;
            }

            if (value > 0 || lineQuestion.Count == 0)
            {
                lineQuestion.Add(value);
            }
            
            m_listQuestion.Add(lineQuestion);
        }

        return true;
    }

    public void InitView(RectTransform parent, float size, float tileSize)
    {
        var goViewQuestion = new GameObject("ViewQuestion", typeof(RectTransform), typeof(ViewQuestion));
        m_view = goViewQuestion.GetComponent<ViewQuestion>();
        m_view.Init(this, parent, size, tileSize);
    }

    public List<int> GetLine(int index)
    {
        if (index >= m_listQuestion.Count || index < 0) return null;
        return m_listQuestion[index];
    }
}
