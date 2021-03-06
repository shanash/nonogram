using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Defective.JSON;
using UnityEngine.UI;

public class LobbyScene : SceneBase
{
    [SerializeField]
    private Button m_baseStageButton = null;

    private List<int[]> m_listAnswers = new List<int[]>();

    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(WR());
    }
    private IEnumerator WR()
    {
        WWWForm form = new WWWForm();
        UnityWebRequest www = UnityWebRequest.Post("http://ec2-13-125-35-167.ap-northeast-2.compute.amazonaws.com:3030/", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);

            yield break;
        }

        Debug.Log($"Success : {www.downloadHandler.text}");
        var jsonObject = new JSONObject(www.downloadHandler.text);
        var value = jsonObject.list[0];

        foreach (var objAnswer in value)
        {
            int[] answer = new int[objAnswer.count];
            int i = 0;
            foreach (var item in objAnswer)
            {
                answer[i] = item.intValue;
                i++;
            }
            m_listAnswers.Add(answer);
        }

        CreateStage(m_listAnswers);
    }

    private void CreateStage(List<int[]> list)
    {
        m_baseStageButton.gameObject.SetActive(true);
        int index = 0;
        foreach (var answer in list)
        {
            Button btn = Instantiate(m_baseStageButton);
            btn.transform.parent = m_baseStageButton.transform.parent;
            btn.name = $"Button{index}";

            btn.transform.Find("Text").GetComponent<Text>().text = index.ToString();
            btn.onClick.AddListener(delegate () { _OnClick(btn.gameObject.name, null); });

            index++;
        }

        m_baseStageButton.gameObject.SetActive(false);
    }

    protected override void _OnClick(string buttonName, object[] list)
    {
        if (buttonName.Contains("Button"))
        {
            if (int.TryParse(buttonName.Replace("Button", ""), out int index))
            {
                if (index >= 0 && index < m_listAnswers.Count)
                {
                    SceneManager.I.ChangeScene("GameScene", m_listAnswers[index]);
                }
            }
        }
    }
}
