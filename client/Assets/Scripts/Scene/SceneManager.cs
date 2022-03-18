using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : BehaviourSingleton<SceneManager>
{
    #region Public Property
    public SceneBase CurrentScene
    {
        get;
        private set;
    }
    #endregion

    #region UI Members
    //private FadeController m_fader = null;
    #endregion

    #region Variable Members
    private bool m_isChanging = false;
    private string m_curSceneName = string.Empty;
    private string m_nextSceneName = string.Empty;
    private object m_parameterForScene = null;
    #endregion

    #region Monobehaviour Callback
    private void Start()
    {
        //GameObject original = await Addressables.InstantiateAsync("Assets/Data/Prefabs/FadeController.prefab").Task;
        //m_fader = original.GetComponent<FadeController>();
        //DontDestroyOnLoad(m_fader.gameObject);
    }
    #endregion

    #region Private Method
    private IEnumerator _CoChangeScene(string sceneName, object parameter)
    {
        m_isChanging = true;

        m_parameterForScene = parameter;

        //yield return new WaitUntil(() => m_fader != null);

        //yield return m_fader.CoFadeOut(1.0f);

        AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(
        sceneName,
        UnityEngine.SceneManagement.LoadSceneMode.Single);

        Resources.UnloadUnusedAssets();
        System.GC.Collect();

        yield return async;

        //yield return m_fader.CoFadeIn(1.0f);

        m_isChanging = false;
    }
    #endregion

    #region Public Method
    public void SetCurrent(SceneBase current)
    {
        CurrentScene = current;

        if (m_parameterForScene != null)
            CurrentScene.OnAwakeWithParameter(m_parameterForScene);
    }

    public void ChangeScene(string sceneName, object parameter = null)
    {
        if (m_isChanging)
            return;

        if (sceneName == m_curSceneName || sceneName == m_nextSceneName)
            return;

        // TODO: 올바른 scene이름인지 확인합니다.

        // TODO: 기존 팝업을 다 닫아줍니다.
        m_nextSceneName = sceneName;
        StartCoroutine(_CoChangeScene(sceneName, parameter));
    }
    #endregion
}
