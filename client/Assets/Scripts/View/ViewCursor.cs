using UnityEngine;
using UnityEngine.InputSystem;

public class ViewCursor : ViewBase
{
    public void Init(Cursor cursor)
    {
        base.Init(cursor);

        var rt = (RectTransform)this.transform;
        rt.anchorMin = new Vector2(0, 1);
        rt.anchorMax = new Vector2(0, 1);
        rt.pivot = new Vector2(0, 1);

        UnityEngine.UI.Image image = this.gameObject.AddComponent<UnityEngine.UI.Image>();
        image.color = Color.red;
    }

    public void SetParent(ViewTile viewTile)
    {
        transform.parent = viewTile.transform;
        var rt = (RectTransform)this.transform;
        var rtTile = (RectTransform)viewTile.transform;
        rt.sizeDelta = rtTile.sizeDelta;
        rt.anchoredPosition = Vector2.zero;
    }
}
