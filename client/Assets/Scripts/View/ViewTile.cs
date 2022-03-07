using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTile : MonoBehaviour
{
    private readonly static int SPACE = 2;

    public void Init(RectTransform parent, int posIndex, int sideLength)
    {
        this.transform.parent = parent;
        float mapSize = parent.rect.width;
        int numSpace = sideLength - 1;
        int numBigSpace = numSpace / 5;
        float tileSize = (mapSize - numSpace * SPACE - numBigSpace * SPACE) / sideLength;

        int posX = (posIndex % sideLength);
        float tileX = posX * (tileSize + SPACE) + (posX/5) * SPACE; // X축 5칸째는 두배로 띄어줍니다.
        int posY = (posIndex / sideLength);
        float tileY = -posY * (tileSize + SPACE) - (posY / 5) * SPACE; // Y축 5칸째는 두배로 띄어줍니다.

        RectTransform rt = this.transform as RectTransform;
        rt.anchorMin = new Vector2(0, 1);
        rt.anchorMax = new Vector2(0, 1);
        rt.pivot = new Vector2(0, 1);
        rt.sizeDelta = new Vector2(tileSize, tileSize);
        rt.anchoredPosition = new Vector2(tileX, tileY);

        this.gameObject.AddComponent<UnityEngine.UI.Image>();
    }
}
