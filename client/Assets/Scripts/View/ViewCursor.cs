using UnityEngine;
using UnityEngine.InputSystem;

public class ViewCursor : MonoBehaviour
{
    private Cursor m_cursor = null;

    private void Update()
    {
        if (m_cursor == null) return;

        if (transform.parent != m_cursor.Tile.View.transform)
            SetParent(m_cursor.Tile.View);
    }

    public void Init(Cursor cursor)
    {
        m_cursor = cursor;

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

    public void OnPaint(InputAction.CallbackContext context)
    {
        Debug.Log($"OnPaint : {context}");
    }

    public void OnX(InputAction.CallbackContext context)
    {
        Debug.Log($"OnX : {context}");
    }

    public void OnUpArrow(InputAction.CallbackContext context)
    {
        
    }

    public void OnDownArrow(InputAction.CallbackContext context)
    {

    }

    public void OnLeftArrow(InputAction.CallbackContext context)
    {

    }

    public void OnRightArrow(InputAction.CallbackContext context)
    {

    }
}
