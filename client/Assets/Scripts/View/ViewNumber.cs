using UnityEngine;
using UnityEngine.UI;

public class ViewNumber : MonoBehaviour
{
    private int m_num = 0;
    private Text m_text = null;

    public void Init(RectTransform parent, int num, float size)
    {
        RectTransform rt = this.transform as RectTransform;
        rt.parent = parent;

        rt.anchoredPosition = Vector2.zero;
        rt.sizeDelta = new Vector2(size, size);
        //rt.anchorMin = new Vector2(0, 0);
        //rt.anchorMax = new Vector2(1, 1);
        //rt.offsetMin = new Vector2(0, 0);
        //rt.offsetMax = new Vector2(0, 0);

        m_text = this.gameObject.AddComponent<Text>();
        m_text.text = num.ToString();
    }
}
