using UnityEngine;


public abstract class SceneBase : MonoBehaviour
{
    protected PlayerControls m_controls = null;

    #region Monobehaviour Callback
    protected virtual void Awake()
    {
        _Init();
        m_controls = new PlayerControls();
    }
    #endregion

    #region Private Method
    protected void _Init()
    {
        SceneManager.I.SetCurrent(this);
    }

    protected void AddInputCallback(PlayerControls.ICursorActions listener)
    {
        m_controls.Cursor.SetCallbacks(listener);
    }
    #endregion
}
