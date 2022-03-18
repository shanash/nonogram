using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : SceneBase
{
    private int[] m_answer0 = new int[]
{
                    0,0,0,1,1,1,1,0,0,0,
                    0,0,1,1,0,0,1,1,0,0,
                    0,1,1,0,0,0,0,1,1,0,
                    0,1,0,0,0,0,0,0,1,0,
                    0,1,1,0,0,0,0,1,1,0,
                    0,0,1,1,0,0,1,1,0,0,
                    1,1,1,1,0,0,1,1,1,1,
                    0,0,0,0,0,0,0,0,0,0,
                    1,1,1,1,1,1,1,1,1,1,
                    0,0,0,0,0,0,0,0,0,0
};

    private int[] m_answer1 = new int[]
{
                    0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,
                    0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,
                    0,1,0,1,1,1,1,1,1,1,1,1,0,1,0,
                    0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,
                    0,0,0,1,0,1,0,1,0,1,0,1,0,0,0,
                    0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,
                    1,0,1,1,1,1,1,1,1,1,1,1,1,0,1,
                    0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,
                    0,0,0,1,1,0,1,0,1,0,1,1,0,0,0,
                    1,0,1,1,1,1,1,1,1,1,1,1,1,0,1,
                    1,0,1,1,0,1,1,0,1,1,0,1,1,0,1,
                    1,0,1,1,1,1,0,0,0,1,1,1,1,0,1,
                    1,0,1,0,0,1,0,1,0,1,0,0,1,0,1,
                    1,0,1,0,0,1,0,0,0,1,0,0,1,0,1,
                    1,0,1,0,1,1,0,0,0,1,1,0,1,0,1
};

    protected override void _OnClick(string buttonName, object[] list)
    {
        switch (buttonName)
        {
            case "Button0":
                SceneManager.I.ChangeScene("GameScene", m_answer0);
                break;
            case "Button1":
                SceneManager.I.ChangeScene("GameScene", m_answer1);
                break;
        }
    }
}
