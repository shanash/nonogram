using UnityEngine;
using UnityEngine.UI;

public abstract class SceneBase : MonoBehaviour
{
    protected PlayerControls m_controls = null;

    #region Monobehaviour Callback
    protected virtual void Awake()
    {
        _Init();

    }
    #endregion

    #region Private Method
    protected void _Init()
    {
        m_controls = new PlayerControls();
        SceneManager.I.SetCurrent(this);
        _InitButtons();
        _InitToggles();
    }

    protected void _InitButtons()
    {
        Button[] components = Resources.FindObjectsOfTypeAll<Button>();

        foreach (Button btn in components)
        {
            btn.onClick.AddListener(delegate () { _OnClick(btn.gameObject.name, null); });
        }
    }

    protected void _InitToggles()
    {
        Toggle[] components = Resources.FindObjectsOfTypeAll<Toggle>();

        foreach (Toggle tgl in components)
        {
            tgl.onValueChanged.AddListener(delegate (bool val) { _OnValueChanged(val, tgl.gameObject.name, null); });
        }
    }

    protected virtual void _OnValueChanged(bool value, string toggleName, object[] list)
    {
        //AudioManager.Instance.PlaySFX("button");
    }

    protected virtual void _OnClick(string buttonName, object[] list)
    {
        //AudioManager.Instance.PlaySFX("button");
    }

    protected void AddInputCallback(PlayerControls.ICursorActions listener)
    {
        m_controls.Cursor.SetCallbacks(listener);
    }

    public virtual void OnAwakeWithParameter(object param)
    {

    }
    #endregion
}
