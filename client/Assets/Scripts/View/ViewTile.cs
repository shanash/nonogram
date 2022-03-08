using UnityEngine;
using UnityEngine.UI;

public class ViewTile : ViewBase
{
    private readonly static int kSPACE = 2;
    public string ImageName
    {
        get
        {
            if (m_image == null) return string.Empty;
            if (m_image.sprite == null) return string.Empty;
            return m_image.sprite.name;
        }
    }
    private Image m_image = null;

    public void Init(Tile tile, RectTransform parent, int posIndex, int sideLength)
    {
        base.Init(tile);

        this.transform.parent = parent;
        float mapSize = parent.rect.width;
        int numSpace = sideLength - 1;
        int numBigSpace = numSpace / 5;
        float tileSize = (mapSize - numSpace * kSPACE - numBigSpace * kSPACE) / sideLength;

        int posX = (posIndex % sideLength);
        float tileX = posX * (tileSize + kSPACE) + (posX/5) * kSPACE; // X축 5칸째는 두배로 띄어줍니다.
        int posY = (posIndex / sideLength);
        float tileY = -posY * (tileSize + kSPACE) - (posY / 5) * kSPACE; // Y축 5칸째는 두배로 띄어줍니다.

        RectTransform rt = this.transform as RectTransform;
        rt.anchorMin = new Vector2(0, 1);
        rt.anchorMax = new Vector2(0, 1);
        rt.pivot = new Vector2(0, 1);
        rt.sizeDelta = new Vector2(tileSize, tileSize);
        rt.anchoredPosition = new Vector2(tileX, tileY);

        this.gameObject.AddComponent<Image>();
        
        var goImage = new GameObject("Image", typeof(RectTransform));
        var rtImage = goImage.transform as RectTransform;
        rtImage.parent = rt;

        rtImage.anchorMin = new Vector2(0, 0);
        rtImage.anchorMax = new Vector2(1, 1);
        rtImage.offsetMin = new Vector2(0, 0);
        rtImage.offsetMax = new Vector2(0, 0);

        m_image = goImage.AddComponent<Image>();
    }

    public void SetImage(string imageName, Color color)
    {
        Sprite sprite = null;
        if (imageName != string.Empty)
            sprite = Resources.Load<Sprite>(imageName);
        m_image.sprite = sprite;
        m_image.color = color;
    }

}
