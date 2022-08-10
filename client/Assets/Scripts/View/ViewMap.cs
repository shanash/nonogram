using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMap : ViewBase
{
    public RectTransform ParentTiles { get; private set; }

    public float TileSize { get; private set; }
    public float MapSideSize { get; private set; }
    public float QuestionSideSize { get; private set; }

    //private ViewLineQuestion m_viewLineQuestion = null;

    public void Init(ModelMap map, RectTransform parent, ref MapQuestion vertical, ref MapQuestion horizon)
    {
        base.Init(map);

        this.transform.parent = parent;
        RectTransform rt = this.transform as RectTransform;
        rt.anchorMin = new Vector2(0, 0);
        rt.anchorMax = new Vector2(1, 0);
        rt.offsetMin = new Vector2(0, 0);
        rt.offsetMax = new Vector2(0, 0);
        rt.pivot = new Vector2(0.5f, 0);
        rt.sizeDelta = new Vector2(0, rt.rect.width);

        int lengthQuestion = vertical.Length > horizon.Length ? vertical.Length : horizon.Length;

        TileSize = rt.rect.width / (map.LengthSide + lengthQuestion);
        float mapSideSize = TileSize * map.LengthSide;
        QuestionSideSize = rt.rect.width - mapSideSize;

        //SetQuestion(vertical, horizon, tileSize, questionSideSize);

        var goParentTiles = new GameObject("PanelTiles", typeof(RectTransform));
        ParentTiles = goParentTiles.GetComponent<RectTransform>();
        ParentTiles.parent = rt;
        ParentTiles.anchorMin = new Vector2(1, 0);
        ParentTiles.anchorMax = new Vector2(1, 0);
        ParentTiles.pivot = new Vector2(1, 0);
        ParentTiles.anchoredPosition = new Vector2(0, 0);
        ParentTiles.sizeDelta = new Vector2(mapSideSize, mapSideSize);

        vertical.InitView(ParentTiles, QuestionSideSize, TileSize);
        horizon.InitView(ParentTiles, QuestionSideSize, TileSize);
    }

    public void SetQuestion(List<List<int>> vertical, List<List<int>> horizon, float tileSize, float questionSideSize)
    {
        foreach (var line in vertical)
        {
            var goNumber = new GameObject("Number", typeof(RectTransform), typeof(ViewLineNumber));
            ViewLineNumber viewNumber = goNumber.GetComponent<ViewLineNumber>();
            viewNumber.Init(ViewLineNumber.Direction.Vertical, (RectTransform)this.transform, line, tileSize);
        }
    }
}