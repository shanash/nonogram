using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMap : ViewBase
{
    public void Init(Map map, RectTransform parent, int size)
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
    }
}