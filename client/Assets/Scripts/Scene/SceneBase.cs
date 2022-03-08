using UnityEngine;


public abstract class SceneBase : MonoBehaviour
{
    protected PlayerControls m_controls = null;

    protected virtual void Awake()
    {
        m_controls = new PlayerControls();
    }

    protected void AddInputCallback(PlayerControls.ICursorActions listener)
    {
        m_controls.Cursor.SetCallbacks(listener);
    }
}
