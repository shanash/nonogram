using UnityEngine;
using UnityEngine.UI;

public class ViewQuestion : MonoBehaviour
{
    private MapQuestion m_question = null;

    public void Init(MapQuestion question, RectTransform parent, float size, float tileSize)
    {
        // 기본 View 구성
        m_question = question;
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.parent = parent;
        rt.anchorMin = new Vector2(0, 1);
        rt.anchorMax = new Vector2(0, 1);

        HorizontalOrVerticalLayoutGroup vlg = null;
        switch (question.Dir)
        {
            case MapQuestion.Direction.Vertical:
                rt.pivot = Vector2.one;
                rt.sizeDelta = new Vector2(size, parent.rect.height);
                vlg = this.gameObject.AddComponent<VerticalLayoutGroup>();
                vlg.childAlignment = TextAnchor.UpperRight;
                break;
            case MapQuestion.Direction.Horizon:
                rt.pivot = Vector2.zero;
                rt.sizeDelta = new Vector2(parent.rect.width, size);
                vlg = this.gameObject.AddComponent<HorizontalLayoutGroup>();
                vlg.childAlignment = TextAnchor.LowerLeft;
                break;
        }
        rt.anchoredPosition = Vector2.zero;

        vlg.childControlWidth = false;
        vlg.childControlHeight = false;
        vlg.childForceExpandWidth = false;
        vlg.childForceExpandHeight = false;

        var font = Resources.Load<Font>("Binggrae_Regular");
        // 숫자 라인 UI
        for (int i = 0; i < question.CountLine; i++)
        {
            var goLineNum = new GameObject("LineNumber", typeof(RectTransform));
            var rtLineNum = goLineNum.GetComponent<RectTransform>();
            rtLineNum.parent = rt;
            HorizontalOrVerticalLayoutGroup lg = null;
            switch (question.Dir)
            {
                case MapQuestion.Direction.Vertical:
                    rtLineNum.sizeDelta = new Vector2(size, tileSize);
                    lg = goLineNum.AddComponent<HorizontalLayoutGroup>();
                    lg.childAlignment = TextAnchor.MiddleRight;
                    break;
                case MapQuestion.Direction.Horizon:
                    rtLineNum.sizeDelta = new Vector2(tileSize, size);
                    lg = goLineNum.AddComponent<VerticalLayoutGroup>();
                    lg.childAlignment = TextAnchor.LowerCenter;
                    break;
            }

            lg.childControlWidth = false;
            lg.childControlHeight = false;
            lg.childForceExpandWidth = false;
            lg.childForceExpandHeight = false;

            foreach(var num in question.GetLine(i))
            {
                var goNum = new GameObject("Number", typeof(RectTransform));
                var rtNum = goNum.GetComponent<RectTransform>();
                rtNum.parent = rtLineNum;
                rtNum.anchoredPosition = Vector2.zero;
                rtNum.sizeDelta = new Vector2(tileSize, tileSize);
                var textNum = goNum.AddComponent<Text>();
                textNum.font = font;
                textNum.color = Color.white;
                textNum.fontSize = 100;
                textNum.resizeTextForBestFit = true;
                textNum.text = num.ToString();
                textNum.alignment = TextAnchor.MiddleCenter;
            }
        }
    }
}
